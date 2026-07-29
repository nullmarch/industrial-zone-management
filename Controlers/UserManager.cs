using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;


namespace WpfApplication2.Controlers
{
    class UserManager
    {
       


        private string connectionString = "Server=localhost;Database=agerfor;port=3306;UserID=root;Password=";

        // Méthode pour hacher le mot de passe
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Méthode pour enregistrer un utilisateur avec un mot de passe haché
        public void RegisterUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO users (username, password_hash) VALUES (@username, @password_hash)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hashedPassword);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("User registered successfully.");
        }

        // Méthode pour vérifier le mot de passe
        public bool ValidateUser(string username, string password)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT password_hash FROM users WHERE username = @username";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader.GetString("password_hash");
                            string enteredHash = HashPassword(password);
                            return storedHash == enteredHash;
                        }
                        else
                        {
                            return false; // Utilisateur non trouvé
                        }
                    }
                }
            }
        }
    }
}

