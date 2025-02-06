#ifndef _BDD_
#define _BDD_

#include "mysql-connector-c++-noinstall-1.1.9-win32/mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/driver.h"
#include "mysql-connector-c++-noinstall-1.1.9-win32/mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/exception.h"
#include "mysql-connector-c++-noinstall-1.1.9-win32/mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/resultset.h"
#include "mysql-connector-c++-noinstall-1.1.9-win32/mysql-connector-c++-noinstall-1.1.9-win32/include/cppconn/statement.h"

#include <string>

class BDD {

	private:
		std::string m_database = "casier_b";
		std::string m_login = "casier";
		std::string m_password = "casier";
		std::string m_host = "tcp://10.187.52.4:3306";

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


        bool BDD::estUnOperateurAutorise(std::string log, std::string pass)
        {

            std::string verification = "SELECT * FROM Utilisateur WHERE password = '" + pass + "' AND login = '" + log + "'"
                ;

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


};

#endif // !_BDD_
