using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication2.Controlers
{
    class AttributionController
    {

        sqlhelper sh = new sqlhelper();
        public void AjouterAttribution(int IdLot, int IdInvestisseur ,string Mode, int RefArreteWali,string DateArreteWali, string Acte, string DateActe, string Projet, string Observation)
        {
            try
            {
                sh.ExecuteQuery("INSERT INTO `attribution` (IdLot,IdInvestisseur,Mode,RefArreteWali,DateArreteWali,Acte,DateActe,Projet,Observation) VALUES ('" + IdLot+"','" + IdInvestisseur + "','" + Mode + "','" + RefArreteWali + "' ,STR_TO_DATE('" + DateArreteWali + "','%m/%d/%Y'),'" + Acte + "' ,STR_TO_DATE('" + DateActe + "', '%m/%d/%Y'),'" + Projet + "' ,'" + Observation + "') ");
                MessageBox.Show("L'attribution a été bien ajouté");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ModifierAttribution(/*int NumLot*/int id,int IdLot, int IdInvestisseur, string Mode, int RefArreteWali, string DateArreteWali, string Acte, string DateActe, string Projet, string Observation)
        {
            try
            {
                sh.ExecuteQuery("UPDATE attribution SET IdLot='"+IdLot+"',IdInvestisseur='"+ IdInvestisseur + "',Mode='" + Mode+ "',RefArreteWali='"+ RefArreteWali + "',DateArreteWali=STR_TO_DATE('" + DateArreteWali + "','%m/%d/%Y'),Acte='"+ Acte + "',DateActe=STR_TO_DATE('" + DateActe + "','%m/%d/%Y'), Projet='" + Projet + "',Observation='" + Observation + "' Where IdAttribution=+ " +id+ "");
                MessageBox.Show("L'attribution a été bien Modifié");

            }
             
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void SupprimerAttribution(int IdAttribution)

        {
            var bouton = MessageBox.Show("Voulez-vous supprimer cette attribution ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {

                if (bouton == MessageBoxResult.Yes)
                {
                    sh.ExecuteQuery("delete from attribution where 	IdAttribution='" + IdAttribution + "'");
                    MessageBox.Show("Les attributions ont été supprimées");
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

