using GalaSoft.MvvmLight;
using MovieNetApiWcf;
using MovieNetDbProject;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using MovieNetDbProject.Dto;
using MovieNet.Tools;

namespace MovieNet.ViewModel
{
    public class UserViewModel : MainViewModel
    {

#region var

        public RelayCommand Add { get; }
        public MainWindowProperties m = MainWindowProperties.mainWindowProperties;
        public double FontSize { get; set; }
        public double HeightFormUser { get; set; }
        public double HeightTitle { get; set; }
        public double WidthFormUser { get; set; }
        public double WidthButtons { get; set; }
        public double PosLineY { get; set; }
        public double HeightUser { get; set; }
        public double WidthUser { get; set; }
        #endregion
        public UserViewModel()
        {
            Add = new RelayCommand(AddExecute, AddCanExecute);
            initGrids();
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
        private void initGrids()
        {
            HeightUser = m.Height * 0.85;
            WidthUser = m.Width;
            HeightFormUser = HeightUser - HeightUser * 0.05;
            HeightTitle = HeightUser * 0.05;
            FontSize = (m.Height * m.Width) / 103680;
            WidthFormUser = WidthUser * 3 / 9;
            PosLineY = HeightTitle + 3;
        }
    }
}
