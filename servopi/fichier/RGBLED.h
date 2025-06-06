#include <iostream>
#include <pigpio.h>
#include <atomic>
#include <chrono>
#include <thread>
#include <chrono>
using namespace std;

#ifndef _DelRGBChainable_
#define _DelRGBChainable_


class DelRGBChainable
{

public:
    DelRGBChainable(unsigned char clk_pin, unsigned char  data_pin, unsigned char  number_of_leds);
    ~DelRGBChainable();

    int initGpio();
    void setColorRGB(unsigned char led, unsigned char  red, unsigned char  green, unsigned char  blue);
    void FlashesRedLed(unsigned char num_led);
    void FlashesGreenLed(unsigned char num_led);
    void GreenLed(unsigned char num_led);
    void RedLed(unsigned char num_led);

private:
    const unsigned int _CLK_PULSE_DELAY = 1;
    unsigned char _clk_pin;
    unsigned char _data_pin;
    unsigned char _num_leds;

    unsigned char* _led_state;

    void clk(void);
    void sendByte(unsigned char b);
    void sendColor(unsigned char red, unsigned char green, unsigned char blue);
};
#endif