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
        public RelayCommand Delete { get; }
        public RelayCommand Search { get; }
        public RelayCommand Connect { get; }
        public RelayCommand NavigateTo { get; }
        private Service1 service;
        private List<Utilisateur> _utilisateurs;
        private Utilisateur _utilisateur;

        public MainViewModel(Service1 service)
        {
            this.service = service;
            Name = service.GetFirstName();
            Utilisateurs = service.GetUtilisateurs();
            Delete = new RelayCommand(DeleteExecute, DeleteCanExecute);
            Search = new RelayCommand(SearchExecute, SearchCanExecute);
            Connect = new RelayCommand(ConnectExecute, ConnectCanExecute);
            NavigateTo = new RelayCommand(NavigateExecute, NavigateCanExecute);
            CurrentView = new Users();
            Visible = "Hidden";
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
        private string _visible;

        public string Visible
        {
            get { return _visible; }
            set
            {
                if (_utilisateur?.inscrit == true)
                {
                    _visible = "Visible";
                }
                else
                {
                    _visible = "Hidden";
                }
                RaisePropertyChanged();
            }
        }


        private string _search;

        public string ToSearch
        {
            get { return _search; }
            set { _search = value; RaisePropertyChanged();}
        }


        public Utilisateur utilisateur
        {
            get { return _utilisateur; }
            set
            {
                _utilisateur = value;
                RaisePropertyChanged();
            }
        }

        private string _name;

        
        public void NavigateExecute()
        {
            SendNavigationRequestMessage(new Uri("test.xaml", UriKind.Relative));
        }

        public bool NavigateCanExecute() { return true; }
        protected void SendNavigationRequestMessage(Uri uri)
        {
            Messenger.Default.Send<Uri>(uri, "NavigationRequest");
        }

        public List<Utilisateur> Utilisateurs
        {
            get { return _utilisateurs; }
            set
            {
                _utilisateurs = value;
                RaisePropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public void DeleteExecute()
        {
            if (utilisateur != null)
                service.Delete(utilisateur.id_utilisateur);
            Utilisateurs = service.GetUtilisateurs();
        }

        public bool DeleteCanExecute()
        {
            return Utilisateurs.Count > 1;
        }

        public void SearchExecute()
        {
            Utilisateurs = service.SearchUsers(ToSearch);
        }

        public bool SearchCanExecute() { return true; }
        public void ConnectExecute()
        {
            //utilisateur = service.GetUtilisateurByLoginAndPassword();
            if (utilisateur?.inscrit == true)
            {
                Visible = "Visible";
            }
            else
            {
                _visible = "Hidden";
            }
        }

        public bool ConnectCanExecute() { return true; }
#endregion
    }
}