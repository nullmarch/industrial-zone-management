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
using WpfApplication2;
using WpfApplication2.Views.Zone;
using WpfApplication2.Views.Lots;
using WpfApplication2.Views.Investisseurs;
using WpfApplication2.Views.Attributions;
using System.Windows.Shapes;

namespace WpfApplication2.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void ExitButoon_Click(object sender, RoutedEventArgs e)
        {
            var button = MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application ? Toutes les modifications ont été enregistrées", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
            

            if (button == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else if (button == MessageBoxResult.No)
            {

            }

        }

        private void btnLZ_Click(object sender, RoutedEventArgs e)
        {
            ListZone LZ = new ListZone();
            this.NavigationService.Navigate(LZ); 
         
        }

        private void btnInvst_Click(object sender, RoutedEventArgs e)
        {
            ListInvestisseurs LS = new ListInvestisseurs();
            this.NavigationService.Navigate(LS);            
 
        }

        private void btnLT_Click(object sender, RoutedEventArgs e)
        {
            ListLots LT = new ListLots();
            this.NavigationService.Navigate(LT);
         
        }

        private void btnAttrib_Click(object sender, RoutedEventArgs e)
        {
            ListAttributions LA = new ListAttributions();
            this.NavigationService.Navigate(LA);
        }
    }
}
