using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps;
using MahApps.Metro.Controls;

namespace MovieNet.Tools
{
    public class DialogService
    {
        private static readonly DialogService _dialogService = new DialogService();
        private MetroWindow windowToOpen;
        public DialogService() { }

        public static DialogService Dialogs { get { return _dialogService; } }

        public void OpenDialog(Type window)
        {
            windowFactory(window);
            buildDialogProperties();
            windowToOpen?.ShowDialog();
        }

        public void CloseDialog()
        {
            windowToOpen?.Close();
        }

        private void windowFactory(Type window)
        {
            if (window == typeof(ConnectWindow))
            {
                windowToOpen = new ConnectWindow();
            }
            else if (window == typeof(SaveMovieWindow))
            {
                windowToOpen = new SaveMovieWindow();
            }
        }

        private void buildDialogProperties()
        {
            MainWindowProperties m = MainWindowProperties.mainWindowProperties;
            windowToOpen.Width = m.Width;
            windowToOpen.Top = m.VerticalPosition - (windowToOpen.Height / 2);
            windowToOpen.Left = m.HorizontalPosition;
            windowToOpen.ResizeMode = ResizeMode.NoResize;
            windowToOpen.ShowIconOnTitleBar = false;
            windowToOpen.UseNoneWindowStyle = true;
        }
    }
}
