#include "servo_class.h"

ServoH::ServoH(serialib* VS, uint8_t id) {
    this->VS = VS;
    this->servoCasiers = 0;
    this->servoRFID = 0;
    this->baudSpeed = HERKULEX_BAUD_RATE::BD115200;
    this->controlMode = HERKULEX_CONTROL_MODE::POSITION;
    if (id > MAX_ID)
        this->id = MAX_ID;
    else
        this->id = id;
    this->playtime = 60;
    this->position = HERKULEX_MID_POSITION;
    this->velocity = 0;
    this->torque = HERKULEX_TORQUE_VALUE::TORQUE_FREE;
    this->errorMessage = "";
}

ServoH::ServoH()
{
    ServoValuePos servopos;
    ServoValueVolt servovolt;

    this->servoCasiers = 0;
    this->servoRFID = 0;
}

ServoH::ServoH(serialib* VS)
{
    this->VS = VS;
}

ServoH::~ServoH()
{

}

void ServoH::scanServos(serialib* VS)
{
    std::vector<uint8_t> servosOnBus;
    if (ServoH::scanBus(VS, servosOnBus, 20)) {
        for (uint8_t i = 0; i < servosOnBus.size(); i++) {
            std::cout << "Id servo : " << static_cast<int>(servosOnBus.at(i)) << std::endl;
        }
    }
}

bool ServoH::readStatusServo(uint16_t status, ServoH& s)
{
    if (!s.readStatus(status)) {
        cout << "Erreur" << s.getLastError() << endl;
        return -1;
    }
    else {
        cout << "Status : " << status << endl;
    }

    if (s.readStatus(status)) {
        cout << "status F : " << hex << (status >> 8) << endl;
        cout << "status f : " << hex << static_cast<int>(status & 0x00FF) << endl;
    }
}

bool ServoH::openConnection(const std::string& port, int baudrate, serialib& VS)
{
    int codeRetour = VS.openDevice(port.c_str(), baudrate);
    if (codeRetour != 1) {
        std::cout << "Erreur à l'ouverture du port série." << std::endl;
        return false;
    }
    return true;
}

void ServoH::closeConnection(serialib& VS)
{
    VS.closeDevice();
}

void ServoH::openServo(ServoH& s, int temp_milli)
{
    float servoCasiers = 0;

    servoCasiers = getservoCasiers();
    s.init();
    s.fixTorqueOn();
    s.fixDegree(0);
    s.stopServo(s, servoCasiers);
    std::this_thread::sleep_for(std::chrono::milliseconds(temp_milli));
}

void ServoH::closeServo(int degree, ServoH& s)
{
    float servoCasiers = 0;
    servoCasiers = getservoCasiers();
    s.fixTorqueOn();
    s.fixDegree(degree);
    s.stopServo(s, servoCasiers);
    std::this_thread::sleep_for(std::chrono::milliseconds(1000));
}

void ServoH::openServoTestVolt(ServoH& s, float& lastVolt, float& minVolt, int degree, int temp_milli)
{
    s.init();
    s.fixTorqueOn();
    s.fixDegree(degree);

    for (int j = 0; j < 20; j++) {
        s.readVoltage(lastVolt);

        if (lastVolt < minVolt) {
            minVolt = lastVolt;
        }

        /*cout << "[open] volt lu : " << lastVolt << " | tension min : " << minVolt << endl;*/
    }

    std::this_thread::sleep_for(std::chrono::milliseconds(temp_milli));
}

void ServoH::closeServoTestVolt(ServoH& s, float& lastVolt, float& minVolt, int degree, int temp_milli)
{
    s.fixTorqueOn();
    s.fixDegree(degree);

    minVolt = std::numeric_limits<float>::max(); // Réinitialise la valeur minimale

    for (int j = 0; j < 20; j++) {
        s.readVoltage(lastVolt);

        if (lastVolt < minVolt) {
            minVolt = lastVolt;
        }

        /*cout << "[close] volt lu : " << lastVolt << " | tension min : " << minVolt << endl;*/
    }

    std::this_thread::sleep_for(std::chrono::milliseconds(temp_milli));
}

