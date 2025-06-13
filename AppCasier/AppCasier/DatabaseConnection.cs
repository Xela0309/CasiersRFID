using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySqlConnector; // Assurez-vous d'importer cette bibliothèque
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//d2c72a3e81

namespace AppCasier
{
    internal class DatabaseConnection
    {
        private MySqlConnection connection ;

        private int nbAffectation ;
         
        private ChiffrageXOR chiffrage = new ChiffrageXOR("ChiffrementXORApplication"); // Chiffrement du mot de passe

        // Chaîne de connexion pour MySQL/MariaDB
        //private string connectionString = "server=10.187.52.4;userid=casier;password=casier;database=casier_b;";
        //private string connectionString = "server=10.187.52.123;userid=casier;password=casier;database=m_Casier;";
        private string connectionString = "server=192.168.2.2;userid=casier;password=casier;database=m_Casier;";


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
                string requete = "SELECT t.tag , v.nom , v.prenom , v.compagnie , v.numPlaque , c.numeroCasier , a.dateDebut , a.dateFin , v.pays FROM Affectation a, Visiteur v , Tag t, Casier c WHERE a.id_Visiteur = v.id_Visiteur AND a.id_Tag = t.tag AND a.id_Casier = c.numeroCasier AND c.numeroCasier = '" + casier + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                string[] details = new string[9];
                details[0] = reader[0].ToString();
                details[1] = reader[1].ToString();
                details[2] = reader[2].ToString();
                details[3] = reader[3].ToString();
                details[4] = reader[4].ToString();
                details[5] = reader[5].ToString();
                details[6] = reader[6].ToString();
                details[7] = reader[7].ToString();
                details[8] = reader[8].ToString();

