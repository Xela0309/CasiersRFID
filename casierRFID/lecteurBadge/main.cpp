#include <iostream>
#include <string>

// Inclusions des headers nécessaires
#include "RFIDReader.h"
#include "requete.h"
#include "serialib.h"

using namespace std;

void programme1() {
    cout << "=== Programme 1 : Lecture RFID avec base de donnees ===" << endl;

    RFIDReader reader("/dev/ttyUSB0");
    Requete dbManager("tcp://10.187.52.4", "casier", "casier", "casier_b"); // Connexion à la base en ligne

    if (!dbManager.connexion()) {
        cerr << "Echec de connexion a la base de donnees." << endl;
        return;
    }

    if (!reader.openPort()) {
        cerr << "Echec d'ouverture du port RFID." << endl;
        return;
    }

    while (true) {
        std::string badge = reader.readBadge();
        if (!badge.empty()) {
            cout << "Badge detecte : " << badge << endl;
            if (dbManager.badgeExiste(badge)) {
                cout << "Badge deja enregistre." << endl;
            }
        }
    }

    reader.closePort();
    dbManager.deconnexion();
}

void programme2() {
    cout << "=== Programme 2 : Lecture RFID avec serialib ===" << endl;

    serialib serial;
    const string portUSB("/dev/ttyUSB0");

    if (serial.openDevice(portUSB.c_str(), 9600) != 1) {
        cerr << "Ouverture du port serie KO !" << endl;
        return;
    }

    cout << "Ouverture du port serie OK. Lecture en cours..." << endl;

    string badgeData = "";

    while (true) {
        char caracRecu;
        int erreur = serial.readChar(&caracRecu, 2000);

        if (erreur > 0) {
            if (caracRecu == 0x02) {
                badgeData = "";
            }
            else if (caracRecu == 0x03) {
                cout << "Donnee recue : " << badgeData << endl;
                badgeData = "";
            }
            else {
                badgeData += caracRecu;
            }
        }
        else if (erreur < 0) {
            cerr << "Erreur de lecture." << endl;
            break;
        }
    }

    serial.closeDevice();
}

int main() {
    cout << "Choisis un programme a tester :" << endl;
    cout << "1 - RFID avec base de donnees" << endl;
    cout << "2 - RFID simple avec serialib" << endl;
    cout << "Ton choix : ";

    int choix;
    cin >> choix;

    if (choix == 1) {
        programme1();
    }
    else if (choix == 2) {
        programme2();
    }
    else {
        cerr << "Choix invalide." << endl;
    }

    return 0;
}
