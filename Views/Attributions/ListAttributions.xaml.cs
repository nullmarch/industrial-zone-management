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
using WpfApplication2.Views.Attributions;



namespace WpfApplication2.Views.Attributions
{
    /// <summary>
    /// Interaction logic for ListAttributions.xaml
    /// </summary>
    public partial class ListAttributions : Page
    {
        int tempid2 = 0;
        bool IsAscending = true;
        public ListAttributions()
        {
            InitializeComponent();
           
            sqlhelper sh = new sqlhelper();
            sh.loaddata(@" SELECT IdAttribution,RaisonSociale,NumLot,Mode,RefArreteWali,DATE_FORMAT(DateArreteWali,'%d/%m/%Y') AS DateArreteWali,Acte,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe,Projet,Observation FROM attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot", DataGirdAttribution);

        }

        private void AjtListAttr_Click(object sender, RoutedEventArgs e)
        {
            AddAttributions ad = new AddAttributions(0);
            //  ad.InputNomDeZone.IsEnabled = false;
            this.NavigationService.Navigate(ad);
        }

        private void DataGirdAttribution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = DataGirdAttribution.SelectedCells[0];
                tempid2 = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void ModLisAtt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tempid2 == 0)
                {
                    MessageBox.Show("Veuillez Sélectionner une Ligne à Modifier!");
                }
                else
                {

                    AddAttributions aa = new AddAttributions(tempid2);
                    this.NavigationService.Navigate(aa);

                    aa.BtnAjtAtt.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SuppLisAttr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tempid2 == 0)
                {
                    MessageBox.Show("Veuillez Sélectionner une Ligne à Supprimer!");
                }