void ServoH::changeID(uint8_t oldId, uint8_t newId, ServoH s)
{

    // Tente de changer l'ID
    if (s.fixNewId(oldId, newId)) {
        std::cout << "L'ID du servomoteur est modifié de " << static_cast<int>(oldId)
            << " a " << static_cast<int>(newId) << std::endl;
    }
    else {
        std::cout << "Erreur lors du changement d'ID : " << s.getLastError() << std::endl;
    }
}

void ServoH::openRfidServo(int degree, ServoH& s, int temp_milli)
{
    float servoRFID = 0;

    servoRFID = getservoRFID();

    s.init();
    s.fixTorqueOn();
    s.fixDegree(degree);
    s.stopServo(s, servoRFID);
    std::this_thread::sleep_for(std::chrono::milliseconds(temp_milli));
}

void ServoH::closeRfidServo(ServoH& s, int temp_milli)
{
    float servoRFID = 0;

    servoRFID = getservoRFID();
    s.fixDegree(0);
    s.stopServo(s, servoRFID);
    std::this_thread::sleep_for(std::chrono::milliseconds(temp_milli));
}

int ServoH::convertPositionToDegree(int position, const int midPosition)
{
    return (position - midPosition) * 0.325f;
}

float ServoH::getservoCasiers()
{
    return this->servoCasiers;
}

float ServoH::getservoRFID()
{
    return this->servoRFID;
}

float ServoH::getservoTest()
{
    return this->servoTest;
}

ServoH::ServoValuePos ServoH::readInfoServoPos()

{
    const string filePath = "../../../fichiers/position_servo.txt";
    std::ifstream file(filePath);
    std::vector<int> valuespos;

    ServoValuePos resultpos = { 0, 0, 0, 0, 0 };

    if (!file.is_open()) {
        std::cerr << "Erreur d'ouverture du fichier : " << filePath << std::endl;
        return resultpos; // Retourne un vecteur vide en cas d'erreur
    }

    std::string line;
    while (std::getline(file, line)) {
        std::istringstream iss(line);
        std::string word1, servoName, colon;
        float value;
        int res_val;

        iss >> word1 >> servoName >> colon >> value;

        // Si la ligne suit le bon format
        if ((word1 == "closeID" || word1 == "openID") && colon == ":" && !servoName.empty()) {
            int res_val = value;
            valuespos.push_back(res_val);
        }
        else std::cerr << "Ligne ignorée (format incorrect) : " << line << std::endl;
    }

    file.close();

    for (size_t i = 0; i < valuespos.size(); ++i) {
        switch (i) {
        case 0: resultpos.servo0 = valuespos[i]; break;
        case 1: resultpos.servo1 = valuespos[i]; break;
        case 2: resultpos.servo2 = valuespos[i]; break;
        case 3: resultpos.servo3 = valuespos[i]; break;
        case 4: resultpos.servo4 = valuespos[i]; break;
        case 5: resultpos.servo5 = valuespos[i]; break;
        }
    }

    cout << "Positions des servos :" << endl;
    for (size_t i = 0; i < valuespos.size(); ++i) {
        std::cout << "Servo " << (i) << " = " << valuespos[i] << std::endl;
    }
    return resultpos;
}

