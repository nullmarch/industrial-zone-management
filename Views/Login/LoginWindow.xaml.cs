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
using WpfApplication2.Views.Login;

namespace WpfApplication2.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            ContentFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            ContentFrame.Navigate(new Connexion());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var button = MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application ? ", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
          

            if (button == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else if (button == MessageBoxResult.No)
            {

            }
        }
    }
}