                reader.Close();
                return details;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des détails de l'affectation : " + ex.Message);
                return null;
            }
        }

        public bool ajouterAffectation(string tag, string nom,string prenom ,string casier, string dateDeb, string dateFin)
        {
            try
            {
                nom = chiffrage.Encrypt(nom);
                prenom = chiffrage.Encrypt(prenom);

                if (!updateEtatTagO(tag)) throw new Exception("Erreur lors de la mise à jour du tag");

                string requete = "INSERT INTO Affectation (id_Tag, id_Visiteur, id_Casier, dateDebut, dateFin) VALUES ('" + tag + "', (SELECT id_Visiteur FROM Visiteur WHERE nom = '" + nom + "' AND prenom = '" + prenom + "' ) , '" + casier + "' , '" + dateDeb + "' , '" + dateFin + "')";

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
                if (!updateEtatTagU(casier)) throw new Exception("Erreur lors de la mise à jour du tag");

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

        public bool ajouterVisiteur(string nom, string prenom, string plaque, string compagnie,string pays)
        {
            try
            {

                // Chiffrage des informations
                nom = chiffrage.Encrypt(nom);
                prenom = chiffrage.Encrypt(prenom);
                plaque = chiffrage.Encrypt(plaque);
                compagnie = chiffrage.Encrypt(compagnie);
                pays = chiffrage.Encrypt(pays);

                string requete = "INSERT INTO Visiteur (nom, prenom, numPlaque, compagnie,pays) VALUES ('" + nom + "', '" + prenom + "', '" + plaque + "', '" + compagnie + "' ,'" + pays +"')";

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

        public string[] recupNomPrenomVisiteurNonAffecté()
        {
            try
            {
                string requete = "SELECT * FROM Visiteur WHERE id_Visiteur NOT IN (SELECT id_Visiteur FROM Affectation)";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<string> liste = new List<string>();

                while (reader.Read())
                {
                    liste.Add(chiffrage.Decrypt(reader[1].ToString()) + " " + chiffrage.Decrypt(reader[2].ToString()));
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

        public string[] recupNomUtilisateur()
        {
            try
            {
                string requete = "SELECT * FROM Utilisateur";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<string> liste = new List<string>();

                while (reader.Read())
                {
                    liste.Add(chiffrage.Decrypt(reader[2].ToString()));
                }
                reader.Close();
                return liste.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des utilisateurs : " + ex.Message);
                return null;
            }
        }


        public bool supprimerVisiteur(string nom, string prenom)
        {
            try
            {
                nom = chiffrage.Encrypt(nom);
                prenom = chiffrage.Encrypt(prenom);

                string requete = "DELETE FROM Visiteur WHERE nom = '" + nom + "' AND prenom = '" + prenom + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du visiteur : " + ex.Message);
                return false;
            }
        }

        public bool supprimerUtilisateur(string login)
        {
            try
            {
                login = chiffrage.Encrypt(login);

                string requete = "DELETE FROM Utilisateur WHERE login = '" + login + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression de l'utilisateur : " + ex.Message);
                return false;
            }
        }

        public bool supprimerTag(string tag)
        {
            try
            {
                string requete = "DELETE FROM Tag WHERE tag = '" + tag + "' AND etat = 'U'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du tag : " + ex.Message);
                return false;
            }
        }

        public bool verifyVisiteur(string nom, string prenom)
        {
            try
            {
                nom = chiffrage.Encrypt(nom);
                prenom = chiffrage.Encrypt(prenom);

                string requete = "SELECT * FROM Visiteur WHERE nom = '" + nom + "' AND prenom = '" + prenom + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la vérification du visiteur : " + ex.Message);
                return false;
            }
        }

        public bool verifyUtilisateur(string login)
        {
            try
            {
                login = chiffrage.Encrypt(login);
                string requete = "SELECT * FROM Utilisateur WHERE login = '" + login + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la vérification de l'utilisateur : " + ex.Message);
                return false;
            }
        }

        public string[] affectationDateLimite()
        {
            try
            {
                string requete = "SELECT * FROM Affectation a, Tag t WHERE a.id_Tag = t.tag AND a.dateFin < NOW() AND t.etat = 'O'";

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
                MessageBox.Show("Erreur lors de la récupération des affectations : " + ex.Message);
                return null;
            }
        }

        public string[] infoAffectation(string id)
        {
            try
            {
                string requete = "SELECT t.tag , v.nom , v.prenom , v.compagnie , v.numPlaque , c.numeroCasier , a.dateDebut , a.dateFin , v.pays FROM Affectation a, Visiteur v , Tag t, Casier c WHERE a.id_Visiteur = v.id_Visiteur AND a.id_Tag = t.tag AND a.id_Casier = c.numeroCasier AND a.id_Affectation = '" + id + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                string[] details = new string[9];
                details[0] = reader[0].ToString();
                details[1] = reader[1].ToString();
                details[2] = reader[2].ToString();
                details[3] = reader[3].ToString();
                details[4] = reader[4].ToString();
                details[5] = reader[5].ToString();
                details[6] = reader[6].ToString();
                details[7] = reader[7].ToString();
                details[8] = reader[8].ToString();




                reader.Close();
                return details;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des info de l'affectation : " + ex.Message);
                return null;
            }
        }

        public bool verifTag(string tag)
        {
            try
            {
                string requete = "SELECT * FROM Tag WHERE tag = '" + tag + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la vérification du tag : " + ex.Message);
                return false;
            }
        }

        public bool ajouterTag(string tag)
        {
            try
            {
                string requete = "INSERT INTO Tag (tag,etat) VALUES ('" + tag + "','U')";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du tag : " + ex.Message);
                return false;
            }
        }

        public bool rendrePerdu(string tag)
        {
            try
            {
                string requete = "UPDATE Tag SET etat = 'P' WHERE tag = '" + tag + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du tag : " + ex.Message);
                return false;
            }
        }

        public bool rendreUtilisable(string tag)
        {
            try
            {
                string requete = "UPDATE Tag SET etat = 'U' WHERE tag = '" + tag + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du tag : " + ex.Message);
                return false;
            }
        }

        public bool updateEtatTagO(string tag)
        {
            try
            {
                string requete = "UPDATE Tag SET etat = 'O' WHERE tag = '" + tag + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du tag : " + ex.Message);
                return false;
            }
        }

        public bool updateEtatTagU(string casier)
        {
            try
            {
                string requete = "UPDATE Tag SET etat = 'U' WHERE tag = (SELECT id_Tag FROM Affectation WHERE id_Casier = '" + casier + "')";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du tag : " + ex.Message);
                return false;
            }
        }

        public string[] recupTagPO()
        {
            try
            {
                string requete = "SELECT * FROM Tag WHERE etat = 'P' OR etat = 'O'";

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
        
        public char getEtatTag(string tag)
        {
            try
            {
                string requete = "SELECT * FROM Tag WHERE tag = '" + tag + "'";

                MySqlCommand cmd = new MySqlCommand(requete, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                char etat = Convert.ToChar(reader[1].ToString());
                reader.Close();
                return etat;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération de l'état du tag : " + ex.Message);
                return '?';
            }
        }

        public bool updateTag(string tag, string etat)
        {
            try
            {
                if (etat == "O")
                {
                    string requete = "UPDATE Tag SET etat = 'P' WHERE tag = '" + tag + "'";
                    MySqlCommand cmd = new MySqlCommand(requete, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else if (etat == "P")
                {
                    string requete = "UPDATE Tag SET etat = 'O' WHERE tag = '" + tag + "'";
                    MySqlCommand cmd = new MySqlCommand(requete, connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    MessageBox.Show("Erreur lors de la mise à jour du tag : état invalide");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du tag : " + ex.Message);
                return false;
            }
        }

        public int ComptageAffectations()
        {
            try
            {
                string requete = "SELECT COUNT(*) FROM Affectation";
                MySqlCommand cmd = new MySqlCommand(requete, connection);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du comptage des affectations : " + ex.Message);
                return -1;
            }

        }

        public int GetNbAffectation()
        {
            return nbAffectation;
        }

        public void SetNbAffectation(int nb)
        {
            nbAffectation = nb;
        }
    }
}
