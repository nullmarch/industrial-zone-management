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
using WpfApplication2.Views.Investisseurs;
using WpfApplication2.Controlers;


namespace WpfApplication2.Views.Investisseurs
{
    /// <summary>
    /// Interaction logic for ListInvestisseurs.xaml
    /// </summary>
    public partial class ListInvestisseurs : Page
    {
        int tempid1 = 0;
        public ListInvestisseurs()
        {
            InitializeComponent();

            sqlhelper sh = new sqlhelper();
            sh.loaddata("select IdInvestisseur,RaisonSociale,NomSociete,Statut,NumRC,DATE_FORMAT(DateRC,'%d/%m/%Y') AS DateRC,NIF,NIS,NomGerant,DATE_FORMAT(DateNaissance,'%d/%m/%Y') AS DateNaissance,NumCNI,DATE_FORMAT(DateCNI,'%d/%m/%Y') AS DateCNI,Adresse,NumTel,NumMob,NumFax,Email from investisseur", DataGridInvestisseur);
           


        }

        public object dataGrid { get; private set; }

        private void AjtListInv_Click(object sender, RoutedEventArgs e)
        {
            AddInvestisseurs ai = new AddInvestisseurs(0);
            this.NavigationService.Navigate(ai);
        }

        private void DataGridInvestisseur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = DataGridInvestisseur.SelectedCells[0];
                tempid1 = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ModListInv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tempid1 == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne à Modifer");
                }
                else
                {
                    AddInvestisseurs ai = new AddInvestisseurs(tempid1);
                    this.NavigationService.Navigate(ai);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

     

        private void SupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tempid1 == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne à Supprimer");
                }
                else
                {
                    InvestisseurController IC = new InvestisseurController();
                    IC.SupprimerInvestisseur(tempid1);

                    sqlhelper sh = new sqlhelper();
                    sh.loaddata("select IdInvestisseur,RaisonSociale,NomSociete,Statut,NumRC,DATE_FORMAT(DateRC,'%d/%m/%Y') AS DateRC,NIF,NIS,NomGerant,DATE_FORMAT(DateNaissance,'%d/%m/%Y') AS DateNaissance,NumCNI,DATE_FORMAT(DateCNI,'%d/%m/%Y') AS DateCNI,Adresse,NumTel,NumMob,NumFax,Email from investisseur", DataGridInvestisseur);


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void Ordre_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Actualiser_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            sh.loaddata("select IdInvestisseur,RaisonSociale,NomSociete,Statut,NumRC,DATE_FORMAT(DateRC,'%d/%m/%Y') AS DateRC,NIF,NIS,NomGerant,DATE_FORMAT(DateNaissance,'%d/%m/%Y') AS DateNaissance,NumCNI,DATE_FORMAT(DateCNI,'%d/%m/%Y') AS DateCNI,Adresse,NumTel,NumMob,NumFax,Email from investisseur", DataGridInvestisseur);

        }

        private void FILTRER_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            switch (SwitchRecherche2.SelectedIndex)
            {
                case 0:
                    
                    string query = @"
        SELECT 
            i.IdInvestisseur,
            i.RaisonSociale,
            i.NomSociete,
            i.Statut,
            i.NumRC,
            DATE_FORMAT(i.DateRC,'%d/%m/%Y') AS DateRC,
            i.NIF,
            i.NIS,
            i.NomGerant,
            DATE_FORMAT(i.DateNaissance,'%d/%m/%Y') AS DateNaissance,
            i.NumCNI,
            DATE_FORMAT(i.DateCNI,'%d/%m/%Y') AS DateCNI,
            i.Adresse,
            i.NumTel,
            i.NumMob,
            i.NumFax,
            i.Email,
            COUNT(a.IdLot) AS TotalLots
        FROM 
            investisseur i
        LEFT JOIN 
            attribution a ON i.IdInvestisseur = a.IdInvestisseur
        GROUP BY 
            i.IdInvestisseur, 
            i.RaisonSociale,
            i.NomSociete,
            i.Statut,
            i.NumRC,
            i.DateRC,
            i.NIF,
            i.NIS,
            i.NomGerant,
            i.DateNaissance,
            i.NumCNI,
            i.DateCNI,
            i.Adresse,
            i.NumTel,
            i.NumMob,
            i.NumFax,
            i.Email;";
                    sh.loaddata(query, DataGridInvestisseur);
                    break;

                case 1:
                    string query1 = @"
        SELECT 
            i.IdInvestisseur,
            i.RaisonSociale,
            i.NomSociete,
            i.Statut,
            i.NumRC,
            DATE_FORMAT(i.DateRC,'%d/%m/%Y') AS DateRC,
            i.NIF,
            i.NIS,
            i.NomGerant,
            DATE_FORMAT(i.DateNaissance,'%d/%m/%Y') AS DateNaissance,
            i.NumCNI,
            DATE_FORMAT(i.DateCNI,'%d/%m/%Y') AS DateCNI,
            i.Adresse,
            i.NumTel,
            i.NumMob,
            i.NumFax,
            i.Email,
            COUNT(Projet) AS NombredePrjet
        FROM 
            investisseur i
        LEFT JOIN 
            attribution a ON i.IdInvestisseur = a.IdInvestisseur
        GROUP BY 
            i.IdInvestisseur, 
            i.RaisonSociale,
            i.NomSociete,
            i.Statut,
            i.NumRC,
            i.DateRC,
            i.NIF,
            i.NIS,
            i.NomGerant,
            i.DateNaissance,
            i.NumCNI,
            i.DateCNI,
            i.Adresse,
            i.NumTel,
            i.NumMob,
            i.NumFax,
            i.Email
        ORDER BY 
            NombredePrjet DESC
        
    ";
                    sh.loaddata(query1, DataGridInvestisseur);
                    break;

            }          
            
        }

    }
}

