#include <iostream>
#include <string>
#include <memory>

// Inclusion du connecteur MySQL C++

#include <cppconn/exception.h>
#include <cppconn/driver.h>
#include <cppconn/resultset.h>
#include <cppconn/statement.h>
#include <cppconn/prepared_statement.h>
#ifndef _Requete_
#define _Requete_

class Requete {
private:
    std::unique_ptr<sql::Connection> con; // Connexion MySQL
    std::unique_ptr<sql::Statement> stmt;
    std::unique_ptr<sql::PreparedStatement> pstmt;
    sql::Driver* driver;

public:
    Requete(const std::string& host, const std::string& user, const std::string& password, const std::string& database);
    ~Requete();
    bool connexion();
    void deconnexion();
    bool doesTagExist(const std::string& badgeID);
    int getCasierIdFromTag(const std::string& badgeID);
};
#endif