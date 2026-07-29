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
using MySql.Data.MySqlClient;
using WpfApplication2.Controlers;

namespace WpfApplication2.Views.Login
{
    /// <summary>
    /// Interaction logic for Connexion.xaml
    /// </summary>
    public partial class Connexion : Page
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void BtnConnx_Click(object sender, RoutedEventArgs e)
        {
            UserManager UM = new UserManager();

          if ( UM.ValidateUser(UsernameInput.Text, PasswordInput.Password))
            {
                MainWindow mw = new MainWindow();
                Application.Current.Windows[0].Close();
                mw.ShowDialog();
                
          
                
            }
          else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe invalide, veuillez réessayer!");
                UsernameInput.Clear();
                PasswordInput.Clear();
            }
            


        }

        private void BtnCreeU_Click(object sender, RoutedEventArgs e)
        {
            CreationU cu = new CreationU();
            this.NavigationService.Navigate(cu);        }
    }
}
