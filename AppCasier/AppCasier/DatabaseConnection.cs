using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySqlConnector; // Assurez-vous d'importer cette bibliothèque


namespace AppCasier
{
    internal class DatabaseConnection
    {
        private MySqlConnection connection;

        private ChiffrageXOR chiffrage = new ChiffrageXOR("ChiffrementXORApplication"); // Chiffrement du mot de passe

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
                MessageBox.Show("Erreur lors de la connexion à la base de données : " + ex.Message);
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
                MessageBox.Show("Erreur lors de la fermeture de la connexion à la base de données : " + ex.Message);
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
                MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message);
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
                MessageBox.Show("Erreur lors de la vérification de l'utilisateur : " + ex.Message);
                return false;
            }
        }

        public bool estAdministateur(string login)
        {
            try
            {


                string requete = "SELECT * FROM Utilisateur WHERE role = 'admin' ";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                login = chiffrage.Encrypt(login);

                while (reader.Read())
                {
                    if (reader[2].ToString() == login)
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
                MessageBox.Show("Erreur lors de la vérification de l'administrateur : " + ex.Message);
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
                MessageBox.Show("Erreur lors de la récupération des affectations : " + ex.Message);
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
                MessageBox.Show("Erreur lors de la récupération des détails de l'affectation : " + ex.Message);
                return null;
            }
        }

        public bool ajouterAffectation(string tag, string nom,string casier, string dateDeb, string dateFin)
        {
            try
            {
                nom = chiffrage.Encrypt(nom);

                string requete = "INSERT INTO Affectation (id_Tag, id_Visiteur, id_Casier, dateDebut, dateFin) VALUES ('" + tag + "', (SELECT id_Visiteur FROM Visiteur WHERE nom = '" + nom + "' ) , '" + casier + "' , '" + dateDeb + "' , '" + dateFin + "')";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'affectation : " + ex.Message);
                return false;
            }
        }

        public void supprimerAffectation(string casier)
        {
            try
            {
                string requete = "DELETE FROM Affectation WHERE id_Casier = '" + casier + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression de l'affectation : " + ex.Message);
            }
        }

        public string[] recupNomVisiteurNonAffecté()
        {
            try
            {
                string requete = "SELECT * FROM Visiteur WHERE id_Visiteur NOT IN (SELECT id_Visiteur FROM Affectation)";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<string> liste = new List<string>();

                while (reader.Read())
                {
                    liste.Add(chiffrage.Decrypt(reader[1].ToString()));
                }
                reader.Close();
                return liste.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des visiteurs : " + ex.Message);
                return null;
            }   
        }

        public string[] recupNumCasierNonAffecté()
        {
            try
            {
                string requete = "SELECT * FROM Casier WHERE numeroCasier NOT IN (SELECT id_Casier FROM Affectation)";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<string> liste = new List<string>();

                while (reader.Read())
                {
                    liste.Add(reader[0].ToString());
                }
                reader.Close();
                return liste.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des casiers : " + ex.Message);
                return null;
            }
        }

        public string[] recupNumTagNonAffecté()
        {
            try
            {
                string requete = "SELECT * FROM Tag WHERE tag NOT IN (SELECT id_Tag FROM Affectation)";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<string> liste = new List<string>();

                while (reader.Read())
                {
                    liste.Add(reader[0].ToString());
                }
                reader.Close();
                return liste.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des tags : " + ex.Message);
                return null;
            }
        }

        public bool ajouterUtilisateur(string login, string pass, string role)
        {
            try
            {
                // Chiffrage du login et du mot de passe
                login = chiffrage.Encrypt(login);
                pass = chiffrage.Encrypt(pass);

                string requete = "SELECT * FROM Utilisateur WHERE login = '" + login + "'";

                // Vérifier si l'utilisateur existe déjà

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return false;
                }
                else
                {
                    reader.Close();

                    requete = "INSERT INTO Utilisateur (login, password, role) VALUES ('" + login + "', '" + pass + "', '" + role + "')";

                    MySqlCommand cmd1 = new MySqlCommand(requete, connection);
                    cmd1.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'utilisateur : " + ex.Message);
                return false;
            }
        }

        public bool ajouterVisiteur(string nom, string prenom, string plaque, string compagnie)
        {
            try
            {
                // Chiffrage des informations
                nom = chiffrage.Encrypt(nom);
                prenom = chiffrage.Encrypt(prenom);
                plaque = chiffrage.Encrypt(plaque);
                compagnie = chiffrage.Encrypt(compagnie);

                string requete = "INSERT INTO Visiteur (nom, prenom, numPlaque, compagnie) VALUES ('" + nom + "', '" + prenom + "', '" + plaque + "', '" + compagnie + "')";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du visiteur : " + ex.Message);
                return false;
            }
        }
    }
}