ServoH::ServoValueVolt ServoH::readInfoServoVolt()
{
    const string filePath = "../../../fichiers/position_servo.txt";
    std::ifstream file(filePath);
    std::vector<int> valuesvolt;

    ServoValueVolt resultvolt = { 0, 0, 0, 0, 0 };

    if (!file.is_open()) {
        std::cerr << "Erreur d'ouverture du fichier : " << filePath << std::endl;
        return resultvolt; // Retourne un vecteur vide en cas d'erreur
    }

    std::string line;
    while (std::getline(file, line)) {
        std::istringstream iss(line);
        std::string word1, servoName, colon;
        float value;
        int res_val;

        iss >> word1 >> servoName >> colon >> value;

        // Si la ligne suit le bon format
        if (word1 == "voltID" && colon == ":" && !servoName.empty()) {
            int res_val = value;
            valuesvolt.push_back(res_val);
        }
        else std::cerr << "Ligne ignorée (format incorrect) : " << line << std::endl;
    }

    file.close();

    for (size_t i = 0; i < valuesvolt.size(); ++i) {
        switch (i) {
        case 0: resultvolt.servo0 = valuesvolt[i]; break;
        case 1: resultvolt.servo1 = valuesvolt[i]; break;
        case 2: resultvolt.servo2 = valuesvolt[i]; break;
        case 3: resultvolt.servo3 = valuesvolt[i]; break;
        case 4: resultvolt.servo4 = valuesvolt[i]; break;
        case 5: resultvolt.servo5 = valuesvolt[i]; break;
        }
    }

    cout << "Positions des servos :" << endl;
    for (size_t i = 0; i < valuesvolt.size(); ++i) {
        std::cout << "Servo " << (i) << " = " << valuesvolt[i] << std::endl;
    }
    return resultvolt;
}

void ServoH::changeTXT(float newval, string text, string id)
{
    std::string filename = "../../../fichiers/position_servo.txt";
    std::ifstream infile(filename);
    std::ofstream outfile("temp.txt");
    std::string line;
    float newServoCasiersVolt = 12; //Nouvelle valeur à définir

    if (!infile || !outfile) {
        std::cerr << "Erreur lors de l'ouverture du fichier." << std::endl;
    }

    while (std::getline(infile, line)) {
        std::istringstream iss(line);
        std::string word1, servoName, colon, value;

        iss >> word1 >> servoName >> colon >> value;

        try {
            if (word1 == text && servoName == id) {
                outfile << word1 << " " << servoName << " " << colon << " " << newval << std::endl;
            }
            else if (word1 == text && servoName == id) {
                outfile << word1 << " " << servoName << " " << colon << " " << newval << std::endl;
            }
            else if (word1 == text && servoName == id) {
                outfile << word1 << " " << servoName << " " << colon << " " << newval << std::endl;
            }
            else if (text == "changeID" && servoName == id) {
                string num = to_string(newval);
                outfile << word1 << " " << num << " " << colon << " " << value << std::endl;
            }
            else {
                outfile << line << std::endl;
            }
        }
        catch (const std::exception& e) {
            std::cerr << "L'ID n'existe pas dans le fichier ! Aucune modification. " << line << "\n"
                << "Exception : " << e.what() << std::endl;
            outfile << line << std::endl;
        }
        std::cout << line << std::endl;
    }

    infile.close();
    outfile.close();

    // Remplace le fichier original
    std::remove(filename.c_str());
    std::rename("temp.txt", filename.c_str());

    std::cout << "Modification terminée." << std::endl;
}


void ServoH::stopServo(ServoH s, float typeServo)
{
    float voltage = 0;
    uint16_t pos;
    int degree;

    for (int j = 0; j < 20; j++) {
        s.readVoltage(voltage);
        if (voltage < typeServo) {
            s.readPosition(pos);
            degree = convertPositionToDegree(pos);
            s.fixTorqueOff();
            cout << "voltage : " << voltage << endl;
            cout << "position : " << pos << endl;
            cout << "degree : " << degree << endl;
            break;  // Quitter la boucle actuelle
        }
        else {
            cout << "voltage : " << voltage << endl;
        }
    }
}

