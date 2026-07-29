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
using WpfApplication2.Views.Lots;
using WpfApplication2.Controlers;

namespace WpfApplication2.Views.Lots
{
    /// <summary>
    /// Interaction logic for ListLots.xaml
    /// </summary>
    public partial class ListLots : Page
    {
        bool IsAscending = true;
        int tempid3 = 0;
        public ListLots()
        {
            InitializeComponent();

            sqlhelper sh = new sqlhelper();
            string qrt = @"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot
               INNER JOIN 
        zone ON lot.IdZone= zone.IdZone";
            sh.loaddata(qrt, DataGridLot);
            
            
                   
        }

        private void AjtListLots_Click(object sender, RoutedEventArgs e)
        {
            AddLots al = new AddLots(0);
             
            this.NavigationService.Navigate(al);
        }

      
        private void DataGridLot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = DataGridLot.SelectedCells[0];
                tempid3 = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);
            }
            catch (Exception)
            {
            }
        }

        private void SuppListLots_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (tempid3 == 0)
                {
                    MessageBox.Show("Veuillez Sélectionner une ligne à supprimer");
                }
                else
                {
                    LotController Lc = new LotController();
                    Lc.SupprimerLot(tempid3);
                    sqlhelper sh = new sqlhelper();
                    string qrt = @"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot
               INNER JOIN 
        zone ON lot.IdZone= zone.IdZone";
                    sh.loaddata(qrt, DataGridLot);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void ModListLots_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (tempid3 == 0)
                {
                    MessageBox.Show("Veuillez Sélectionner une ligne à modifier");
                }
                else
                {
                    AddLots AL = new AddLots(tempid3);
                    this.NavigationService.Navigate(AL);
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
            string SortOrder = IsAscending ? "ASC" : "DESC";
           switch (SwitchRecherche1.SelectedIndex)
            {
                case 0:
                    string qrt = $@"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot
                     INNER JOIN zone on lot.IdZone=zone.IdZone
                     ORDER BY NomDeZone {SortOrder}";
                    sh.loaddata(qrt, DataGridLot);
                    IsAscending = !IsAscending; 

                    break;
                case 1:
                    string qrt1 = $@"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot
                                  INNER JOIN zone on lot.IdZone=zone.IdZone
                                  ORDER BY NomDaira {SortOrder}";
                    sh.loaddata(qrt1, DataGridLot);
                    IsAscending = !IsAscending;
                    break;
                case 2:
                    string qrt2 = $@"select IdLot,NomDeZone,NomCommune,NumLot,Ilot,Surface from lot
                                 INNER JOIN zone on lot.IdZone=zone.IdZone
                                 ORDER BY NomCommune {SortOrder}";
                    sh.loaddata(qrt2, DataGridLot);
                    IsAscending = !IsAscending;
                    break;
                case 3:
                    string qrt3 = $@"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,ILot,Surface from lot
                                INNER JOIN zone on lot.IdZone=zone.IdZone
                                ORDER BY NumLot {SortOrder}";
                    sh.loaddata(qrt3, DataGridLot);
                    IsAscending = !IsAscending;
                    break;
            }
        }

        private void Actualiser_Click(object sender, RoutedEventArgs e)
        {
            sqlhelper sh = new sqlhelper();
            string qrt = @"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot
               INNER JOIN 
               zone ON lot.IdZone= zone.IdZone";
            sh.loaddata(qrt, DataGridLot);
        }

        private void InputRecherche_KeyUp(object sender, KeyEventArgs e)
        {
          string  userInput = InputRecherche.Text;
            sqlhelper sh = new sqlhelper();
            switch (SwitchRecherche.SelectedIndex)
            {
                case 0:
                    
                    string sqrt = @"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot        
                                  INNER JOIN zone on lot.IdZone=zone.IdZone
                                  where NomDeZone like '%" + userInput + "%'";
                    sh.loaddata(sqrt, DataGridLot);


                    break;

                case 1:
                    string sqrt1 = @"select Idlot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot
                                   INNER JOIN zone on lot.IdZone = zone.IdZone
                                   where NomDaira like '%" + userInput + "%'";
                    sh.loaddata(sqrt1, DataGridLot);
                    break;

                case 2:
                    string sqrt2 = @"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot
                                    INNER JOIN zone on lot.IdZone = zone.IdZone
                                     where NomCommune like '%" + userInput + "%'";
                    sh.loaddata(sqrt2, DataGridLot);
                    break;
                case 3:
                    string sqrt3 = @"select IdLot,NomDeZone,NomDaira,NomCommune,NumLot,Ilot,Surface from lot
                                  INNER JOIN zone on lot.IdZone = zone.IdZone
                                  where NumLot like '%" + userInput + "%'";
                    sh.loaddata(sqrt3, DataGridLot);
                    break;





            }




        }

        private void FILTRE_Click(object sender, RoutedEventArgs e)
        {

        }
    }
        }
    

