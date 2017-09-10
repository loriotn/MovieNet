using GalaSoft.MvvmLight;
using MovieNetApiWcf;
using MovieNetDbProject;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using MovieNetDbProject.Dto;

namespace MovieNet.ViewModel
{
    public class UserViewModel : MainViewModel
    {

#region var

        public RelayCommand Add { get; }
#endregion
        public UserViewModel()
        {
            Add = new RelayCommand(AddExecute, AddCanExecute);
        }

        #region getset

        #endregion

        #region relaycommand
        public void AddExecute()
        {
            //Utilisateurs = service.AddUser(Utilisateur);
            Utilisateur = new UserDto();
        }

        public bool AddCanExecute()
        {
            return (Utilisateur.nom_utilisateur?.Length > 0 && Utilisateur.prenom_utilisateur?.Length > 0);
        }
#endregion
    }
}
