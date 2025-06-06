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

bool Requete::doesTagExist(const std::string& badgeID) {
    try {
        // Vérifie si la connexion à la base de données est bien établie
        if (!con) {
            std::cerr << "Erreur : connexion MySQL non etablie." << std::endl;
            return false; // Retourne false si la connexion échoue
        }

        // Étape 1: Vérifier si le tag existe et récupérer son état
        std::unique_ptr<sql::PreparedStatement> pstmtTag(con->prepareStatement(
            "SELECT etat FROM Tag WHERE tag = ?"
        ));

        // Remplacer le "?" par l'identifiant du tag
        pstmtTag->setString(1, badgeID);

        // Exécution de la requête pour vérifier le tag et récupérer son état
        std::unique_ptr<sql::ResultSet> resTag(pstmtTag->executeQuery());

        std::string tagState; // Variable pour stocker l'état du tag
        if (resTag->next()) {
            tagState = resTag->getString("etat");  // Récupère l'état du tag
        }
        else {
            // Si aucun tag n'a été trouvé, retourne false
            std::cerr << "Le tag n'existe pas." << std::endl;
            return false;
        }

        // Si le tag est "perdu" (P), on retourne false directement
        if (tagState == "P") {
            std::cerr << "Le tag est perdu." << std::endl;
            return false;
        }

        // Étape 2: Vérifier si le tag existe dans la table Affectation
        std::unique_ptr<sql::PreparedStatement> pstmtAffectation(con->prepareStatement(
            "SELECT COUNT(*) FROM Affectation WHERE id_Tag = ?"
        ));

        // Remplacer le "?" par l'identifiant du tag
        pstmtAffectation->setString(1, badgeID);

        // Exécution de la requête pour vérifier si le tag est affecté
        std::unique_ptr<sql::ResultSet> resAffectation(pstmtAffectation->executeQuery());

        // Si le tag est trouvé dans la table Affectation
        if (resAffectation->next()) {
            int count = resAffectation->getInt(1);  // Récupère le résultat de la requête (le COUNT)
            if (count > 0) {
                // Le tag est affecté, donc il existe dans la table Affectation
                std::cout << "Le tag est déjà affecté." << std::endl;
                return true;  // Le tag existe et est affecté
            }
        }

        // Si aucune affectation n'a été trouvée, retourne false               
        std::cerr << "Le tag n'est pas affecté à un casier." << std::endl;
        return false;
    }
    catch (sql::SQLException& e) {
        // Gestion des erreurs en cas d'échec de la requête
        std::cerr << "Erreur lors de la vérification du tag : " << e.what() << " (Code: " << e.getErrorCode() << ")" << std::endl;
        return false;
    }
}

int Requete::getCasierIdFromTag(const std::string& badgeID) {
    try {
        // Étape 1: Vérifier si le tag existe et est affecté (en utilisant la méthode doesTagExist)
        if (!doesTagExist(badgeID)) {
            std::cerr << "Le tag n'existe pas ou n'est pas affecté à un casier." << std::endl;
            return -1; // Retourne -1 si le tag n'existe pas ou n'est pas affecté
        }

        // Étape 2: Si le tag existe et est affecté, récupérer l'ID du casier
        std::unique_ptr<sql::PreparedStatement> pstmtCasier(con->prepareStatement(
            "SELECT id_Casier FROM Affectation WHERE id_Tag = ?"
        ));

        // Remplacer le "?" par l'identifiant du tag
        pstmtCasier->setString(1, badgeID);

        // Exécution de la requête pour récupérer l'ID du casier
        std::unique_ptr<sql::ResultSet> resCasier(pstmtCasier->executeQuery());

        // Si un casier est trouvé, retourner son ID
        if (resCasier->next()) {
            int casierId = resCasier->getInt("id_Casier");
            std::cout << "ID Casier associé au tag " << badgeID << " : " << casierId << std::endl;
            return casierId;
        }
        else {
            // Si aucun casier n'a été trouvé pour le tag donné, retourne -1
            std::cerr << "Aucun casier trouvé pour ce tag." << std::endl;
            return -1;
        }
    }
    catch (sql::SQLException& e) {
        // Gestion des erreurs en cas d'échec de la requête
        std::cerr << "Erreur lors de la récupération de l'ID du casier : " << e.what() << " (Code: " << e.getErrorCode() << ")" << std::endl;
        return -1;
    }
}
