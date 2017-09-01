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

namespace MovieNet.ViewModel
{
    public class ConnectWindowViewModel: MainViewModel
    {

        public ConnectWindowViewModel()
        {
            Utilisateur = new Utilisateur();
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
                bool isValid = true;
                if (WantConnect)
                {
                    Utilisateur.mdp_utilisateur = parameter?.Password;
                    Utilisateur = Facade?.userService.GetByLogin(Utilisateur?.nom_utilisateur, Utilisateur?.mdp_utilisateur);
                    Utilisateur = nullUser(Utilisateur, ref isValid, "Veuillez saisir un login et un mot de passe valide");
                }
                else
                {
                    sign(parameter, ref isValid);
                }
                endSignIn(isValid);
            }

            public void Close()
            {
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
                Utilisateur = Facade?.userService.Upsert(Utilisateur);
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

        private void endSignIn(bool isValid)
        {
            if (isValid)
            {
                UserViewModel.Utilisateurs = Facade.userService.GetAll();
                MainViewModel.id = Utilisateur.id;
                Utilisateur = new Utilisateur();
                Password = null;
                DialogService.Dialogs.CloseDialog();
            }
        }

        private Utilisateur nullUser(Utilisateur util, ref bool isValid, string errorMessage)
        {
            util = new Utilisateur();
            Error = errorMessage;
            isValid = false;
            Password = null;
            return util;
        }

        #endregion
    }
}
