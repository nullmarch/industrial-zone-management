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
using WpfApplication2.Views.Attributions;
using WpfApplication2.Controlers;



namespace WpfApplication2.Views.Attributions
{
    /// <summary>
    /// Interaction logic for AddAttributions.xaml
    /// </summary>
    public partial class AddAttributions : Page
    {
        int id = 0;
        public AddAttributions(int id)
        {
         
            InitializeComponent();
           
            this.id = id;
            
            Mode.Items.Add("Concession");
            Mode.Items.Add("Cession");

            sqlhelper sh = new sqlhelper();
            sh.loadfilldata2("select IdZone,NomDeZone from zone", IdZone, "IdZone", "NomDeZone");
            
           
             sh.loadfilldata2("select IdInvestisseur,RaisonSociale from investisseur ", InputIdInvestisseur, "IdInvestisseur","RaisonSociale");
            
           

            if (id!= 0)
                try
                {

                    string query = "select * from attribution,investisseur,zone,lot where IdAttribution =" + id + " and attribution.IdInvestisseur=investisseur.IdInvestisseur and attribution.IdLot=lot.IdLot and lot.IdZone=zone.IdZone";
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
                            IdAttribution.Text = rdr["IdAttribution"].ToString();
                            InputIdInvestisseur.Text = rdr["IdInvestisseur"].ToString()+"-"+rdr["RaisonSociale"].ToString();
                            IdZone.Text = rdr["IdZone"] + "-" + rdr["NomDeZone"].ToString();
                            InputIdLot.Text = rdr["IdLot"].ToString();
                            Mode.Text = rdr["Mode"].ToString();
                            RefArreteWali.Text = rdr["RefArreteWali"].ToString();
                            DateArreteWali.Text = rdr["DateArreteWali"].ToString();
                            Acte.Text = rdr["Acte"].ToString();
                            DateActe.Text = rdr["DateActe"].ToString();
                            Projet.Text = rdr["Projet"].ToString();
                            Observation.Text = rdr["Observation"].ToString();
                          
                        }



                    }
                    con.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
        }

        

        private void BtnAjtAtt_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string idinvest = sh.GetUntilOrEmpty(InputIdInvestisseur.SelectedItem.ToString(), "-");
            AttributionController AC = new AttributionController();
            IdAttribution.IsEnabled = false; 
            AC.AjouterAttribution(int.Parse(InputIdLot.Text),int.Parse(idinvest),/*int.Parse(InputIdZone.Text)*/Mode.Text, int.Parse(RefArreteWali.Text), DateArreteWali.Text, Acte.Text, DateActe.Text, Projet.Text, Observation.Text);

            ListAttributions LA = new ListAttributions();
            this.NavigationService.Navigate(LA);

        }
        private void BtnModAtt_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string idinvest = sh.GetUntilOrEmpty(InputIdInvestisseur.SelectedItem.ToString(), "-");
            AttributionController AC = new AttributionController();
            IdAttribution.IsEnabled = false;
            AC.ModifierAttribution(int.Parse(IdAttribution.Text),int.Parse(InputIdLot.Text), int.Parse(idinvest),/*int.Parse(InputIdZone.Text)*/ Mode.Text, int.Parse(RefArreteWali.Text), DateArreteWali.Text, Acte.Text, DateActe.Text, Projet.Text, Observation.Text);

            
            ListAttributions LA = new ListAttributions();
            this.NavigationService.Navigate(LA);

        }

        private void BtnSuppAtt_Click(object sender, RoutedEventArgs e)
        {
           
        }


        



        private void IdZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           // InputNumLot.Items.Clear();

            
           sqlhelper sh = new sqlhelper();
           string idzone = sh.GetUntilOrEmpty(IdZone.SelectedItem.ToString(),"-");
            //   MessageBox.Show(idzone);
            InputNumLot.Items.Clear();
            sh.loadfilldata("select NumLot from lot where lot.IdZone='" + idzone + "'", InputNumLot,"NumLot");
 
        }

        
 
        private void InputIdInvestisseur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
           // sh.loadfilldata2("select RaisonSociale from investisseur where IdInvestisseur=" + InputIdInvestisseur.SelectedItem + "", InputRaisonSociale, "RaisonSociale");
              } 

       
    
       

       

        private void InputNumLot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string idzone = sh.GetUntilOrEmpty(IdZone.SelectedItem.ToString(), "-");
            InputIdLot.Text =  sh.getdata("select IdLot from lot where NumLot='" + InputNumLot.SelectedValue.ToString() + "' and lot.IdZone='"+idzone+"'", "IdLot");
            InputIdLot.IsEnabled = false;
        }
    }
}
