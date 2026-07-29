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
using WpfApplication2.Views.Investisseurs;
using MySql.Data.MySqlClient;

namespace WpfApplication2.Views.Investisseurs
{
    /// <summary>
    /// Interaction logic for AddInvestisseurs.xaml
    /// </summary>
    public partial class AddInvestisseurs : Page
    {
        int id = 0;
        public AddInvestisseurs(int id)
        {
            InitializeComponent();
            this.id = id;

            sqlhelper sh = new sqlhelper();

       //    MessageBox.Show(id.ToString());

            if (id != 0)
                try
                {

                    string query = "select * from investisseur where IdInvestisseur="+ id +"";
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
                            IdInvestisseur.Text = rdr["IdInvestisseur"].ToString();
                            RaisonSociale.Text = rdr["RaisonSociale"].ToString();
                            NomSciete.Text = rdr["NomSociete"].ToString();
                            Statut.Text = rdr["Statut"].ToString();
                            NumRC.Text = rdr["NumRC"].ToString();
                            DateRC.Text = rdr["DateRC"].ToString();
                            NIF.Text = rdr["NIF"].ToString();
                            NIS.Text = rdr["NIS"].ToString();
                            NomGerant.Text = rdr["NomGerant"].ToString();
                            DateNaissance.Text = rdr["DateNaissance"].ToString();
                            NumCNI.Text = rdr["NumCNI"].ToString();
                            DateCNI.Text = rdr["DateCNI"].ToString();
                            Adresse.Text = rdr["Adresse"].ToString();
                            NumTel.Text = rdr["NumTel"].ToString();
                            NumMob.Text = rdr["NumMob"].ToString();
                            NumFax.Text = rdr["NumFax"].ToString();
                            Email.Text = rdr["Email"].ToString();
                        }



                    }
                    con.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
        }

      

        private void BtnAjtInv_Click(object sender, RoutedEventArgs e)
        {
            InvestisseurController IC = new InvestisseurController();
            IC.AjouterInvestisseur(RaisonSociale.Text, NomSciete.Text, Statut.Text, int.Parse(NumRC.Text), DateRC.Text, int.Parse(NIF.Text), int.Parse(NIS.Text), NomGerant.Text, DateNaissance.Text, int.Parse(NumCNI.Text), DateCNI.Text, Adresse.Text, int.Parse(NumTel.Text), int.Parse( NumMob.Text),int.Parse(NumFax.Text), Email.Text);

            ListInvestisseurs LI = new ListInvestisseurs();
            this.NavigationService.Navigate(LI);
            

        }

        private void BtnModInv_Click(object sender, RoutedEventArgs e)
        {
            InvestisseurController IC = new InvestisseurController();
            IC.ModifierInvestissuer(int.Parse(IdInvestisseur.Text), RaisonSociale.Text, NomSciete.Text, Statut.Text, int.Parse(NumRC.Text), DateRC.Text, int.Parse(NIF.Text), int.Parse(NIS.Text), NomGerant.Text, DateNaissance.Text, int.Parse(NumCNI.Text), DateCNI.Text, Adresse.Text, int.Parse(NumTel.Text), int.Parse(NumMob.Text), int.Parse(NumFax.Text), Email.Text);

            ListInvestisseurs LI = new ListInvestisseurs();
            this.NavigationService.Navigate(LI);

        }

        private void BtnSuppInv_Click(object sender, RoutedEventArgs e)
        {
            InvestisseurController IC = new InvestisseurController();
            IC.SupprimerInvestisseur (int.Parse(IdInvestisseur.Text));

        }
    }


    }