bool ServoH::sendSimpleIJOGData(HERKULEX_CONTROL_MODE mode, uint16_t position, uint8_t playtime)
{
    frameToSend.clear();
    frameToSend.push_back(HERKULEX_FRAME_HEADER1_VALUE);
    frameToSend.push_back(HERKULEX_FRAME_HEADER2_VALUE);
    frameToSend.push_back(HERKULEX_IJOG_MINIMUM_LENGHT);
    frameToSend.push_back(this->id);
    frameToSend.push_back(static_cast<uint8_t>(HERKULEX_CMD::I_JOG));
    frameToSend.push_back(0);
    frameToSend.push_back(0);
    frameToSend.push_back(static_cast<uint8_t>(position & 0x00FF));
    frameToSend.push_back(static_cast<uint8_t>((position & 0xFF00) >> 8));
    // ne fonctionne pas si je mets la ligne suivante donc je force à 0 pour passer en mode position
    //uint8_t byteSet = ((getLeds()<<2) | (static_cast<uint8_t>(HERKULEX_CONTROL_MODE::POSITION)<<1));
    if (mode == HERKULEX_CONTROL_MODE::POSITION)
        frameToSend.push_back(0);
    else
        frameToSend.push_back(2);
    frameToSend.push_back(this->id);
    frameToSend.push_back(playtime);
    frameToSend.at(static_cast<int>(HERKULEX_FRAME::CRC1)) = calcCRC1(frameToSend);
    frameToSend.at(static_cast<int>(HERKULEX_FRAME::CRC2)) = calcCRC2(frameToSend);

    if (!sendFrame()) {
        errorMessage += "\nError sending simple I_JOG command\n";
        return false;
    }
    return true;
}

bool ServoH::writeEEPROM(HERKULEX_ROM_REGISTERS startReg, vector<uint8_t> data)
{
    return writeRegs(HERKULEX_REGISTERS::EEPROM, static_cast<uint8_t>(startReg), data);
}

bool ServoH::writeRegs(HERKULEX_REGISTERS memType, uint8_t address, vector<uint8_t> data)
{
    frameToSend.push_back(HERKULEX_FRAME_HEADER1_VALUE);
    frameToSend.push_back(HERKULEX_FRAME_HEADER2_VALUE);
    frameToSend.push_back(HERKULEX_EEPROM_RAM_WRITE_LENGHT + data.size());
    frameToSend.push_back(this->id);
    if (memType == HERKULEX_REGISTERS::EEPROM)
        frameToSend.push_back(static_cast<uint8_t>(HERKULEX_CMD::EEP_WRITE));
    else
        frameToSend.push_back(static_cast<uint8_t>(HERKULEX_CMD::RAM_WRITE));
    frameToSend.push_back(0);
    frameToSend.push_back(0);
    frameToSend.push_back(address);
    frameToSend.push_back(data.size());
    for (uint8_t i = 0; i < data.size(); i++) frameToSend.push_back(data.at(i));
    frameToSend.at(static_cast<int>(HERKULEX_FRAME::CRC1)) = calcCRC1(frameToSend);
    frameToSend.at(static_cast<int>(HERKULEX_FRAME::CRC2)) = calcCRC2(frameToSend);

    //printFrameToSend();
    if (!sendFrame()) {
        errorMessage += "\nError while sending frame for writing EEPROM/RAM registers";
        return false;
    }
    return true;
}

uint8_t     ServoH::calcCRC1(vector<uint8_t> frame) {
    uint8_t     CRC1 = 0;

    for (unsigned int i = static_cast<int>(HERKULEX_FRAME::LENTGH); i < frame.size(); i++) {
        switch (i) {
        case static_cast<int>(HERKULEX_FRAME::CRC1):
        case static_cast<int>(HERKULEX_FRAME::CRC2):
            break;
        default:
            CRC1 ^= frame.at(i);
        }
    }
    CRC1 = CRC1 & 0xFE;
    return CRC1;
}

uint8_t     ServoH::calcCRC2(vector<uint8_t> frame) {
    return (~calcCRC1(frame) & 0xFE);
}

bool ServoH::init()
{
    if (!readMaximumPosition(this->maxPosition)) return false;
    if (!readMinimumPosition(this->minPosition)) return false;
    if (!readControlMode(this->controlMode)) return false;
    if (!readPosition(this->position)) return false;

    return true;
}

bool ServoH::getId() const
{
    return this->id;
}

bool ServoH::fixNewId(uint8_t oldId, uint8_t newId)
{
    vector<uint8_t> data;
    bool state;

    if (oldId != this->id) {
        this->errorMessage += "\nWrong actual id";
        return false;
    }

    if (newId > MAX_ID) {
        this->errorMessage += "\nNew servo id too large (>253)";
        return false;
    }

    this->frameToSend.clear();
    data.push_back(newId);
    state = writeEEPROM(HERKULEX_ROM_REGISTERS::ROM_ID, data);
    if (state) this->id = newId;

    return state;

}

