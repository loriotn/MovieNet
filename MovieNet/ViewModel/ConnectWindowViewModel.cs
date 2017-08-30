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
        public RelayCommand<PasswordBox> signin { get; private set; }
        public RelayCommand close { get; private set; }
        private System.Security.SecureString password;
        private string error;

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
        public ConnectWindowViewModel()
        {
            Utilisateur = new Utilisateur();
            signin = new RelayCommand<PasswordBox>(param => Signin(param), CanSignIn);
            close = new RelayCommand(Close, CanClose);
        }
        public void Close()
        {
            DialogService.Dialogs.CloseDialog();
        }
        public bool CanClose() { return true; }
        public void Signin(PasswordBox parameter)
        {
            bool isValid = true;
            isValid = sign(parameter, isValid);
            if (isValid)
            {
                UserViewModel.Utilisateurs = Facade.userService.GetAll();
                MainViewModel.id = Utilisateur.id;
                Utilisateur = new Utilisateur();
                Password = null;
                DialogService.Dialogs.CloseDialog();
            }
        }
        public bool CanSignIn(PasswordBox parameter) { return true; }
        private bool sign(PasswordBox parameter, bool isValid)
        {
            Utilisateur.mdp_utilisateur = parameter?.Password;
            Utilisateur.prenom_utilisateur = Utilisateur.nom_utilisateur;
            
            if (!string.IsNullOrEmpty(Utilisateur.mdp_utilisateur) && !string.IsNullOrEmpty(Utilisateur.prenom_utilisateur) && !string.IsNullOrEmpty(Utilisateur.nom_utilisateur))
            {
                Utilisateur.connecte = true;
                Utilisateur.inscrit = true;
                Utilisateur = Facade?.userService.Upsert(Utilisateur);
                Error = string.Empty;
            }
            else
            {
                Error = "Veuillez saisir un login et un mot de passe valide";
                isValid = false;
            }
            return isValid;    
        }
    }
}
