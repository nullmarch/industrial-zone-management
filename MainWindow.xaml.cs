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
using WpfApplication2.Views;
using WpfApplication2.Views.Zone;
using WpfApplication2.Views.Lots;
using WpfApplication2.Views.Attributions;
using WpfApplication2.Views.Investisseurs;


namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Dashboard());
        }
              

        private void btnLZ_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new ListZone());
        }

        private void btnLT_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new ListLots());
        }

        private void btnAttrib_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new ListAttributions());
        }

        private void btnInvst_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new ListInvestisseurs());
        }

        private void btntdb_Click(object sender, RoutedEventArgs e)
        {
            Dashboard DB = new Dashboard();
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Dashboard());
        }




        /* private void btntdb_Click(object sender, RoutedEventArgs e)
         {
             Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
             Frame.Navigate(new Tableau_Du_Board());
         }*/
    }
}