bool ServoH::fixPosition(uint16_t position, uint8_t playtime)
{
    HERKULEX_CONTROL_MODE mode;

    if (!readControlMode(mode))
        return false;

    if (mode != HERKULEX_CONTROL_MODE::POSITION) {
        errorMessage += "\nCan't set position when servo is in velocity mode";
        return false;
    }

    if (position < this->minPosition || position > this->maxPosition) {
        this->errorMessage += "\nPosition must be between " + to_string(minPosition) +
            " and " + to_string(maxPosition) + "\n";
        return false;
    }

    if (!sendSimpleIJOGData(mode, position, playtime)) {
        errorMessage += "Can\'t change servo position";
        return false;
    }

    this->position = position;
    this->playtime = playtime;

    return true;
}

bool ServoH::recvFrame(const int timeOut) {
    char car;
    int result;

    frameRecv.clear();

    do {
        // lecture d'un caractère sur la voie série avec timeout
        result = VS->readChar(&car, timeOut);
        // on rajoute le caractère recu dans le vecteur si on est pas en timeout
        if (result != 0) frameRecv.push_back(car);
    } while (result != 0);

    if (result == 0 && frameRecv.empty()) {
        HERKULEX_CMD cmdSend;
        cmdSend = static_cast<HERKULEX_CMD>(frameToSend.at(static_cast<int>(HERKULEX_FRAME::CMD)));
        if (cmdSend == HERKULEX_CMD::EEP_WRITE ||
            cmdSend == HERKULEX_CMD::RAM_WRITE)
            return true;
        else
            errorMessage += "\nNo response from servo";
        return false;
    }

    if (frameRecv.at(static_cast<int>(HERKULEX_FRAME::HEADER1)) != HERKULEX_FRAME_HEADER1_VALUE ||
        frameRecv.at(static_cast<int>(HERKULEX_FRAME::HEADER2)) != HERKULEX_FRAME_HEADER2_VALUE) {
        errorMessage += "\nReceived frame header error";
        return false;
    }

    if (frameRecv.at(static_cast<int>(HERKULEX_FRAME::LENTGH)) != frameRecv.size()) {
        errorMessage += "\nReceived frame size error";
        return false;
    }

    if (calcCRC1(frameRecv) != frameRecv.at(static_cast<int>(HERKULEX_FRAME::CRC1))) {
        errorMessage += "\nReceived frame CRC1 error";
        return false;
    }

    if (calcCRC2(frameRecv) != frameRecv.at(static_cast<int>(HERKULEX_FRAME::CRC2))) {
        errorMessage += "\nReceived frame CRC2 error";
        return false;
    }

    return true;
}

vector<uint8_t> ServoH::readRAM(HERKULEX_RAM_REGISTERS startReg, uint8_t nbBytes)
{
    return readRegs(HERKULEX_REGISTERS::RAM, static_cast<uint8_t>(startReg), nbBytes);
}

vector<uint8_t> ServoH::readRegs(HERKULEX_REGISTERS memType, uint8_t address, uint8_t nbBytes)
{
    vector<uint8_t> reg;

    frameToSend.push_back(HERKULEX_FRAME_HEADER1_VALUE);
    frameToSend.push_back(HERKULEX_FRAME_HEADER2_VALUE);
    frameToSend.push_back(HERKULEX_EEPROM_RAM_READ_LENGHT);
    frameToSend.push_back(this->id);
    if (memType == HERKULEX_REGISTERS::EEPROM)
        frameToSend.push_back(static_cast<uint8_t>(HERKULEX_CMD::EEP_READ));
    else
        frameToSend.push_back(static_cast<uint8_t>(HERKULEX_CMD::RAM_READ));
    frameToSend.push_back(0);
    frameToSend.push_back(0);
    frameToSend.push_back(address);
    frameToSend.push_back(nbBytes);
    frameToSend.at(static_cast<int>(HERKULEX_FRAME::CRC1)) = calcCRC1(frameToSend);
    frameToSend.at(static_cast<int>(HERKULEX_FRAME::CRC2)) = calcCRC2(frameToSend);

    if (!sendFrame()) {
        errorMessage += "\nError while sending frame for reading EEPROM/RAM registers";
        return reg;
    }

    if (!recvFrame()) {
        errorMessage += "\nError while receiving frame after reading EEPROM/RAM registers";
        return reg;
    };

    for (uint8_t i = 9; i < 9 + nbBytes; i++) reg.push_back(frameRecv.at(i));
    return reg;
}

