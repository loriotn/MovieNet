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
    public class ConnectWindowViewModel: MainViewModel
    {

        public ConnectWindowViewModel()
        {
            Utilisateur = new UserDto();
            signin = new RelayCommand<PasswordBox>(param => Signin(param), CanSignIn);
            close = new RelayCommand(Close, CanClose);
        }

        #region relayCommande

        public RelayCommand<PasswordBox> signin { get; private set; }
        public RelayCommand close { get; private set; }

        #endregion

        #region privateVar

        private System.Security.SecureString password;
        private string error;
        private bool wantConnect;
        private bool isValid;
        #endregion

        #region publicVar

        public bool WantConnect
        {
            get { return wantConnect; }
            set { wantConnect = value; RaisePropertyChanged(); }
        }

        public string Error
        {
            get { return error; }
            set { error = value; RaisePropertyChanged(); }
        }

        public System.Security.SecureString Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(); }
        }
        #endregion

        #region relayCommandMethods

            #region voidMethods

            public void Signin(PasswordBox parameter)
            {
                isValid = true;
            if (WantConnect)
            {
                Utilisateur.mdp_utilisateur = parameter?.Password;
                Utilisateur = ViewModelLocator.Facade?.userService.GetByLogin(Utilisateur?.nom_utilisateur, Utilisateur?.mdp_utilisateur);
                if (Utilisateur == null)
                    Utilisateur = nullUser(Utilisateur, ref isValid, "Veuillez saisir un login et un mot de passe valide");
            }
            else if (string.IsNullOrEmpty(parameter?.Password) || string.IsNullOrEmpty(Utilisateur?.nom_utilisateur))
                Utilisateur = nullUser(Utilisateur, ref isValid, "Veuillez saisir un login et un mot de passe valide");
            else if (ViewModelLocator.Facade?.userService.GetByLogin(Utilisateur?.nom_utilisateur) != null)
                Utilisateur = nullUser(Utilisateur, ref isValid, "Ce login existe déjà");
            else
                sign(parameter, ref isValid);
            endSignIn(ref isValid);
            }

            public void Close()
            {
                nullUser(Utilisateur,ref isValid);
                MainViewModel.id = 0;
                DialogService.Dialogs.CloseDialog();
            }

            #endregion

            #region canMethods

            public bool CanClose() { return true; }
            public bool CanSignIn(PasswordBox parameter) { return true; }

        #endregion

        #endregion

        #region privateMethods

        private void sign(PasswordBox parameter, ref bool isValid)
        {
            Utilisateur.mdp_utilisateur = parameter?.Password;
            Utilisateur.prenom_utilisateur = Utilisateur.nom_utilisateur;

            if (!string.IsNullOrEmpty(Utilisateur.mdp_utilisateur) && !string.IsNullOrEmpty(Utilisateur.prenom_utilisateur) && !string.IsNullOrEmpty(Utilisateur.nom_utilisateur))
            {
                Utilisateur.connecte = true;
                Utilisateur.inscrit = true;
                Utilisateur = ViewModelLocator.Facade?.userService.Upsert(Utilisateur);
                if (Utilisateur == null)
                    nullUser(Utilisateur, ref isValid, "Ce login existe déjà");
                Error = string.Empty;
            }
            else
            {
                Error = "Veuillez saisir un login et un mot de passe valide";
                isValid = false;
            }
        }

        private void endSignIn(ref bool isValid)
        {
            if (isValid == true)
            {
                UserViewModel.Utilisateurs = ViewModelLocator.Facade.userService.GetAll();
                MainViewModel.id = Utilisateur.id;
                Utilisateur = new UserDto();
                Password = null;
                DialogService.Dialogs.CloseDialog();
            }
        }

        private UserDto nullUser(UserDto util, ref bool isValid, string errorMessage = "")
        {
            util = new UserDto();
            Error = errorMessage;
            isValid = false;
            Password = null;
            return util;
        }

        #endregion
    }
}
