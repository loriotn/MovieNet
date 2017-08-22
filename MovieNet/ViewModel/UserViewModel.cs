﻿using GalaSoft.MvvmLight;
using MovieNetApiWcf;
using MovieNetDbProject;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;

namespace MovieNet.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private Service1 service;
        public RelayCommand Add { get; }
        public UserViewModel(Service1 service)
        {
            this.service = service;
            Utils = service.GetUtilisateurs();
            Util = new Utilisateur();
            Add = new RelayCommand(AddExecute, AddCanExecute);
        }

        private List<Utilisateur> _utils;

        public List<Utilisateur> Utils
        {
            get { return _utils; }
            set
            {
                _utils = value;
                RaisePropertyChanged();
            }
        }

        private Utilisateur _util;

        public Utilisateur Util
        {
            get { return _util; }
            set { _util = value; RaisePropertyChanged(); }
        }

        public void AddExecute()
        {
            Utils = service.AddUser(Util);
            Util = new Utilisateur();
        }

        public bool AddCanExecute()
        {
            return (Util.nom_utilisateur?.Length > 0 && Util.prenom_utilisateur?.Length > 0);
        }

    }
}