vector<uint8_t> ServoH::readEEPROM(HERKULEX_ROM_REGISTERS startReg, uint8_t nbBytes)
{
    return readRegs(HERKULEX_REGISTERS::EEPROM, static_cast<uint8_t>(startReg), nbBytes);
}

bool ServoH::fixTorque(HERKULEX_TORQUE_VALUE torque) {
    vector<uint8_t> data;
    bool state;

    this->frameToSend.clear();
    data.push_back(static_cast<uint8_t>(torque));
    state = writeRAM(HERKULEX_RAM_REGISTERS::RAM_TORQUE_CONTROL, data);
    if (!state)
        this->errorMessage += "Can\'t change torque\n";
    else
        this->torque = torque;

    return state;
}

bool ServoH::fixTorqueOn()
{
    return fixTorque(HERKULEX_TORQUE_VALUE::TORQUE_ON);
}

bool ServoH::fixTorqueOff() {
    return fixTorque(HERKULEX_TORQUE_VALUE::TORQUE_FREE);
}

bool ServoH::readControlMode(HERKULEX_CONTROL_MODE& mode)
{
    vector<uint8_t> response;

    frameToSend.clear();
    response = readRAM(HERKULEX_RAM_REGISTERS::RAM_CURRENT_CONTROL_MODE, ONE_BYTE_REGISTER);

    if (response.size() == ONE_BYTE_REGISTER) {
        mode = static_cast<HERKULEX_CONTROL_MODE>(response.at(0));
        return true;
    }
    else {
        errorMessage += "\nError reading current control mode";
        return false;
    }
}

bool ServoH::readStatus(uint16_t& statusValue)
{
    frameToSend.clear();
    frameToSend.push_back(HERKULEX_FRAME_HEADER1_VALUE);
    frameToSend.push_back(HERKULEX_FRAME_HEADER2_VALUE);
    frameToSend.push_back(HERKULEX_STATUS_FRAME_LENGHT);
    frameToSend.push_back(this->id);
    frameToSend.push_back(static_cast<uint8_t>(HERKULEX_CMD::STAT));
    frameToSend.push_back(calcCRC1(frameToSend));
    frameToSend.push_back(calcCRC2(frameToSend));

    if (!sendFrame()) {
        errorMessage += "\nError getting STATUS\n";
        return false;
    }

    if (!recvFrame()) return false;

    statusValue = frameRecv.at(7) << 8 | frameRecv.at(8);
    return true;
}

bool ServoH::readPosition(uint16_t& position)
{
    vector<uint8_t> response;

    frameToSend.clear();
    response = readRAM(HERKULEX_RAM_REGISTERS::RAM_CALIBRATED_POSITION, TWO_BYTE_REGISTER);

    if (response.size() == TWO_BYTE_REGISTER) {
        uint16_t result = response.at(1) << 8 | response.at(0);
        // Masquage du resultat sur 10 bits (gamme 0-1023)
        position = result & 0x03FF;
        return true;
    }
    else {
        errorMessage += "\nError reading calibrated position";
        return false;
    }
}

bool ServoH::readVoltage(float& voltage) {
    vector<uint8_t> response;

    frameToSend.clear();
    response = readRAM(HERKULEX_RAM_REGISTERS::RAM_VOLTAGE, ONE_BYTE_REGISTER);

    if (response.size() == ONE_BYTE_REGISTER) {
        // le nombre 0.074 vient de la documentation page 29
        voltage = (static_cast<float>(response.at(0)) * 0.074);
        return true;
    }
    else {
        errorMessage += "\nError reading servo voltage";
        return false;
    }
}

