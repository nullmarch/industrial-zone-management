using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication2.Controlers
{

    class LotController
    {

        sqlhelper sh = new sqlhelper();
        public void AjouterLot(int IdZone, int NumLot ,int Ilot, double Surface)
        {
            try
            {
                // '" + NumeroActe + "', STR_TO_DATE('" + DateActe + "','%m/%d/%Y'),STR_TO_DATE('" + DateArrete + "','%m/%d/%Y')
                sh.ExecuteQuery("INSERT INTO `lot` (IdZone,NumLot,Ilot,Surface) VALUES  ('" + IdZone + "','" + NumLot + "','" + Ilot + "','" + Surface + "') ");
                MessageBox.Show("Le Lot a été bien ajouté ");
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ModifierLot(int id, int IdZone, int NumLot,/* string NumeroActe, string DateActe, string DateArrete,*/ int Ilot, double Surface)
        {
            try
            {
                //,NumeroActe='" + NumeroActe + "', DateActe=STR_TO_DATE('" + DateActe + "','%m/%d/%Y'), DateArrete=STR_TO_DATE('" + DateArrete + "','%m/%d/%Y')
                sh.ExecuteQuery("UPDATE lot SET IdZone='" + IdZone + "',NumLot='" + NumLot + "', Ilot='" + Ilot + "', Surface='" + Surface + "' where IdLot=+" + id + " ");
                MessageBox.Show("Le Lot a été bien modifié");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void SupprimerLot(int IdLot )

        {
            var bouton = MessageBox.Show("Voulez-vous supprimer ce lot ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {
                if (bouton == MessageBoxResult.Yes)
                {
                    sh.ExecuteQuery("delete from lot where IdLot ='" + IdLot + "'");
                    MessageBox.Show("Le lot a été bien supprimé");
                }
                else if (bouton == MessageBoxResult.No)
                {
                   
                }




            }

            catch (Exception)
            {


            }






        }








    }

    }
    

