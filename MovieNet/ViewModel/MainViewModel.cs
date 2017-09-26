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
using System.Windows.Media.Imaging;
using System.IO;

namespace MovieNet.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainWindowProperties m = MainWindowProperties.mainWindowProperties;
        private string userExist;

        public string UserExist
        {
            get { return userExist; }
            set { userExist = value; RaisePropertyChanged(); }
        }

        public double FontSize { get; set; }
        public double HeightFormUser { get; set; }
        public double HeightTitle { get; set; }
        public double WidthFormUser { get; set; }
        public double WidthButtons { get; set; }
        public double PosLineY { get; set; }
        public double HeightUser { get; set; }
        public double WidthUser { get; set; }
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
        public RelayCommand OpenUserFlyout { get; private set; }
        public RelayCommand UpdateUser { get; private set; }
        public RelayCommand DeleteUser { get; private set; }
        public RelayCommand Disconnect { get; private set; }
        public string welcomMessage;
        private UserDto _utilisateur;
        private UserControl selectedView;
        public static Window fen;
        public static int id { get; set; }
        private string welcomeMessage;
        public Uri iconUri { get; set; }
        public object icon { get; set; }
        private bool isOpenFlyoutComment;

        public bool IsOpenFlyoutComment
        {
            get { return isOpenFlyoutComment; }
            set { isOpenFlyoutComment = value; RaisePropertyChanged(); }
        }
        private bool isOpenFlyoutFilter;

        public bool IsOpenFlyoutFilter
        {
            get { return isOpenFlyoutFilter; }
            set { isOpenFlyoutFilter = value; RaisePropertyChanged(); }
        }

        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set { isOpen = value; RaisePropertyChanged("IsOpen"); }
        }

        public string WelcomeMessage
        {
            get { return welcomeMessage; }
            set { welcomeMessage = "Bonjour " + value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            IsOpen = false;
            setBindingWindowSettings();
            initIcon();
            initGrids();
            NavigateTo = new RelayCommand<string>((param) => NavigateExecute(param), NavigateCanExecute);
            openWindow = new RelayCommand(open, openCan);
            Disconnect = new RelayCommand(disconnect, disconnectCan);
            OpenUserFlyout = new RelayCommand(OpenUserFlyoutCan, OpenUserFlyoutCanExecute);
            UpdateUser = new RelayCommand(UpdateUserCan, UpdateUserCanExecute);
            DeleteUser = new RelayCommand(DeleteUserCan, DeleteUserCanExecute);
            Utilisateur = new UserDto();
            WelcomeMessage = Utilisateur?.nom_utilisateur;
        }
        public void DeleteUserCan()
        {
            ViewModelLocator.Facade.userService.Delete(Utilisateur.id);
            disconnect();
        }

        public bool DeleteUserCanExecute() { return Utilisateur?.id > 0 ? true : false; }
        public void UpdateUserCan()
        {
            if (ViewModelLocator.Facade.userService.GetByLogin(Utilisateur?.nom_utilisateur, Utilisateur.id) != null)
            {
                UserExist = "Ce login existe déjà";
                return;
            }
            else
                ViewModelLocator.Facade.userService.Upsert(Utilisateur);
        }
        public bool UpdateUserCanExecute() { return Utilisateur?.id > 0 ? true : false; }
        public void OpenUserFlyoutCan()
        {
            IsOpen = !IsOpen;
        }

        public bool OpenUserFlyoutCanExecute() { return Utilisateur.connecte; }
        private void initIcon()
        {
            try
            {
                iconUri = new Uri("pack://application:,,,/IconMainWindow.ico", UriKind.RelativeOrAbsolute);
                icon = BitmapFrame.Create(iconUri);
            }
            catch (IOException e)
            {
                throw new IOException(e.StackTrace);
            }
            
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
            else
            {
                selectedView = null;
            }
            CurrentView = selectedView;
        }
        private void initGrids()
        {
            HeightUser = m.Height * 0.85;
            WidthUser = m.Width;
            HeightFormUser = HeightUser - HeightUser * 0.05;
            HeightTitle = HeightUser * 0.05;
            FontSize = (m.Height * m.Width) / 103680;
            WidthFormUser = WidthUser * 3 / 9;
            PosLineY = HeightTitle + 3;
        }
        public bool NavigateCanExecute(string p) { return Utilisateur.connecte; }
        
#endregion
    }
}