﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNet.Interface;
using MovieNetApiWcf;
using GalaSoft.MvvmLight.Command;
using MovieNetDbProject;

namespace MovieNet.ViewModel
{
    public class SignInViewModel: MainViewModel
    {
        public RelayCommand<System.Windows.Controls.PasswordBox> Pass { get; private set; }
        private System.Security.SecureString password;
        
        public System.Security.SecureString Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(); }
        }
        
        public SignInViewModel()
        {
            Pass = new RelayCommand<System.Windows.Controls.PasswordBox>(param => PasswordExecute(param), PasswordCanExecute);
        }

        public void PasswordExecute(System.Windows.Controls.PasswordBox parameter)
        {
            Utilisateur.mdp_utilisateur = parameter.Password;
            Utilisateur.prenom_utilisateur = Utilisateur.nom_utilisateur;
            userService.Upsert(Utilisateur);
            
            Utilisateur = new Utilisateur();
            Password = null;
        }

        public bool PasswordCanExecute(object p) { return true; }
    }
}
