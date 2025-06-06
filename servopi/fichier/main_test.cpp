#include <iostream>
#include <vector>
#include <string>
#include <cstdlib>
#include <cstdint>  // type int8_t, int16_t, uint8_t, etc...
#include <thread>   // Pour std::this_thread::sleep_for
#include <mutex>
#include <fstream>
#include <sstream>
#include <vector>

using namespace std;

#include "serialib.h"
#include "servo_class.h"
#include "RGBLED.h"
#include "requete.h"
#include "RFIDReader.h"

int main(int argc, char** argv) {
		
	DelRGBChainable d(16, 17, 5);
	uint16_t status = 0;
	ServoH servoh;
	serialib VS;
	ServoH::ServoValuePos servopos;
	ServoH::ServoValueVolt servovolt;

	
		servopos = servoh.readInfoServoPos();
		
		servovolt = servoh.readInfoServoVolt();

	    // Initialisation des objets
	    RFIDReader reader("/dev/ttyUSB0");
	    Requete dbManager("tcp://10.187.52.4", "casier", "casier", "casier_b");
	
	    // Connexion à la base de données
	    if (!dbManager.connexion()) {
	        cerr << "Erreur de connexion à la base de données." << endl;
	        return -1;
	    }

	    d.initGpio();  // Initialisation des GPIO
	
	   
	    cout << "Avant ouverture" << endl;
		
	
	    if (!servoh.openConnection("/dev/ttyS0", 115200, VS)) {
	        cerr << "Erreur d'ouverture de la connexion série." << endl;
	        return -1;
	    }
	
	    cout << "Après ouverture" << endl;
	    cout << "avant scan" << endl;
	    /*servoh.scanServos(&VS);*/  // Scanner les servos
		std::vector<uint8_t> servosOnBus;
		if (ServoH::scanBus(&VS, servosOnBus, 20)) {
			for (uint8_t i = 0; i < servosOnBus.size(); i++) {
				std::cout << "Id servo : " << static_cast<int>(servosOnBus.at(i)) << std::endl;
			}
		}
	    cout << "Après scan" << endl;

	    //Création des servos
		ServoH s0(&VS, 0);
		ServoH s1(&VS, 1);
	    ServoH s2(&VS, 2);
		ServoH s3(&VS, 3);
		ServoH s4(&VS, 4);
		ServoH s5(&VS, 5);

		d.GreenLed(0);
		d.GreenLed(1);
		d.GreenLed(2);
		d.GreenLed(3);
		d.GreenLed(4);

	    while (true) {

			if (!reader.openPort()) {
				cerr << "Erreur d'ouverture du port RFID." << endl;
				return -1;
			}
	
	        string badge = reader.readBadge();
	
	        if (!badge.empty()) {
	            cout << "Badge lu : " << badge << endl;
				
				reader.closePort();

	            if (dbManager.doesTagExist(badge)) {
	                // Badge existant
	                cout << "Badge déjà enregistré." << endl;
	
	                int casierId = dbManager.getCasierIdFromTag(badge);
	
					servoh.openRfidServo(servopos.servo0, s0, 3000);
					std::this_thread::sleep_for(std::chrono::milliseconds(1000));  // Pause de 1000 ms
					servoh.closeRfidServo(s0, 1000);
					

	                if (casierId != -1) {
	                    cout << "Casier ID associé : " << casierId << endl;
	
	                    // Selon l'ID du casier, actionner le servomoteur correspondant
	                    if (casierId == 1) {
	                        // Casier 1 : ouvrir le servomoteur 1
							servoh.openServo(s1, 1000); 
							d.FlashesGreenLed(0);
	                        std::this_thread::sleep_for(std::chrono::milliseconds(1000));
							servoh.closeServo(servopos.servo1, s1);     // Fermer le servo
							d.RedLed(0);
	                    }
	                    else if (casierId == 2) {
	                        // Casier 2 : ouvrir le servomoteur 2
							servoh.openServo(s2, 0);
							d.FlashesGreenLed(1);
	                        std::this_thread::sleep_for(std::chrono::milliseconds(1000));  // Pause de 1000 ms
							servoh.closeServo(servopos.servo2, s2);     // Fermer le servo
							d.RedLed(1);
	                    }
						else if (casierId == 3) {
							// Casier 3 : ouvrir le servomoteur 3
							servoh.openServo(s3, 1000);
							d.FlashesGreenLed(2);
							std::this_thread::sleep_for(std::chrono::milliseconds(1000));  // Pause de 1000 ms
							servoh.closeServo(servopos.servo3, s3);     // Fermer le servo
							d.RedLed(2);
						}
						else if (casierId == 4) {
							// Casier 4 : ouvrir le servomoteur 4
							servoh.openServo(s4, 1000);
							d.FlashesGreenLed(3);
							std::this_thread::sleep_for(std::chrono::milliseconds(1000));  // Pause de 1000 ms
							servoh.closeServo(servopos.servo4, s4);     // Fermer le servo
							d.RedLed(3);
							std::this_thread::sleep_for(std::chrono::seconds(5));
						}
	                }
	            
	                }
	                else {
	                    // Badge non enregistré
	                    cout << "Badge non enregistré !" << endl;
	
						servoh.openRfidServo(servopos.servo0, s0, 3000);
						std::this_thread::sleep_for(std::chrono::milliseconds(1000));  // Pause de 1000 ms
						servoh.closeRfidServo(s0, 1000);
	
	                }
	            }
	        }
	
// Fermer la connexion série et la connexion GPIO
	servoh.closeConnection(VS);
	gpioTerminate();
	reader.closePort();
	dbManager.deconnexion();
	return 0;
}