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
    public class TestFenetreViewModel: MainViewModel
    {
        public RelayCommand<PasswordBox> signin { get; private set; }
        private System.Security.SecureString password;

        public System.Security.SecureString Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(); }
        }
        public TestFenetreViewModel()
        {
            Utilisateur = new Utilisateur();
            signin = new RelayCommand<PasswordBox>(param => Signin(param), CanSignIn);
        }
        public void Signin(System.Windows.Controls.PasswordBox parameter)
        {
            Utilisateur.mdp_utilisateur = parameter.Password;
            Utilisateur.prenom_utilisateur = Utilisateur.nom_utilisateur;
            Utilisateur = Facade.userService.Upsert(Utilisateur);
            UserViewModel.Utilisateurs = Facade.userService.GetAll();
            MainViewModel.id = Utilisateur.id;
            Utilisateur = new Utilisateur();
            Password = null;
            MainViewModel.fen.Close();
        }
        public bool CanSignIn(System.Windows.Controls.PasswordBox parameter) { return true; }
    }
}
