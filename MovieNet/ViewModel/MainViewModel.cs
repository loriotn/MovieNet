using GalaSoft.MvvmLight;
using MovieNetApiWcf;
using MovieNetDbProject;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using System.Windows;
using MovieNet.Tools;
using MovieNetDbProject.Dto;

namespace MovieNet.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public Window w = MainWindowProperties.mainWindowProperties.mainWindow;
        public double Height { get; set; }
        public double HeightContentPresenter { get; set; }
        public double HeightStackPanel { get; set; }
        public double Width { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
        public ResizeMode ResizeMode { get; set; }
        public RelayCommand<string> NavigateTo { get; private set; }
        public RelayCommand openWindow { get; private set; }
        public RelayCommand Disconnect { get; private set; }
        public string welcomMessage;
        private UserDto _utilisateur;
        private UserControl selectedView;
        public static Window fen;
        public static int id { get; set; }
        private string welcomeMessage;

        public string WelcomeMessage
        {
            get { return welcomeMessage; }
            set { welcomeMessage = "Bonjour " + value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            setBindingWindowSettings();
            NavigateTo = new RelayCommand<string>((param) => NavigateExecute(param), NavigateCanExecute);
            openWindow = new RelayCommand(open, openCan);
            Disconnect = new RelayCommand(disconnect, disconnectCan);
            Utilisateur = new UserDto();
            WelcomeMessage = Utilisateur?.nom_utilisateur;
        }

        public void disconnect()
        {
            Utilisateur = new UserDto();
            ViewModelLocator.FilmVm.Films = null;
            CurrentView = null;
            WelcomeMessage = Utilisateur?.nom_utilisateur;
        }

        public bool disconnectCan()
        {
            if (Utilisateur != null)
                return Utilisateur.connecte;
            else return false;
        }
        private void setBindingWindowSettings()
        {
            Height = w.Height;
            Width = w.Width;
            Top = w.Top;
            Left = w.Left;
            HeightContentPresenter = Height * 0.85;
            HeightStackPanel = Height * 0.1;
            this.ResizeMode = w.ResizeMode;
        }
        public void open()
        {
            DialogService.Dialogs.OpenDialog(typeof(ConnectWindow));
            Utilisateur = ViewModelLocator.Facade.userService.GetById(id) ?? new UserDto();
            WelcomeMessage = Utilisateur?.nom_utilisateur;
        }

        public bool openCan()
        {
            if (Utilisateur != null)
                return !Utilisateur.connecte;
            else
                return true;
        }
        private UserControl _currentView;

        public UserControl CurrentView
        {
            get { return _currentView; }
            set
            {
                if (value != _currentView)
                {
                    _currentView = value;
                    RaisePropertyChanged("CurrentView");
                }
                
            }
        }

        #region beforetest

        public UserDto Utilisateur
        {
            get { return _utilisateur; }
            set
            {
                _utilisateur = value;
                RaisePropertyChanged();
            }
        }
        
        public void NavigateExecute(string parameter)
        {
            if (parameter.Equals("user"))
            {
                selectedView = new Users();
            }
            else if (parameter.Equals("film"))
            {
                ViewModelLocator.FilmVm.initMovies();
                selectedView = new Films();
            }
            else if (parameter.Equals("welcome"))
            {
                selectedView = new Welcome();
            }
            else
            {
                selectedView = null;
            }
            CurrentView = selectedView;
        }

        public bool NavigateCanExecute(string p) { return Utilisateur.connecte; }
        
#endregion
    }
}