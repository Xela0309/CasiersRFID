using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AppCasier;
using MySqlConnector; // Assurez-vous d'importer cette bibliothèque
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace testBDD
{
    internal class DatabaseConnection
    {
        private MySqlConnection connection;

        private Chiffrage chiffrage = new Chiffrage("CryptageApplication"); // Chiffrement du mot de passe

        // Chaîne de connexion pour MySQL/MariaDB
        private string connectionString = "server=10.187.52.4;userid=casier;password=casier;database=casier_b;";
        //private string connectionString = "server=10.187.52.123;userid=casier;password=casier;database=m_Casier;";
        //private string connectionString = "server=10.187.52.123;userid=casier;password=casier;database=m_Casier;";


        public DatabaseConnection()
        {
            connection = new MySqlConnection(connectionString); // Initialisation de la connexion
        }

        // Ouvrir la connexion à la base de données

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // Exécution d'une requête
        public bool ExecuteQuery(string query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                int result = cmd.ExecuteNonQuery();  // Utilisé pour les requêtes qui ne retournent pas de données
                return true;

            }
            catch (Exception ex)
            {
                 return false;

            }
        }

        // Lire des données depuis la base
        /* ------Exemple de lecture de données------
        public void ReadData()
        {
            try
            {
                string query = "SELECT id_Visiteur,nom , prenom FROM Visiteur";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                //  Afficher les données
                while (reader.Read())
                {
                    Console.WriteLine("Nom : " + reader[0] + " Prenom : " + reader[1]);
                }



                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la lecture des données : " + ex.Message);
            }
        }
        */

        public bool estUtilisateur(string login, string pass)
        {
            try
            {
                string requete = "SELECT * FROM Utilisateur";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (login == chiffrage.Decrypt(reader[2].ToString()) && pass == chiffrage.Decrypt(reader[3].ToString()))
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string[] listeAffectation()
        {
            try
            {
                string requete = "SELECT * FROM Affectation";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<string> liste = new List<string>();

                while (reader.Read())
                {
                    liste.Add(reader[1].ToString());
                }
                reader.Close();
                return liste.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string[] detailsAffectation(string casier)
        {
            try
            {
                string requete = "SELECT t.tag , v.nom , v.prenom , v.compagnie , v.numPlaque , c.numeroCasier , a.dateDebut , a.dateFin FROM Affectation a, Visiteur v , Tag t, Casier c WHERE a.id_Visiteur = v.id_Visiteur AND a.id_Tag = t.tag AND a.id_Casier = c.numeroCasier AND c.numeroCasier = '" + casier + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                string[] details = new string[8];
                details[0] = reader[0].ToString();
                details[1] = reader[1].ToString();
                details[2] = reader[2].ToString();
                details[3] = reader[3].ToString();
                details[4] = reader[4].ToString();
                details[5] = reader[5].ToString();
                details[6] = reader[6].ToString();
                details[7] = reader[7].ToString();




                reader.Close();
                return details;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
