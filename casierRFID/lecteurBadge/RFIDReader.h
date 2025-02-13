#ifndef RFIDREADER_H
#define RFIDREADER_H

#include <iostream>
#include <string>
#include "serialib.h"

class RFIDReader {
private:
    serialib serial;
    std::string portUSB;

public:
    RFIDReader(const std::string& port);
    bool openPort(int baudRate = 9600);
    std::string readBadge();
    void closePort();
};

#endif // RFIDREADER_H
