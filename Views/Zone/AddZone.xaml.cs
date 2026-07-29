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
using WpfApplication2.Views.Zone;
using MySql.Data.MySqlClient;

namespace WpfApplication2.Views.Zone
{
    /// <summary>
    /// Interaction logic for AddZone.xaml
    /// </summary>
    public partial class AddZone : Page

        
    {
        int id = 0;
        public AddZone(int id)
        {

            InitializeComponent();
            this.id = id;

            sqlhelper sh = new sqlhelper();

            sh.loadfilldata("select NomDaira from daira", InputDaira, "NomDaira");
            // MessageBox.Show(id.ToString());
            
            if (id != 0)
                try
                {
                   
                    string query = "select * from zone where IdZone =" + id + "";
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
                            IdZone.Text = rdr["IdZone"].ToString()+"- " +rdr["NomDeZone"].ToString();
                            NomDeZone.Text = rdr["NomDeZone"].ToString();
                            InputDaira.Text = rdr["NomDaira"].ToString();
                            InputCommune.Text = rdr["Nomcommune"].ToString();
                            proprietaire.Text = rdr["Proprietaire"].ToString();
                            NumeroActe.Text = rdr["NumeroActe"].ToString();
                            VolActe.Text = rdr["VolActe"].ToString();
                            DateActe.Text = rdr["DateActe"].ToString();
                            NumPL.Text = rdr["NumPL"].ToString();
                            DatePL.Text = rdr["DatePL"].ToString();
                            NumCC.Text = rdr["NumCC"].ToString();
                            VolCC.Text = rdr["VolCC"].ToString();
                            DateCC.Text = rdr["DateCC"].ToString();
                            SurfaceBrute.Text = rdr["SurfaceBrute"].ToString();
                            SurfaceCessible.Text = rdr["SurfaceCessible"].ToString();
                            NombredesLots.Text = rdr["NombredesLots"].ToString();
                        }



                    }
                    con.Close();
                }


                catch (Exception)
                {

                }
        }       

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void InputDaira_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputCommune.Items.Clear();
            sqlhelper sh = new sqlhelper();
            string iddaira = sh.getdata("select IdDaira from daira where NomDaira='" + InputDaira.SelectedItem + "'", "IdDaira");
            sh.loadfilldata("select NomCommune from commune where IdDaira=" + iddaira+ "",  InputCommune , "NomCommune");
        }

        private void BtnAjtZone_Click(object sender, RoutedEventArgs e)
        {
            
            ZoneController ZC = new ZoneController();
            ZC.AjouterZone(NomDeZone.Text, InputDaira.Text ,InputCommune.Text,proprietaire.Text,int.Parse(NumeroActe.Text),int.Parse(VolActe.Text),DateActe.Text,int.Parse(NumPL.Text),DatePL.Text,int.Parse(NumCC.Text),int.Parse(VolCC.Text),DateCC.Text,double.Parse(SurfaceBrute.Text),double.Parse(SurfaceCessible.Text), int.Parse(NombredesLots.Text));

            ListZone LZ = new ListZone();
            this.NavigationService.Navigate(LZ);

        }
        private void BtnModZone_Click(object sender, RoutedEventArgs e)
        {
            
            ZoneController ZC = new ZoneController();
            ZC.ModifierZone(int.Parse(IdZone.Text),NomDeZone.Text, InputDaira.Text, InputCommune.Text, proprietaire.Text, int.Parse(NumeroActe.Text), VolActe.Text,DateActe.Text, int.Parse(NumPL.Text), DatePL.Text, int.Parse(NumCC.Text), int.Parse(VolCC.Text), DateCC.Text, double.Parse(SurfaceBrute.Text), double.Parse(SurfaceCessible.Text), int.Parse(NombredesLots.Text));

            ListZone LZ = new ListZone();
            this.NavigationService.Navigate(LZ);

        }
        private void BtnSupZone_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void NomDeZone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}