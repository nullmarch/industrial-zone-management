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
using WpfApplication2.Controlers;
using WpfApplication2.Views.Lots;
using MySql.Data.MySqlClient;

namespace WpfApplication2.Views.Lots
{
    /// <summary>
    /// Interaction logic for AddLots.xaml
    /// </summary>
    public partial class AddLots : Page
    {
        int id = 0;
        public AddLots(int id)
        {
            InitializeComponent();
            this.id = id;

            sqlhelper sh = new sqlhelper();
            sh.loadfilldata2("select IdZone,NomDeZone from zone", IdZone, "IdZone","NomDeZone");
            if (id != 0)
                try
                {

                    string query = "select * from lot where IdLot =" + id + "";
                    MySqlDataReader rdr = null;
                    MySqlConnection con = null;
                    MySqlCommand cmd = null;

                    con = new MySqlConnection("Server=localhost;Port=3306;Database=agerfor;Uid=root;Pwd=");
                    con.Open();
                    cmd = new MySqlCommand(query);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    bool oneTime = true;
                    while (rdr.Read())
                    {

                        if (oneTime)
                        {
                            IdZone.Text = rdr["IdZone"].ToString();
                            NumLot.Text = rdr["NumLot"].ToString();
                          /*NumeroActe.Text = rdr["NumeroActe"].ToString();
                            DateActe.Text = rdr["DateActe"].ToString();
                            DateArrete.Text = rdr["DateArrete"].ToString();*/
                            Ilot.Text = rdr["Ilot"].ToString();
                            Surface.Text = rdr["Surface"].ToString();
                            
                        }



                    }
                    con.Close();
                }


                catch (Exception)
                {

                }

        }

        private void AjouterLot_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string idzone = sh.GetUntilOrEmpty(IdZone.SelectedItem.ToString(), "-");
            LotController LC = new LotController();
            LC.AjouterLot(int.Parse(idzone),int.Parse(NumLot.Text),int.Parse(Ilot.Text),double.Parse(Surface.Text));
            
            ListLots LL = new ListLots();
            NavigationService.Navigate(LL);

        }
        private void ModifierLot_Click(object sender, RoutedEventArgs e)
        {
            LotController LC = new LotController();
            LC.ModifierLot(id, int.Parse(IdZone.Text),int.Parse(NumLot.Text),int.Parse(Ilot.Text),double.Parse(Surface.Text));

            ListLots LL = new ListLots();
            NavigationService.Navigate(LL);
        }

        private void SupprimerLot_Click(object sender, RoutedEventArgs e)
        {
            
              
        }

      

     

        private void IdZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        
            sqlhelper sh = new sqlhelper();
          //  sh.loadfilldata2("select NomDeZone from zone where IdZone=" + IdZone.SelectedItem.ToString() + "",NomDeZone, "NomDeZone");



        }

        private void InputNumLot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
