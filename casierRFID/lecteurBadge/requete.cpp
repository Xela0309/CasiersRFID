#include "requete.h"

// Constructeur de la classe Requete : initialise la connexion à la base de données MySQL
Requete::Requete(const std::string& host, const std::string& user, const std::string& password, const std::string& database) {
    try {
        // Obtention d'une instance du driver MySQL
        driver = get_driver_instance();

        // Création d'une connexion avec les informations fournies (hôte, utilisateur, mot de passe)
        con = std::unique_ptr<sql::Connection>(driver->connect(host, user, password));

        // Sélection de la base de données à utiliser
        con->setSchema(database);

        std::cout << "Connexion a la base de donnees reussie !" << std::endl;
    }
    catch (sql::SQLException& e) {
        // Gestion des erreurs en cas d'échec de connexion
        std::cerr << "Erreur de connexion MySQL: " << e.what() << " (Code: " << e.getErrorCode() << ")" << std::endl;
    }
}

// Destructeur de la classe Requete : ferme la connexion à la base de données
Requete::~Requete() {
    deconnexion();
}

// Vérifie si la connexion à la base de données est bien établie
bool Requete::connexion() {
    return con != nullptr; // Retourne vrai si la connexion existe, faux sinon
}

// Ferme proprement la connexion à la base de données
void Requete::deconnexion() {
    if (con) {
        con.reset(); // Réinitialisation du pointeur unique, libérant ainsi la connexion
        std::cout << "Connexion MySQL fermee." << std::endl;
    }
}

// Insère un badge dans la base de données
bool Requete::insertBadge(const std::string& badgeID) {
    try {
        // Vérifie si la connexion à la base de données est bien établie avant d'insérer un badge
        if (!con) {
            std::cerr << "Erreur : connexion MySQL non etablie." << std::endl;
            return false;
        }

        // Préparation de la requête SQL pour insérer un badge dans la table "Tag"
        // Utilisation d'une requête préparée pour éviter les injections SQL
        std::unique_ptr<sql::PreparedStatement> pstmt(con->prepareStatement("INSERT INTO Tag (Tag) VALUES (?)"));

        // Remplacement du "?" dans la requête par l'identifiant du badge
        pstmt->setString(1, badgeID);

        // Exécution de la requête d'insertion
        pstmt->executeUpdate();

        std::cout << "Badge insere avec succes !" << std::endl;
        return true; // Retourne vrai si l'insertion s'est bien passée
    }
    catch (sql::SQLException& e) {
        // Gestion des erreurs en cas d'échec de l'insertion
        std::cerr << "Erreur d'insertion : " << e.what() << " (Code: " << e.getErrorCode() << ")" << std::endl;
        return false;
    }
}
