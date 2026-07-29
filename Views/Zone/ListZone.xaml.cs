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
using WpfApplication2.Views.Zone;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using WpfApplication2.Controlers;


namespace WpfApplication2.Views.Zone

{
    /// <summary>
    /// Interaction logic for ListZone.xaml
    /// </summary>
    public partial class ListZone : Page
    {
        bool IsAscending = true;
        int tempid = 0;
        public ListZone()
        {
            InitializeComponent();

            sqlhelper sh = new sqlhelper();
            string qrt = "select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots from zone";
            sh.loaddata(qrt, DataGridZone);

        }

        public object dataGrid { get; private set; }

     


        private void Button_Ajouter(object sender, RoutedEventArgs e)
        {
            AddZone al = new AddZone(0);
            this.NavigationService.Navigate(al);
        }

        private void ModZone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tempid == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne à Modifier");
                }
                else
                {
                    AddZone al = new AddZone(tempid);
                    al.IdZone.IsEnabled = al.NomDeZone.IsEnabled = al.InputDaira.IsEnabled = false;
                    this.NavigationService.Navigate(al);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DataGridZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = DataGridZone.SelectedCells[0];
                tempid = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);
            }
            catch (Exception)
            {
            }

        }

        private void SuppZone_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (tempid == 0)
                {
                    MessageBox.Show("Veuillez Sélectionner une ligne à supprimer");
                }
                else
                {
                    ZoneController ZC = new ZoneController();
                    ZC.SupprimerZone(tempid);
                    sqlhelper sh = new sqlhelper();
                    string qrt = "select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots from zone";
                    sh.loaddata(qrt, DataGridZone);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }






        private void Actualiser_Click_(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string qrt = "select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots from zone";
            sh.loaddata(qrt, DataGridZone);
        }

        private void Ordre_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string sortOrder = IsAscending ? "ASC" : "DESC";

            switch (SwitchRecherche1.SelectedIndex)
            {

                case 0:

                    sh.loaddata($@" select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots from zone
             ORDER BY NomDeZone {sortOrder}", DataGridZone);
                    IsAscending = !IsAscending;

                    break;

                case 1:

                    sh.loaddata($@" select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots from zone
             ORDER BY NomDaira {sortOrder}", DataGridZone);
                    IsAscending = !IsAscending;

                    break;

                case 2:

                    sh.loaddata($@" select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots from zone
             ORDER BY NomCommune {sortOrder}", DataGridZone);
                    IsAscending = !IsAscending;

                    break;

                case 3:

                    sh.loaddata($@" select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots from zone
             ORDER BY NombredesLots {sortOrder}", DataGridZone);
                    IsAscending = !IsAscending;

                    break;


            }
        }

        private void InputRecherche_KeyUp(object sender, KeyEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            String UserInput = InputRecherche.Text;

            switch (SwitchRecherche.SelectedIndex)
            {
                case 0:
                    
                    sh.loaddata(@"select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots from zone
                    
                    where NomDeZone like '%" + UserInput + "%'" , DataGridZone);
                    break;
                case 1:
                    sh.loaddata(@"select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots
                                  from zone where NomDaira like '%" + UserInput + "%'", DataGridZone);
                    break;
                case 2:
                    sh.loaddata(@"select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots
                                  from zone where NomCommune like '%" + UserInput + "%'", DataGridZone);
                    break;
                case 3:
                    sh.loaddata(@"select IdZone ,NomDeZone,NomDaira,NomCommune,Proprietaire,NumeroActe,VolActe,DATE_FORMAT(DateActe,'%d/%m/%Y') AS DateActe ,NumPL,DATE_FORMAT(DatePL,'%d/%m/%Y') AS DatePL ,NumCC,VolCC,DATE_FORMAT(DateCC,'%d/%m/%Y') AS DateCC ,SurfaceBrute,SurfaceCessible,NombredesLots
                                  from zone where NombredesLots like '%" + UserInput + "%'", DataGridZone);
                    break;
            }
        }

       

        private void FILTRE_Click(object sender, RoutedEventArgs e)
        {
            
            switch (SwitchRecherche2.SelectedIndex)
            {
                case 0:
                 sqlhelper sh = new sqlhelper();
            string qrt = @"
        SELECT 
            z.IdZone,
            z.NomDeZone,
            z.NomDaira,
            z.NomCommune,
            z.Proprietaire,
            z.NumeroActe,
            z.VolActe,
            DATE_FORMAT(z.DateActe, '%d/%m/%Y') AS DateActe,
            z.NumPL,
            DATE_FORMAT(z.DatePL, '%d/%m/%Y') AS DatePL,
            z.NumCC,
            z.VolCC,
            DATE_FORMAT(z.DateCC, '%d/%m/%Y') AS DateCC,
            z.SurfaceBrute,
            z.SurfaceCessible,
            z.NombredesLots,
            COUNT(l.IdLot) AS TotalLots
        FROM 
            zone z
        LEFT JOIN 
            lot l ON z.IdZone = l.IdZone
        GROUP BY 
            z.IdZone, 
            z.NomDeZone,
            z.NomDaira,
            z.NomCommune,
            z.Proprietaire,
            z.NumeroActe,
            z.VolActe,
            z.DateActe,
            z.NumPL,
            z.DatePL,
            z.NumCC,
            z.VolCC,
            z.DateCC,
            z.SurfaceBrute,
            z.SurfaceCessible,
            z.NombredesLots
        ORDER BY 
            TotalLots DESC;
    ";
            sh.loaddata(qrt, DataGridZone);
                    break;

                case 1:
                    sqlhelper sh1 = new sqlhelper();
                    string qrt1 = @"
        SELECT 
            z.IdZone,
            z.NomDeZone,
            COUNT(l.IdLot) AS LotCount
        FROM 
            zone z
        LEFT JOIN 
            lot l ON z.IdZone = l.IdZone
        GROUP BY 
            z.IdZone, z.NomDeZone
        ORDER BY 
            LotCount DESC
        LIMIT 1;  
    ";
                    sh1.loaddata(qrt1, DataGridZone);
                    break;



        }
             
        }

        private void btnloaddata_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

