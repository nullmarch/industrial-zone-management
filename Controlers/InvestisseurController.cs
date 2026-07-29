using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace WpfApplication2.Controlers
{
    class InvestisseurController
    {

        sqlhelper sh = new sqlhelper();
        public void AjouterInvestisseur(string RaisonSociale, string NomSociete, string Statut, int NumRC, string DateRC, int NIF, int NIS, string NomGerant, string DateNaissance, int NumCNI, string DateCNI, string Adresse, int NumTel, int NumMob, int NumFax, string Email)
        {
            try
            {
                sh.ExecuteQuery("INSERT INTO `investisseur` (RaisonSociale,NomSociete,Statut,NumRC,DateRC,NIF,NIS,NomGerant,DateNaissance,NumCNI,DateCNI,Adresse,NumTel,NumMob,NumFax,Email) VALUES  ('" + RaisonSociale + "','" + NomSociete + "','" + Statut + "' ,'"+ NumRC + "',STR_TO_DATE('" + DateRC + "','%m/%d/%Y'),'" + NIF + "','"+ NIS + "','"+NomGerant+"',STR_TO_DATE('" + DateNaissance + "','%m/%d/%Y'),'" + NumCNI + "' , STR_TO_DATE('" + DateCNI + "','%m/%d/%Y'),  '" + Adresse + "','"+ NumTel + "','"+ NumMob + "','"+ NumFax + "','" + Email + "') ");
                MessageBox.Show("L'investisseur a été bien ajouté");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ModifierInvestissuer(int id, string RaisonSociale, string NomSociete, string Statut, int NumRC, string DateRC, int NIF, int NIS, string NomGerant, string DateNaissance, int NumCNI, string DateCNI, string Adresse, int NumTel, int NumMob, int NumFax, string Email)
        {
            try
            {
                sh.ExecuteQuery("UPDATE investisseur SET RaisonSociale='" + RaisonSociale + "',NomSociete='"+ NomSociete + "' ,Statut='"+ Statut + "',NumRC='"+NumRC+ "',DateRC=STR_TO_DATE('" + DateRC + "','%m/%d/%Y'),NIF='" + NIF + "',NIS='"+ NIS + "',NomGerant='"+NomGerant+ "', DateNaissance=STR_TO_DATE('" + DateNaissance + "','%m/%d/%Y' ), NumCNI='" + NumCNI + "',  DateCNI=STR_TO_DATE('" + DateCNI + "','%m/%d/%Y' ), Adresse='" + Adresse + "',NumTel='"+ NumTel + "',NumFax='"+ NumFax + "',Email='" + Email + "' Where IdInvestisseur =+" + id+ "");
                MessageBox.Show("L'investisseur a été bien modifié");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
       
        public void SupprimerInvestisseur(int IdInvestisseur)

        {
            var bouton = MessageBox.Show("La suppression de cet investisseur entraînera également la suppression de toutes les lignes d'attribution associées. Souhaitez-vous continuer ?   ", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);
            try
            {

                if (bouton == MessageBoxResult.Yes)
                {
                    sh.ExecuteQuery("delete from investisseur where IdInvestisseur ='" + IdInvestisseur + "'");
                    MessageBox.Show("Le client a été bien supprimé");
                }
                else if (bouton == MessageBoxResult.No)
                {
                 
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }




        }




    }


}

