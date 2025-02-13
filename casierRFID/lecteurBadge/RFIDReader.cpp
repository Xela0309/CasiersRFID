#include "RFIDReader.h"

RFIDReader::RFIDReader(const std::string& port) : portUSB(port) {}

bool RFIDReader::openPort(int baudRate) {
    char erreur = serial.openDevice(portUSB.c_str(), baudRate);
    return erreur == 1;
}

std::string RFIDReader::readBadge() {
    std::string badgeData = "";
    char caracRecu;

    while (true) {
        char erreur = serial.readChar(&caracRecu, 2000); // Timeout de 2s

        if (erreur > 0) {
            if (caracRecu == 0x02) { // Début de transmission (STX)
                badgeData = "";
            }
            else if (caracRecu == 0x03) { // Fin de transmission (ETX)
                return badgeData; // Retourne les données complètes
            }
            else {
                badgeData += caracRecu;
            }
        }
        else if (erreur < 0) {
            return ""; // Erreur de lecture -> Retourne une chaîne vide
        }
    }
}

void RFIDReader::closePort() {
    serial.closeDevice();
}
