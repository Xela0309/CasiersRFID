#include <iostream>
#include <vector>

#include <string>
#include <cstdlib>
#include <cstdint>      // type int8_t, int16_t, uint8_t, etc...
#include "serialib.h"
#include <fstream>
#include <sstream>
#include <thread>
#include <chrono>

using namespace std;

enum class HERKULEX_ROM_REGISTERS : std::uint8_t {
    ROM_MIN_POSITION = 26,
    ROM_MAX_POSITION = 28,
    ROM_ID = 6
};

enum class HERKULEX_BAUD_RATE : std::uint8_t {
    BD666666 = 0x02,
    BD500000 = 0x03,
    BD400000 = 0x04,
    BD250000 = 0x07,
    BD200000 = 0x09,
    BD115200 = 0x10,
    BD57600 = 0x22
};

enum class HERKULEX_TORQUE_VALUE : std::uint8_t {
    TORQUE_FREE = 0x00,
    BREAK_ON = 0x40,
    TORQUE_ON = 0x60
};

enum class HERKULEX_CONTROL_MODE : std::uint8_t {
    POSITION = 0x00,
    VELOCITY
};

enum class HERKULEX_RAM_REGISTERS : std::uint8_t {
    RAM_TORQUE_CONTROL = 52,
    RAM_CURRENT_CONTROL_MODE = 56,
    RAM_CALIBRATED_POSITION = 58,
    RAM_VOLTAGE = 54

};

enum class HERKULEX_REGISTERS : std::uint8_t {
    RAM = 0,
    EEPROM
};

enum class HERKULEX_CMD : std::uint8_t {
    EEP_WRITE = 1,
    EEP_READ,
    RAM_WRITE,
    RAM_READ,
    I_JOG,
    STAT = 7
};

enum class HERKULEX_FRAME : std::uint8_t {
    HEADER1 = 0,
    HEADER2,
    LENTGH,
    PID,
    CMD,
    CRC1,
    CRC2
};

const uint16_t  HERKULEX_MID_POSITION = 512;
const uint8_t   DEFAULT_ID = 0xFD;
const uint8_t   HERKULEX_FRAME_HEADER1_VALUE = 0xFF;
const uint8_t   HERKULEX_FRAME_HEADER2_VALUE = 0xFF;
const uint8_t   HERKULEX_STATUS_FRAME_LENGHT = 7;
const int       HERKULEX_TIMEOUT = 100;
const uint8_t   MAX_ID = 0xFD;
const uint8_t   HERKULEX_EEPROM_RAM_WRITE_LENGHT = 9;
const uint8_t   HERKULEX_IJOG_MINIMUM_LENGHT = 12;
const uint8_t   HERKULEX_EEPROM_RAM_READ_LENGHT = 9;
const uint8_t   ONE_BYTE_REGISTER = 1;
const uint8_t   TWO_BYTE_REGISTER = 2;

class ServoH {
private:

    float servoCasiers;
    float servoRFID;
    float servoTest;

    serialib* VS;  // Objet de communication série
    uint8_t             id;
    vector<uint8_t>     frameToSend, frameRecv;
    int16_t             velocity;
    string              errorMessage;
    uint16_t            maxPosition;
    uint16_t            minPosition;
    HERKULEX_CONTROL_MODE controlMode;
    HERKULEX_BAUD_RATE    baudSpeed;
    uint16_t            position;
    uint8_t             playtime;
    HERKULEX_TORQUE_VALUE torque;

    bool            sendSimpleIJOGData(HERKULEX_CONTROL_MODE mode, uint16_t position, uint8_t playtime = 60);
    bool            writeEEPROM(HERKULEX_ROM_REGISTERS startReg, vector<uint8_t> data);
    bool            writeRegs(HERKULEX_REGISTERS memType, uint8_t address, vector<uint8_t> data);
    static  uint8_t calcCRC1(vector<uint8_t> frame);
    static  uint8_t calcCRC2(vector<uint8_t> frame);
    bool            recvFrame(const int timeOut = HERKULEX_TIMEOUT);
    vector<uint8_t> readRAM(HERKULEX_RAM_REGISTERS startReg, uint8_t nbBytes);
    vector<uint8_t> readRegs(HERKULEX_REGISTERS memType, uint8_t address, uint8_t nbBytes);
    vector<uint8_t> readEEPROM(HERKULEX_ROM_REGISTERS startReg, uint8_t nbBytes);

public:

    struct ServoValuePos {

        int servo0;
        int servo1;
        int servo2;
        int servo3;
        int servo4;
        int servo5;
    };

    struct ServoValueVolt {

        int servo0;
        int servo1;
        int servo2;
        int servo3;
        int servo4;
        int servo5;
    };

    // Constructeur par défaut
    ServoH();
    ServoH(serialib* VS);/*: isConnected(false) {}*/
    ServoH(serialib* VS, uint8_t id);
    ~ServoH();

    //methodes utiles
    void scanServos(serialib* VS);
    bool readStatusServo(uint16_t status, ServoH& s);
    bool openConnection(const std::string& port, int baudrate, serialib& VS);
    void closeConnection(serialib& VS);
    void openServo(ServoH& s, int temp_milli);
    void openServoTestVolt(ServoH& s, float& volt1, float& volt2, int degree, int temp_milli);
    void closeServoTestVolt(ServoH& s, float& volt1, float& volt2, int degree, int temp_milli);
    void changeID(uint8_t oldId, uint8_t newId, ServoH s);
    void closeServo(int degree, ServoH& s);
    void openRfidServo(int degree, ServoH& s, int temp_milli);
    void closeRfidServo(ServoH& s, int temp_milli);
    void stopServo(ServoH s, float typeServo);
    int convertPositionToDegree(int position, const int midPosition = 512);
    float getservoCasiers();
    float getservoRFID();
    float getservoTest();
    ServoValuePos readInfoServoPos();
    ServoValueVolt readInfoServoVolt();
    void changeTXT(float newval, string text, string oldid);



    //autres methodes
    bool init();
    bool getId() const;
    bool fixNewId(uint8_t oldId, uint8_t newId);
    bool fixPosition(uint16_t position, uint8_t playtime = 60);
    bool fixTorque(HERKULEX_TORQUE_VALUE torque);
    bool fixTorqueOn();
    bool fixTorqueOff();
    bool readControlMode(HERKULEX_CONTROL_MODE& mode);
    bool readStatus(uint16_t& statusValue);
    bool readPosition(uint16_t& position);
    bool readVoltage(float& voltage);

    bool readMinimumPosition(uint16_t& minPos);
    bool readMaximumPosition(uint16_t& maxPos);

    static bool scanBus(serialib* VS, vector<uint8_t>& idServo, uint8_t idMax = MAX_ID);
    bool fixDegree(float degree, uint8_t playtime = 60);
    bool writeRAM(HERKULEX_RAM_REGISTERS startReg, vector<uint8_t> data);
    bool sendFrame();

    string      getLastError();
};