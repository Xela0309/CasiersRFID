#include "requete.h"

// Constructeur de la classe Requete : initialise la connexion � la base de donn�es MySQL
Requete::Requete(const std::string& host, const std::string& user, const std::string& password, const std::string& database) {
    try {
        // Obtention d'une instance du driver MySQL
        driver = get_driver_instance();

        // Cr�ation d'une connexion avec les informations fournies (h�te, utilisateur, mot de passe)
        con = std::unique_ptr<sql::Connection>(driver->connect(host, user, password));

        // S�lection de la base de donn�es � utiliser
        con->setSchema(database);

        std::cout << "Connexion a la base de donnees reussie !" << std::endl;
    }
    catch (sql::SQLException& e) {
        // Gestion des erreurs en cas d'�chec de connexion
        std::cerr << "Erreur de connexion MySQL: " << e.what() << " (Code: " << e.getErrorCode() << ")" << std::endl;
    }
}

// Destructeur de la classe Requete : ferme la connexion � la base de donn�es
Requete::~Requete() {
    deconnexion();
}

// V�rifie si la connexion � la base de donn�es est bien �tablie
bool Requete::connexion() {
    return con != nullptr; // Retourne vrai si la connexion existe, faux sinon
}

// Ferme proprement la connexion � la base de donn�es
void Requete::deconnexion() {
    if (con) {
        con.reset(); // R�initialisation du pointeur unique, lib�rant ainsi la connexion
        std::cout << "Connexion MySQL fermee." << std::endl;
    }
}

// Ins�re un badge dans la base de donn�es
bool Requete::insertBadge(const std::string& badgeID) {
    try {
        // V�rifie si la connexion � la base de donn�es est bien �tablie avant d'ins�rer un badge
        if (!con) {
            std::cerr << "Erreur : connexion MySQL non etablie." << std::endl;
            return false;
        }

        // Pr�paration de la requ�te SQL pour ins�rer un badge dans la table "Tag"
        // Utilisation d'une requ�te pr�par�e pour �viter les injections SQL
        std::unique_ptr<sql::PreparedStatement> pstmt(con->prepareStatement("INSERT INTO Tag (Tag) VALUES (?)"));

        // Remplacement du "?" dans la requ�te par l'identifiant du badge
        pstmt->setString(1, badgeID);

        // Ex�cution de la requ�te d'insertion
        pstmt->executeUpdate();

        std::cout << "Badge insere avec succes !" << std::endl;
        return true; // Retourne vrai si l'insertion s'est bien pass�e
    }
    catch (sql::SQLException& e) {
        // Gestion des erreurs en cas d'�chec de l'insertion
        std::cerr << "Erreur d'insertion : " << e.what() << " (Code: " << e.getErrorCode() << ")" << std::endl;
        return false;
    }
}
