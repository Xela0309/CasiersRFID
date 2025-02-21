#ifndef _BDD_
#define _BDD_

#include "mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/driver.h"
#include "mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/exception.h"
#include "mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/resultset.h"
#include "mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/statement.h"
#include "mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/connection.h"
#include "mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/prepared_statement.h"

#include <string>
#include <vector>

class BDD {

	private:
		
		//std::string m_database = "m_Casier";
		//std::string m_host = "tcp://10.187.52.123:3306";

		std::string m_host = "tcp://10.187.52.4:3306";
		std::string m_database = "casier_b";
		std::string m_login = "casier";
		std::string m_password = "casier";

		

		sql::Driver* m_driver;
		sql::Connection* m_con;
		sql::Statement* m_stmt;
		sql::ResultSet* m_res;	// A SUPPRIMER ET A METTRE DANS LES METHODES EN LOCAL

    public:
        BDD::BDD()
            : m_driver(nullptr), m_con(nullptr), m_stmt(nullptr), m_res(nullptr)
        {}

        BDD::~BDD()
        {}

        bool BDD::connecter()
        {
            // Premier test du connecteur C++ Mysql


            try {
                m_driver = get_driver_instance();

                m_con = m_driver->connect(m_host, m_login, m_password);

                m_con->setSchema(m_database);

                m_stmt = m_con->createStatement();

            }
            catch (sql::SQLException& e) {
                // Gestion des execeptions
				return false;
            }
            return true;
        }

        bool BDD::connecter(std::string serveur, std::string login, std::string password, std::string baseDeDonnee)
        {

            try {

                sql::Driver* driver;
                sql::Connection* con;
                sql::Statement* stmt;
                sql::ResultSet* res;

                driver = get_driver_instance();

                con = driver->connect(serveur, login, password);

                con->setSchema(baseDeDonnee);


                m_stmt = m_con->createStatement();

            }
            catch (sql::SQLException& e) {
                // Gestion des execeptions
                return false;
            }
            return true;
        }

        void BDD::deconnecter()
        {
            delete m_res;
            delete m_stmt;
            delete m_con;

        }

