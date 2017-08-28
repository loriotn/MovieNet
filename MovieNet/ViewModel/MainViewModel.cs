using GalaSoft.MvvmLight;
using MovieNetApiWcf;
using MovieNetDbProject;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using System.Windows;

namespace MovieNet.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand<string> NavigateTo { get; private set; }
        private Service1 service;
        private List<Utilisateur> _utilisateurs;
        private Utilisateur _utilisateur;
        private UserControl selectedView;

        public MainViewModel(Service1 service)
        {
            this.service = service;
            NavigateTo = new RelayCommand<string>((param) => NavigateExecute(param), NavigateCanExecute);
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

        public Utilisateur Utilisateur
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
                selectedView = new Films();
            }
            else if (parameter.Equals("signin"))
            {
                selectedView = new SignIn();
            }
            else
            {
                selectedView = null;
            }
            CurrentView = selectedView;
        }

        public bool NavigateCanExecute(string p) { return true; }
        public List<Utilisateur> Utilisateurs
        {
            get { return _utilisateurs; }
            set
            {
                _utilisateurs = value;
                RaisePropertyChanged();
            }
        }
#endregion
    }
}