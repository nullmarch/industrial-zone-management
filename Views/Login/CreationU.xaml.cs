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
using WpfApplication2.Views.Login;

namespace WpfApplication2.Views.Login
{
    /// <summary>
    /// Interaction logic for CreationU.xaml
    /// </summary>
    public partial class CreationU : Page
    {
        public CreationU()
        {
            InitializeComponent();
        }

        private void BtnConnxNavigate_Click(object sender, RoutedEventArgs e)
        {
            Connexion c = new Connexion();
            this.NavigationService.Navigate(c);
        }

        private void BtnCreeU1_Click(object sender, RoutedEventArgs e)
        {
            UserManager UM = new UserManager();
            Connexion C = new Connexion();
            string passwordInput1 = passwordInput.Password;
            string passwordConfirm1 = passwordConfirm.Password;
            if (passwordInput1 == passwordConfirm1)
            {
                UM.RegisterUser(usernameInput.Text, passwordInput.Password);
                MessageBox.Show("L'utilisateur a été créé");
                NavigationService.Navigate(C);

            }
            else if (passwordInput != passwordConfirm)
            {
                MessageBox.Show("Le mot de passe ne correspond pas, veuillez réessayer!");
                passwordInput.Clear();
                passwordConfirm.Clear();
            }
           

          
        }
    }
}