bool ServoH::readMinimumPosition(uint16_t& minPos)
{
    vector<uint8_t> response;

    frameToSend.clear();
    response = readEEPROM(HERKULEX_ROM_REGISTERS::ROM_MIN_POSITION, TWO_BYTE_REGISTER);

    if (response.size() == TWO_BYTE_REGISTER) {
        minPos = response.at(1) << 8 | response.at(0);
        return true;
    }
    else {
        errorMessage += "\nError reading minimum servo position";
        return false;
    }
}

bool ServoH::readMaximumPosition(uint16_t& maxPos)
{
    vector<uint8_t> response;

    frameToSend.clear();
    response = readEEPROM(HERKULEX_ROM_REGISTERS::ROM_MAX_POSITION, TWO_BYTE_REGISTER);

    if (response.size() == TWO_BYTE_REGISTER) {
        maxPos = response.at(1) << 8 | response.at(0);
        return true;
    }
    else {
        errorMessage += "\nError reading maximum servo position";
        return false;
    }

}

bool ServoH::scanBus(serialib* VS, vector<uint8_t>& idServo, uint8_t idMax)
{
    vector<uint8_t> frame;
    vector<uint8_t> tempFrame;
    char car;

    frame.push_back(HERKULEX_FRAME_HEADER1_VALUE);
    frame.push_back(HERKULEX_FRAME_HEADER2_VALUE);
    frame.push_back(HERKULEX_STATUS_FRAME_LENGHT);
    frame.push_back(0); // id inconnu
    frame.push_back(static_cast<uint8_t>(HERKULEX_CMD::STAT));
    frame.push_back(0); // CRC1 non calcule
    frame.push_back(0); // CRC2 non calcule

    for (uint8_t i = 0; i <= idMax; i++) {
        frame.at(static_cast<int>(HERKULEX_FRAME::PID)) = i;
        frame.at(static_cast<int>(HERKULEX_FRAME::CRC1)) = calcCRC1(frame);
        frame.at(static_cast<int>(HERKULEX_FRAME::CRC2)) = calcCRC2(frame);
        int result = VS->writeBytes(frame.data(), frame.size());
        if (result < 0)
            return false;

        tempFrame.clear();
        do {
            // lecture d'un caractère sur la voie série avec timeout
            result = VS->readChar(&car, 100);
            // on rajoute le caractère recu dans le vecteur si on est pas en timeout
            if (result != 0) tempFrame.push_back(car);
        } while (result != 0);

        if (result == 0 && !tempFrame.empty()) idServo.push_back(i);
    }
    return true;
}

bool ServoH::fixDegree(float degree, uint8_t playtime)
{
    float minDegree = (this->minPosition - HERKULEX_MID_POSITION) * 0.325;
    float maxDegree = (this->maxPosition - HERKULEX_MID_POSITION) * 0.325;

    if (degree < minDegree || degree > maxDegree) {
        errorMessage += "\nDegree must be between " + to_string(minDegree) +
            " and " + to_string(maxDegree) + "\n";
        return false;
    }
    int position = static_cast<uint16_t>(HERKULEX_MID_POSITION + (degree / 0.325));
    return this->fixPosition(position, playtime);
}

bool ServoH::sendFrame()
{
    int result = VS->writeBytes(frameToSend.data(), frameToSend.size());
    if (result < 0) {
        errorMessage += "\nError writing on serial port";
        return false;
    }
    else
        return true;
}

string ServoH::getLastError()
{
    string tempErrorMessage = errorMessage;
    errorMessage = "No error";
    return tempErrorMessage;
}

bool ServoH::writeRAM(HERKULEX_RAM_REGISTERS startReg, vector<uint8_t> data) {
    return writeRegs(HERKULEX_REGISTERS::RAM, static_cast<uint8_t>(startReg), data);
}