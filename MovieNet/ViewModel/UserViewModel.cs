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
        private UserService service;
        public RelayCommand Add { get; }
#endregion
        public UserViewModel()
        {
            this.service = new UserService(ModelMovieNet.GetContext());
            Utilisateur = new Utilisateur();
            Add = new RelayCommand(AddExecute, AddCanExecute);
            Utilisateurs = service.GetAll();
        }

#region getset

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
