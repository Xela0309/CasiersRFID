#include "RFIDReader.h"
#include "requete.h"
#include <iostream>

int main() {
    RFIDReader reader("/dev/ttyUSB0");

    // Paramètres de connexion à la base MySQL (via phpMyAdmin)
    Requete dbManager("tcp://10.187.52.4", "casier", "casier", "casier_b");

    if (!dbManager.connexion()) {
        return -1;
    }

    if (!reader.openPort()) {
        return -1;
    }

    while (true) {
        std::string badge = reader.readBadge();
        if (!badge.empty()) {
            std::cout << "Badge enregistré : " << badge << std::endl;

            // Insérer dans la base de données
            dbManager.insertBadge(badge);
        }
    }

    reader.closePort();
    dbManager.deconnexion();

    return 0;
}
