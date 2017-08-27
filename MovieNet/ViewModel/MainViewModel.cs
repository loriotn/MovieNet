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
        public RelayCommand NavigateTo { get; }
        private Service1 service;
        private List<Utilisateur> _utilisateurs;
        private Utilisateur _utilisateur;

        public MainViewModel(Service1 service)
        {
            this.service = service;
            NavigateTo = new RelayCommand(NavigateExecute, NavigateCanExecute);
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
        
        public void NavigateExecute()
        {
            CurrentView = new Users();
        }

        public bool NavigateCanExecute() { return true; }
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