                else
                {
                    AttributionController AC = new AttributionController();
                    AC.SupprimerAttribution(tempid2);

                    sqlhelper sh = new sqlhelper();
                    string qrt = @" SELECT IdAttribution,NomGerant,RaisonSociale,NumLot,Mode,RefArreteWali,DATE_FORMAT(DateArreteWali, '%d/%m/%Y') AS DateArreteWali,Acte,DATE_FORMAT(DateActe, '%d/%m/%Y') AS DateActe,Projet,Observation FROM attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot";
                    sh.loaddata(qrt, DataGirdAttribution);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Ordre_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string sortOrder = IsAscending ? "ASC" : "DESC";

            switch (SwitchRecherche1.SelectedIndex)
            {

                case 0:


                    sh.loaddata($@" SELECT IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DATE_FORMAT(DateArreteWali, '%d/%m/%Y') AS DateArreteWali,Acte,DATE_FORMAT(DateActe, '%d/%m/%Y') AS DateActe,Projet,Observation FROM attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot
             ORDER BY RaisonSociale {sortOrder}", DataGirdAttribution);
                    IsAscending = !IsAscending;


                    break;

                case 1:
                    sh.loaddata($@" SELECT IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DATE_FORMAT(DateArreteWali, '%d/%m/%Y') AS DateArreteWali,Acte,DATE_FORMAT(DateActe, '%d/%m/%Y') AS DateActe,Projet,Observation FROM attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot
             ORDER BY NumLot {sortOrder}", DataGirdAttribution);
                    IsAscending = !IsAscending;

                    break;

                case 2:
                    sh.loaddata($@" SELECT IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,	RefArreteWali,DATE_FORMAT(DateArreteWali, '%d/%m/%Y') AS DateArreteWali,Acte,DATE_FORMAT(DateActe, '%d/%m/%Y') AS DateActe,Projet,Observation FROM attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot
             ORDER BY Acte {sortOrder}", DataGirdAttribution);
                    IsAscending = !IsAscending;
                    break;

                case 3:
                    sh.loaddata($@" SELECT IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DATE_FORMAT(DateArreteWali, '%d/%m/%Y') AS DateArreteWali,Acte,DATE_FORMAT(DateActe, '%d/%m/%Y') AS DateActe,Projet,Observation FROM attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot
             ORDER BY Projet {sortOrder}", DataGirdAttribution);
                    IsAscending = !IsAscending;
                    break;

                case 4:
                    sh.loaddata($@" SELECT IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DATE_FORMAT(DateArreteWali, '%d/%m/%Y') AS DateArreteWali,Acte,DATE_FORMAT(DateActe, '%d/%m/%Y') AS DateActe,Projet,Observation FROM attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot
             ORDER BY Observation {sortOrder}", DataGirdAttribution);
                    IsAscending = !IsAscending;

                    break;




            }








        }

        private void Actualiser_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string qrt = @" SELECT IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DATE_FORMAT(DateArreteWali, '%d/%m/%Y') AS DateArreteWali,Acte,DATE_FORMAT(DateActe, '%d/%m/%Y') AS DateActe,Projet,Observation FROM attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot";
            sh.loaddata(qrt, DataGirdAttribution);
        }





        private void InputRecherche_KeyUp(object sender, KeyEventArgs e)
        {

            sqlhelper sh = new sqlhelper();
            String UserInput = InputRecherche.Text;

            switch (SwitchRecherche.SelectedIndex)
            {
                case 0:

                    sh.loaddata(@"select IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DateArreteWali,Acte,DateActe,Projet,Observation from attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN
        lot ON attribution.IdLot = lot.IdLot  where RaisonSociale Like '%" + UserInput + "%'", DataGirdAttribution);
                    break;

                case 1:
                    sh.loaddata(@"select IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DateArreteWali,Acte,DateActe,Projet,Observation from attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN
        lot ON attribution.IdLot = lot.IdLot  where NumLot Like '%" + UserInput + "%'", DataGirdAttribution);
                    break;

                case 2:

                    sh.loaddata(@"select IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DateArreteWali,Acte,DateActe,Projet,Observation from attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN
        lot ON attribution.IdLot = lot.IdLot  where Acte Like '%" + UserInput + "%'", DataGirdAttribution);
                    break;
                case 3:

                    sh.loaddata(@"select IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DateArreteWali,Acte,DateActe,Projet,Observation from attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN
        lot ON attribution.IdLot = lot.IdLot  where Projet Like '%" + UserInput + "%'", DataGirdAttribution);
                    break;

                case 4:

                    sh.loaddata(@"select IdAttribution,RaisonSociale,NomGerant,NumLot,Mode,RefArreteWali,DateArreteWali,Acte,DateActe,Projet,Observation from attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN
        lot ON attribution.IdLot = lot.IdLot  where Observation Like '%" + UserInput + "%'", DataGirdAttribution);
                    break;
            }









        }

        private void Filtre_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();

            switch (SwitchRecherche2.SelectedIndex)
            {
                case 0:
                    string sqrt = @"
    SELECT 
        attribution.IdAttribution,
        investisseur.RaisonSociale,
        investisseur.NomGerant,
        lot.NumLot,
        attribution.Mode,
        attribution.RefArreteWali,
        DATE_FORMAT(attribution.DateArreteWali, '%d/%m/%Y') AS DateArreteWali,
        attribution.Acte,
        DATE_FORMAT(attribution.DateActe, '%d/%m/%Y') AS DateActe,
        attribution.Projet,
        attribution.Observation,
        COUNT(Projet) AS NombredePrjet
    FROM 
        attribution
    INNER JOIN 
        investisseur ON attribution.IdInvestisseur = investisseur.IdInvestisseur
    INNER JOIN 
        lot ON attribution.IdLot = lot.IdLot
    GROUP BY 
        attribution.IdAttribution, 
        investisseur.RaisonSociale,
        investisseur.NomGerant, 
        lot.NumLot, 
        attribution.Mode,
        attribution.RefArreteWali,
        attribution.DateArreteWali,
        attribution.Acte,
        attribution.DateActe,
        attribution.Projet,
        attribution.Observation
    ORDER BY 
       NombredePrjet ASC;
    ";


                    sh.loaddata(sqrt, DataGirdAttribution);
                    break;
            }

        }
    }
}
    
    

