using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
using System.Windows.Controls;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApplication2.Controlers
{
    class sqlhelper
    {
        public bool checkDB_Conn()
        {
            var conn_info = "Server=localhost;Port=3306;Database=agerfor;Uid=root;Pwd=";
            bool isConn = false;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(conn_info);
                conn.Open();
                isConn = true;

            }
            catch (ArgumentException a_ex)
            {

                /*
                Console.WriteLine("Check the Connection String.");
                Console.WriteLine(a_ex.Message);
                Console.WriteLine(a_ex.ToString());
                */
            }
            catch (MySqlException ex)
            {
                /*string sqlErrorMessage = "Message: " + ex.Message + "\n" +
                "Source: " + ex.Source + "\n" +
                "Number: " + ex.Number;
                Console.WriteLine(sqlErrorMessage);
                */
                isConn = false;
                switch (ex.Number)
                {
                    //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                    case 1042: // Unable to connect to any of the specified MySQL hosts (Check Server,Port)
                        MessageBox.Show("Connexion à la base de données non établie");
                        break;
                    case 0: // Access denied (Check DB name,username,password)
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return isConn;
        }




        public void ExecuteQuery(string Query)
        {
            string acc = "Server=localhost;Database=agerfor;port=3306;Uid=root;Pwd=";
            using (MySqlConnection connection = new MySqlConnection(acc))
            {
                connection.Open();
               
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = Query;            
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }

        public void loaddata(string sqrt, DataGrid datagrid)
        {
            try
            {
                string acc = "Server=localhost;Database=agerfor;port=3306;Uid=root;Pwd=";
                MySqlConnection connection = new MySqlConnection(acc);
                connection.Open();
               
                
                MySqlCommand cmd = new MySqlCommand(sqrt, connection);
                DataTable Dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(Dt);
                datagrid.DataContext = Dt;
                connection.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());


            }

        }

        public void loadfilldata(string Query, ComboBox cb, string Fillwidth)
        {
            try
            {
                string acc = "Server=localhost;Database=agerfor;port=3306;Uid=root;Pwd=";
                MySqlConnection connection = new MySqlConnection(acc);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cb.Items.Add(rdr[Fillwidth].ToString());
                }
                cb.SelectedItem = null;
                connection.Close();
            }
            catch (Exception)
            {

            }

        }



        public void loadfilldata2(string Query, ComboBox cb, string Fillwidth, string Fillwidth2)
        {
            try
            {
                string acc = "Server=localhost;Database=agerfor;port=3306;Uid=root;Pwd=";
                MySqlConnection connection = new MySqlConnection(acc);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cb.Items.Add(rdr[Fillwidth].ToString() + "-" + rdr[Fillwidth2].ToString());
                }
                cb.SelectedItem = null;
                connection.Close();
            }
            catch (Exception)
            {

            }

        }

        public void loadfilldata2(string Query, TextBox cb, string Fillwidth)
        {
            try
            {
                string acc = "Server=localhost;Database=agerfor;port=3306;Uid=root;Pwd=";
                MySqlConnection connection = new MySqlConnection(acc);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cb.Text = rdr[Fillwidth].ToString();
                }
                //cb.Text = null;
                connection.Close();
            }
            //  MessageBox.Show(cb.Text);            
            catch (Exception)
            {

            }

        }
        public string GetUntilOrEmpty(string text, string stopAt)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }

        public string getdata(string Query, string att)
        {
            try
            {
                string acc = "Server=localhost;Database=agerfor;port=3306;Uid=root;Pwd=";
                MySqlConnection connection = new MySqlConnection(acc);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    return rdr[att].ToString();
                }
                return "";
                
            }
            catch (Exception)
            {
                return "";
            }

        }

    }



    
}
