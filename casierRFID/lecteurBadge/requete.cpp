#include "requete.h"

// Constructeur de la classe Requete : initialise la connexion à la base de données MySQL
Requete::Requete(const std::string& host, const std::string& user, const std::string& password, const std::string& database)
{
    try
    {
        // Obtention d'une instance du driver MySQL
        driver = get_driver_instance();

        // Création d'une connexion avec les informations fournies (hôte, utilisateur, mot de passe)
        con = std::unique_ptr<sql::Connection>(driver->connect(host, user, password));

        // Sélection de la base de données à utiliser
        con->setSchema(database);

        std::cout << "Connexion a la base de donnees reussie !" << std::endl;
    }
    catch (sql::SQLException& e)
    {
        // Gestion des erreurs en cas d'échec de connexion
        std::cerr << "Erreur de connexion MySQL: " << e.what() << " (Code: " << e.getErrorCode() << ")" << std::endl;
    }
}

// Destructeur de la classe Requete : ferme la connexion à la base de données
Requete::~Requete()
{
    deconnexion();
}

// Vérifie si la connexion à la base de données est bien établie
bool Requete::connexion()
{
    return con != nullptr; // Retourne vrai si la connexion existe, faux sinon
}

// Ferme proprement la connexion à la base de données
void Requete::deconnexion()
{
    if (con)
    {
        con.reset(); // Réinitialisation du pointeur unique, libérant ainsi la connexion
        std::cout << "Connexion MySQL fermee." << std::endl;
    }
}

// Vérifie si un badge existe dans la base de données
bool Requete::badgeExiste(const std::string& badgeID)
{
    try
    {
        if (!con)
        {
            std::cerr << "Erreur : connexion MySQL non établie." << std::endl;
            return false;
        }

        std::unique_ptr<sql::PreparedStatement> pstmt(con->prepareStatement("SELECT COUNT(*) FROM Tag WHERE Tag = ?"));
        pstmt->setString(1, badgeID);

        std::unique_ptr<sql::ResultSet> res(pstmt->executeQuery());
        res->next();

        return res->getInt(1) > 0; // Retourne vrai si le badge existe déjà
    }
    catch (sql::SQLException& e)
    {
        std::cerr << "Erreur lors de la vérification du badge : " << e.what() << " (Code: " << e.getErrorCode() << ")" << std::endl;
        return false;
    }
}
