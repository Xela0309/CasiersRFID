#include "RGBLED.h"

DelRGBChainable::DelRGBChainable(unsigned char clk_pin,
    unsigned char data_pin, unsigned char number_of_leds) :
    _clk_pin(clk_pin), _data_pin(data_pin), _num_leds(number_of_leds)
{
    gpioInitialise();
    gpioSetMode(_clk_pin, PI_OUTPUT);
    gpioSetMode(_data_pin, PI_OUTPUT);

    _led_state = new unsigned char[_num_leds * 3];

    for (unsigned char i = 0; i < _num_leds; i++)
        setColorRGB(i, 0, 0, 0);
}

DelRGBChainable::~DelRGBChainable() {
    delete[] _led_state;
    gpioTerminate();
}

int DelRGBChainable::initGpio() {
    if (gpioInitialise() < 0) {
        std::cerr << "Erreur d'initialisation de pigpio" << std::endl;
        return -1;
    }
}

void DelRGBChainable::clk(void) {
    gpioWrite(_clk_pin, 0);
    gpioDelay(_CLK_PULSE_DELAY);
    gpioWrite(_clk_pin, 1);
    gpioDelay(_CLK_PULSE_DELAY);
}

void DelRGBChainable::sendByte(unsigned char b) {
    // Send one bit at a time, starting with the MSB
    for (unsigned char i = 0; i < 8; i++) {
        // If MSB is 1, write one and clock it, else write 0 and clock
        if ((b & 0x80) != 0) {
            gpioWrite(_data_pin, 1);
        }
        else {
            gpioWrite(_data_pin, 0);
        }
        clk();

        // Advance to the next bit to send
        b <<= 1;
    }
}

void DelRGBChainable::sendColor(unsigned char red, unsigned char green, unsigned char blue) {
    // Start by sending a byte with the format "1 1 /B7 /B6 /G7 /G6 /R7 /R6"
    unsigned char prefix = 0xC0; // B11000000;
    if ((blue & 0x80) == 0) {
        prefix |= 0x20; // B00100000;
    }
    if ((blue & 0x40) == 0) {
        prefix |= 0x10; // B00010000;
    }
    if ((green & 0x80) == 0) {
        prefix |= 0x08; // B00001000;
    }
    if ((green & 0x40) == 0) {
        prefix |= 0x04; // B00000100;
    }
    if ((red & 0x80) == 0) {
        prefix |= 0x02; // B00000010;
    }
    if ((red & 0x40) == 0) {
        prefix |= 0x01; // B00000001;
    }
    sendByte(prefix);

    // Now must send the 3 colors
    sendByte(blue);
    sendByte(green);
    sendByte(red);
}

void DelRGBChainable::setColorRGB(unsigned char led, unsigned char red, unsigned char green, unsigned char blue) {
    // Send data frame prefix (32x "0")
    sendByte(0x00);
    sendByte(0x00);
    sendByte(0x00);
    sendByte(0x00);

    // Send color data for each one of the leds
    for (unsigned char i = 0; i < _num_leds; i++) {
        if (i == led) {
            _led_state[i * 3] = red;
            _led_state[i * 3 + 1] = green;
            _led_state[i * 3 + 2] = blue;
        }

        sendColor(_led_state[i * 3],
            _led_state[i * 3 + 1],
            _led_state[i * 3 + 2]);
    }
}

void DelRGBChainable::FlashesRedLed(unsigned char num_led) {
    for (int i = 0; i < 10; i++) {
        // Allumer la LED en rouge
        setColorRGB(num_led, 255, 0, 0);
        std::this_thread::sleep_for(std::chrono::milliseconds(100));

        // Éteindre la LED
        setColorRGB(num_led, 0, 0, 0);
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
    }
}

void DelRGBChainable::FlashesGreenLed(unsigned char num_led) {
    for (int i = 0; i < 10; i++) {
        // Allumer la LED en vert
        setColorRGB(num_led, 0, 255, 0);
        std::this_thread::sleep_for(std::chrono::milliseconds(100));

        // Éteindre la LED
        setColorRGB(num_led, 0, 0, 0);
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
    }
}


void DelRGBChainable::GreenLed(unsigned char num_led) {

    setColorRGB(num_led, 0, 255, 0);
}

void DelRGBChainable::RedLed(unsigned char num_led) {

    setColorRGB(num_led, 255, 0, 0);
}