        bool BDD::estUnUtilisateurAutorise(std::string log, std::string pass)
        {

            std::string verification = "SELECT * FROM Utilisateur WHERE password = '" + pass + "' AND login = '" + log + "'" ;

            m_res = m_stmt->executeQuery(verification);

            while (m_res->next())
            {

                
                if (log == m_res->getString("login") && pass == m_res->getString("password"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }


		bool BDD::estAdministrateur(std::string log, std::string pass)
		{
			std::string verification = "SELECT * FROM Utilisateur WHERE password = '" + pass + "' AND login = '" + log + "' AND role = 'admin' ";

			m_res = m_stmt->executeQuery(verification);

			while (m_res->next())
			{
				if (log == m_res->getString("login") && pass == m_res->getString("password"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		std::vector<std::string> BDD::listeAffectation()
		{
			std::vector<std::string> liste;

			std::string affectation = "SELECT * FROM Affectation";

			m_res = m_stmt->executeQuery(affectation);

			while (m_res->next())
			{
    		    //liste.push_back("Casier n°" + m_res->getString("id_Casier"));
				liste.push_back(m_res->getString("id_Casier"));
			}

			return liste;
		}

		std::vector<std::string> BDD::infosAffectation(std::string casier)
		{
			std::vector<std::string> infos;

			std::string affectationInfos = "SELECT t.tag , v.nom , v.prenom , v.compagnie , v.numPlaque , c.numeroCasier , a.dateDebut , a.dateFin FROM Affectation a , Visiteur v , Tag t , Casier c WHERE a.id_Visiteur = v.id_Visiteur AND a.id_Tag = t.tag AND a.id_Casier = c.numeroCasier AND c.numeroCasier = '" + casier + "'";

			m_res = m_stmt->executeQuery(affectationInfos);

			while (m_res->next())
			{
				infos.push_back(m_res->getString("tag"));
				infos.push_back(m_res->getString("nom"));
				infos.push_back(m_res->getString("prenom"));
				infos.push_back(m_res->getString("compagnie"));
				infos.push_back(m_res->getString("numPlaque"));
				infos.push_back(m_res->getString("numeroCasier"));
				infos.push_back(m_res->getString("dateDebut"));
				infos.push_back(m_res->getString("dateFin"));
			}


			return infos;
		}

		std::vector<std::string> BDD::listeVisiteurNonAffecter()
		{
			std::vector<std::string> liste;

			std::string affectation = "SELECT * FROM Visiteur WHERE id_Visiteur NOT IN (SELECT id_Visiteur FROM Affectation)";

			m_res = m_stmt->executeQuery(affectation);

			while (m_res->next())
			{
				liste.push_back(m_res->getString("nom"));
			}
			return liste;
		}

		std::vector<std::string> BDD::listeCasierNonAffecter()
		{
			std::vector<std::string> liste;

			std::string affectation = "SELECT * FROM Casier WHERE numeroCasier NOT IN (SELECT id_Casier FROM Affectation)";

			m_res = m_stmt->executeQuery(affectation);

			while (m_res->next())
			{
				liste.push_back(m_res->getString("numeroCasier"));
			}
			return liste;
		}

        std::vector<std::string> BDD::listeTagNonAffecter()
		{
			std::vector<std::string> liste;

			std::string affectation = "SELECT * FROM Tag WHERE tag NOT IN (SELECT id_Tag FROM Affectation)";

			m_res = m_stmt->executeQuery(affectation);

			while (m_res->next())
			{
				liste.push_back(m_res->getString("tag"));
			}
			return liste;
		}

		bool BDD::ajouterAffectation(std::string nom, std::string casier, std::string tag,std::string dateDebut, std::string dateFin)
		{
			std::string affectation = "INSERT INTO Affectation (id_Visiteur, id_Casier, id_Tag, dateDebut, dateFin) VALUES ((SELECT id_Visiteur FROM Visiteur WHERE nom = '" + nom + "'), '" + casier + "', '" + tag + "', '" + dateDebut + "', '" + dateFin + "')";

			m_stmt->execute(affectation);

			return true;
		}

		bool BDD::verificationAffectationExistente(std::string nom, std::string casier, std::string tag)
		{
			// Verifie si un Visiteur est deja affecter
			std::string affectation = "SELECT * FROM Affectation WHERE id_Visiteur = (SELECT id_Visiteur FROM Visiteur WHERE nom = '" + nom + "') ";
			
			// Verifie si un tag est deja affecter
			std::string affectation2 = "SELECT * FROM Affectation WHERE id_Tag = '" + tag + "'";
			
			// Verifie si un casier est deja affecter
			std::string affectation3 = "SELECT * FROM Affectation WHERE id_Casier = '" + casier + "'";

			// Verification des requtes
			m_res = m_stmt->executeQuery(affectation);
			if (m_res->next())
			{
				return false;
			}
			m_res = m_stmt->executeQuery(affectation2);
			if (m_res->next())
			{
				return false;
			}
			m_res = m_stmt->executeQuery(affectation3);
			if (m_res->next())
			{
				return false;
			}
			return true;

		}
		 
		bool BDD::ajouterVisiteur(std::string nom, std::string prenom, std::string compagnie, std::string plaque)
		{
			std::string affectation = "INSERT INTO Visiteur (nom, prenom, compagnie, numPlaque) VALUES ('" + nom + "', '" + prenom + "', '" + compagnie + "', '" + plaque + "')";

			m_stmt->execute(affectation);

			return true;
		}

		bool BDD::ajouterUtilisateur(std::string login, std::string password, std::string role)
		{
			std::string affectation = "INSERT INTO Utilisateur (login, password, role) VALUES ('" + login + "', '" + password + "', '" + role + "')";

			m_stmt->execute(affectation);

			return true;
		}
		
		bool BDD::ajouterCasier(std::string casier)
		{
			std::string affectation = "INSERT INTO Casier (numeroCasier) VALUES ('" + casier + "')";

			m_stmt->execute(affectation);

			return true;
		}

		bool BDD::ajouterTag(std::string tag)
		{
			std::string affectation = "INSERT INTO Tag (tag) VALUES ('" + tag + "')";

			m_stmt->execute(affectation);

			return true;
		}

		bool BDD::supprimerVisiteur(std::string nom)
		{
			std::string affectation = "DELETE FROM Visiteur WHERE nom = '" + nom + "'";

			m_stmt->execute(affectation);

			return true;
		}

		bool BDD::supprimerAffectation(std::string casier)
		{
			std::string affectation = "DELETE FROM Affectation WHERE id_Casier = '" + casier + "'";

			m_stmt->execute(affectation);

			return true;
		}

};

#endif // !_BDD_
