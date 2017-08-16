using GalaSoft.MvvmLight;
using MovieNetApiWcf;
using MovieNetDbProject;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;

namespace MovieNet.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand Delete { get; }
        public RelayCommand Search { get; }
        public Service1 service = new Service1();

        private List<Utilisateur> _utilisateurs;
        private Utilisateur _utilisateur;

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

        public MainViewModel()
        {
            Name = service.GetFirstName();
            Utilisateurs = service.GetUtilisateurs();
            Delete = new RelayCommand(DeleteExecute, DeleteCanExecute);
            Search = new RelayCommand(SearchExecute, SearchCanExecute);
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
    }
}