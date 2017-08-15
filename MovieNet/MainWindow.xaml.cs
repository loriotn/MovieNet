using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MovieNetApiWcf;
using MovieNetDbProject;

namespace MovieNet
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Service1 service = new Service1();
        private CollectionViewSource utilisateurViewSource;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            utilisateurViewSource = ((CollectionViewSource)(FindResource("utilisateurViewSource")));
            utilisateurViewSource.Source = service.GetUtilisateurs();
            utilisateurViewSource.View.MoveCurrentToLast();
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // utilisateurViewSource.Source = [source de données générique]
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (utilisateurViewSource.View.CurrentPosition > 0)
                utilisateurViewSource.View.MoveCurrentToPrevious();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (utilisateurViewSource.View.CurrentPosition < ((CollectionView)utilisateurViewSource.View).Count - 1)
            {
                utilisateurViewSource.View.MoveCurrentToNext();
            }
        }
    }
}
