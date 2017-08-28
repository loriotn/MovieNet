using GalaSoft.MvvmLight;
using MovieNetApiWcf;
using MovieNetDbProject;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;

namespace MovieNet.ViewModel
{
    public class UserViewModel : MainViewModel
    {

#region var

        public RelayCommand Add { get; }
#endregion
        public UserViewModel()
        {
            Utilisateurs = userService.GetAll();
            Add = new RelayCommand(AddExecute, AddCanExecute);
        }

        #region getset
        private List<Utilisateur> _utilisateurs;
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

        #region relaycommand
        public void AddExecute()
        {
            //Utilisateurs = service.AddUser(Utilisateur);
            Utilisateur = new Utilisateur();
        }

        public bool AddCanExecute()
        {
            return (Utilisateur.nom_utilisateur?.Length > 0 && Utilisateur.prenom_utilisateur?.Length > 0);
        }
#endregion
    }
}
