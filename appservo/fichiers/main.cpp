#include <iostream>
#include <vector>
#include <string>
#include <cstdlib>
#include <cstdint>  // type int8_t, int16_t, uint8_t, etc...
#include <thread>   // Pour std::this_thread::sleep_for
#include <mutex>
#include <chrono>   // Pour std::chrono::milliseconds
#include <fstream>
#include <sstream>
#include <vector>

using namespace std;

#include "serialib.h"
#include "servo_class.h"


int main(int argc, char** argv) {
	//bite
	string pos, volt, modif;
	uint16_t status = 0;
	ServoH servoh;
	serialib VS;
	ServoH::ServoValuePos servopos;
	ServoH::ServoValueVolt servovolt;

	servopos = servoh.readInfoServoPos();
	servovolt = servoh.readInfoServoVolt();

	/*for (size_t i = 0; i < servoValues.size(); ++i) {
		std::cout << "Servo " << (i + 1) << " = " << servoValues[i] << std::endl;
	}*/

	cout << "Avant ouverture" << endl;


	if (!servoh.openConnection("/dev/ttyS0", 115200, VS)) {
		cerr << "Erreur d'ouverture de la connexion série." << endl;
		return -1;
	}

	cout << "Après ouverture" << endl;
	// Scanner les servos sur le bus
	cout << "<< Avant scan >>" << endl;
	/*servoh.scanServos(&VS);*/
	std::vector<uint8_t> servosOnBus;
	if (ServoH::scanBus(&VS, servosOnBus, 20)) {
		for (uint8_t i = 0; i < servosOnBus.size(); i++) {
			std::cout << "Id servo : " << static_cast<int>(servosOnBus.at(i)) << std::endl;
		}
	}
	else {
		cout << "Aucun servo trouvé sur le bus !" << endl;
	}
	cout << "<< Après scan >>" << endl;

	// Demander les ID à l'utilisateur
	bool exita = true;
	string option;
	string exits = "exit";
	while (exita == true) {
		servopos = servoh.readInfoServoPos();
		servovolt = servoh.readInfoServoVolt();
		cout << "choisissez une option : " << endl << "1. Modifier l'id du servomoteur"
			<< endl << "2. modifier la position des servomoteurs" << endl << "3. Modifier le voltes d'un servomoteur" << endl
			<< "4. Quitter" << endl;
		cout << "Entrer une option : ";
		cin >> option;

		if (option == "4") {
			exita = false;
			break;
		}
		else if (option == "1") {
			string text = "changID";
			bool exitb = true;
			int oldId, newId;
			while (exitb == true) {
				cout << "Entrez 'exit' pour quitter" << std::endl;
				cout << "Entrez l'ancien ID du servomoteur : ";
				cin >> option;
				if (option == exits) {
					exitb = false;
					break;
				}
				else {
					try {
						oldId = stoi(option);
					}
					catch (const std::invalid_argument& e) {
						std::cerr << "L'ancien ID doit etre un entier ou tapez 'exit' pour quitter !" << endl;
						continue;
					}

					bool idExists = false;
					for (uint8_t id : servosOnBus) {
						if (id == oldId) {
							idExists = true;
							break;
						}
					}

					if (!idExists) {
						std::cerr << "L'ancien ID n'existe pas ! Veuillez essayer un autre ID." << endl;
						continue;
					}
				}
				cout << "Entrez le nouveau ID du servomoteur : ";
				cin >> newId;

				ServoH s(&VS, oldId);
				string idservo = to_string(oldId);
				// Changer l'ID
				servoh.changeID(oldId, newId, s);
				servoh.changeTXT(newId, text, idservo);
				break;
			}

		}
		else if (option == "2") {
			string text = "closeID";
			for (uint8_t id : servosOnBus) {
				ServoH servo(&VS, id);
				uint16_t pos = 0;
				int serID = static_cast<int>(id);

				if (servo.readPosition(pos)) {
					float degree = servoh.convertPositionToDegree(pos);
					cout << "Servo ID " << serID
						<< " -> Position : " << pos
						<< " | Degrée : " << degree << "°" << endl;
					string idservo =  to_string(serID);
					servoh.changeTXT(degree, text, idservo);
				}
				else {
					cerr << "Erreur lecture servo ID " << static_cast<int>(id)
						<< " : " << servo.getLastError() << endl;
				}

			}
		}
		else if (option == "3") {
			int selectId;
			cout << "Entrez 'exit' pour quitter" << std::endl;
			cout << "Entrez l'ID du servomoteur a tester: ";
			cin >> option;
			if (option == exits) {
				exita = false;
				break;
			}
			else {
				try {

					selectId = stoi(option);
				}
				catch (const std::invalid_argument& e) {
					std::cerr << "L'ID doit etre un entier ou tapez 'exit' pour quitter !" << endl;
					continue;
				}

				bool idExists = false;
				for (uint8_t id : servosOnBus) {
					if (id == selectId) {
						idExists = true;
						break;
					}
				}

				if (!idExists) {
					std::cerr << "L'ID n'existe pas ! Veuillez essayer un autre ID." << endl;
					continue;
				}

				ServoH s(&VS, selectId);

				/*float voltMin = std::numeric_limits<float>::max();*/
				float voltLast = 0.0;
				float voltMin = 10.0;
				int servo_degree = 0;
				string text;
				string chaine;

				if (selectId == 0) {
					servo_degree = servopos.servo0;
					text = "voltID";
					chaine = "0";
				}
				else if (selectId == 1) {
					servo_degree = servopos.servo1;
					text = "voltID";
					chaine = "1";
				}
				else if (selectId == 2) {
					servo_degree = servopos.servo2;
					text = "voltID";
					chaine = "2";
				}
				else if (selectId == 3) {
					servo_degree = servopos.servo3;
					text = "voltID";
					chaine = "3";
				}
				else if (selectId == 4) {
					servo_degree = servopos.servo4;
					text = "voltID";
					chaine = "4";
				}
				else if (selectId == 5) {
					servo_degree = servopos.servo5;
					text = "voltID";
					chaine = "5";
				}

				cout << chaine << endl;

				servoh.openServoTestVolt(s, voltLast, voltMin, 0, 200);
				cout << "Tension minimale (open) : " << voltMin << endl;

				servoh.closeServoTestVolt(s, voltLast, voltMin, servo_degree, 200);
				cout << "Tension minimale (close) : " << voltMin << endl;

				servoh.changeTXT(voltMin, text, chaine);
			}
		}
		else {
			cout << "Entrer l'option 1, 2, 3 ou 4 !" << endl;
		}

	}

	servoh.closeConnection(VS);
	return 0;
}