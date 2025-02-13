#pragma once

#include <iostream>
#include <string>
#include <memory>

// Inclusion du connecteur MySQL C++
#include <cppconn/driver.h>
#include <cppconn/exception.h>
#include <cppconn/resultset.h>
#include <cppconn/statement.h>
#include <cppconn/prepared_statement.h>

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
    bool insertBadge(const std::string& badgeID);
};
