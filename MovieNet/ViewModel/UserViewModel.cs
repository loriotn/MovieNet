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
    public class UserViewModel : ViewModelBase
    {
        private Service1 service;
        public UserViewModel(Service1 service)
        {
            this.service = service;
            Utils = service.GetUtilisateurs();
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

    }
}
