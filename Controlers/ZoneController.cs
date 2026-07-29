using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace WpfApplication2.Controlers
{
    
    class ZoneController
    {

        sqlhelper sh = new sqlhelper();
        public void AjouterZone(string NomDeZone, string NomDaira, string NomCommune, string proprietaire, int NumeroActe, int VolActe, string DateActe, int NumPL, string DatePL, int NumCC, int VolCC, string DateCC, double SurfaceBrute, double SurfaceCessible, int NombredesLots)
        {
            try
            {
                sh.ExecuteQuery
          ("INSERT INTO `zone` (NomDeZone,NomDaira,NomCommune,proprietaire, NumeroActe, VolActe, DateActe, NumPL, DatePL, NumCC, VolCC, DateCC, SurfaceBrute, SurfaceCessible, NombredesLots) VALUES  ('" + NomDeZone + "','"+NomDaira+"','"+NomCommune+"','"+proprietaire+ "','"+NumeroActe+ "','"+VolActe+ "',STR_TO_DATE('" + DateActe + "','%m/%d/%Y'),'" + NumPL + "',STR_TO_DATE('" + DatePL + "','%m/%d/%Y' ),'" + NumCC +"' , '"+ VolCC + "', STR_TO_DATE('" + DateCC + "','%m/%d/%Y'), '" + SurfaceBrute + "', '"+ SurfaceCessible + "', '"+ NombredesLots + "') ");
                MessageBox.Show("La zone a été bien ajoutée");
                
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ModifierZone(int id,string NomDeZone, string NomDaira, string NomCommune, string proprietaire, int NumeroActe, string VolActe, string DateActe, int NumPL, string DatePL, int NumCC, int VolCC, string DateCC, double SurfaceBrute, double SurfaceCessible, int NombredesLots)
        {
            try
            {
                sh.ExecuteQuery("UPDATE zone SET NomDeZone='" + NomDeZone + "',NomDaira='"+ NomDaira + "', NomCommune='"+ NomCommune + "', proprietaire='" + proprietaire + "', NumeroActe='"+NumeroActe+ "', VolActe='"+VolActe+ "',DateActe=STR_TO_DATE('" + DateActe+ "','%m/%d/%Y' ), NumPL='" + NumPL+ "', DatePL=STR_TO_DATE('"+DatePL+ "','%m/%d/%Y'),NumCC='" + NumCC+"', VolCC='"+VolCC+ "', DateCC=STR_TO_DATE('"+DateCC+ "','%m/%d/%Y'), SurfaceBrute='" + SurfaceBrute + "', SurfaceCessible='"+ SurfaceCessible + "', NombredesLots='" + NombredesLots + "'  where IdZone=+" + id + "");
            //    Clipboard.SetText("UPDATE zone SET NomDeZone='" + NomDeZone + "',NomDaira='" + NomDaira + "', NomCommune='" + NomCommune + "', proprietaire='" + proprietaire + "', NumeroActe='" + NumeroActe + "', VolActe='" + VolActe + "',DateActe=STR_TO_DATE('" + DateActe + "','%m/%d/%Y' ), NumPL='" + NumPL + "', DatePL=STR_TO_DATE('" + DatePL + "','%m/%d/%Y'),NumCC='" + NumCC + "', VolCC='" + VolCC + "', DateCC=STR_TO_DATE('" + DateCC + "','%m/%d/%Y'), SurfaceBrute='" + SurfaceBrute + "', SurfaceCessible='" + SurfaceCessible + "', NombredesLots='" + NombredesLots + "'  where IdZone=+" + id + "");
                MessageBox.Show("La zone a été bien modifiée");
                
                    }

            catch (Exception)
            {
                MessageBox.Show("La zone n'a pas été correctement modifiée");

            }
        }

      
        public void SupprimerZone(int IdZone)
        {
            var bouton = MessageBox.Show("La suppression de cette zone entraînera également la suppression de toutes les lignes du lots associées. Souhaitez-vous continuer ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
        
                try
            {
                if (bouton == MessageBoxResult.Yes)
                {
                    sh.ExecuteQuery("delete from zone where IdZone='" + IdZone + "'");
                    MessageBox.Show("La zone a été bien supprimée");
              

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
