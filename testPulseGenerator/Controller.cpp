#include "Controller.h"
#include "TestSequence.h"
#include "TestSetting.h"

void Controller::init()
{
    testState = STATE_IDLE;
    for (int i = 0; i < SETTING_COUNT; i++)
    {
        pinMode(testsetting[i].p.portNum, OUTPUT);
    }
    randomSeed(analogRead(0));
    Serial.setTimeout(500);
    Serial.begin(115200);
    Serial.println("Initialized");
}

void Controller::setupTest()
{
    testCount = 0;
    Serial.println("start Test.");
}

void Controller::perform()
{
    switch (testState)
    {
    case STATE_IDLE:
        performOnIdle();
        break;
    case STATE_RUNNING:
        performOnRunning();
        if (TEST_COUNT != 0 &&
            testCount > TEST_COUNT)
        {
            transit(ETX);
        }
        break;
    }
}

void Controller::transit(int state)
{
    switch (state)
    {
    case STX:
        testState = STATE_RUNNING;
        setupTest();
        break;
    case CAN:
        testState = STATE_IDLE;
        Serial.write(EOT);
        break;
    case ETX:
        testState = STATE_IDLE;
        Serial.write(ETX);
        break;
    }
}

void Controller::performOnIdle()
{
}

void Controller::performOnRunning()
{
    for (int i = 0; i < SETTING_COUNT; i++)
    {
        seqs[i] = TestSequence::toSequence(testsetting[i], &workspace[i]);
    }
    TestSequence::sort();
    TestSequence::relativize();
    TestSequence::printSequences(testCount);
    for (int i = 0; i < SETTING_COUNT; i++)
    {
        delay(seqs[i].delayTime);
        digitalWrite(seqs[i].p.portNum, seqs[i].p.state);
    }
    testCount++;
}
