#include "TestSetting.h"
#include "TestSequence.h"

int testcount;

void setup()
{
  // put your setup code here, to run once:
  for (int i = 0; i < SETTING_COUNT; i++)
  {
    pinMode(testsetting[i].p.portNum, OUTPUT);
  }
  randomSeed(analogRead(0));
  Serial.begin(115200);
  Serial.print("Initialized\n");
  testcount = 0;
}

void loop()
{
  // put your main code here, to run repeatedly:
  /* Create test sequence */
  for (int i = 0; i < SETTING_COUNT; i++)
  {
    seqs[i] = TestSequence::toSequence(testsetting[i], &workspace[i]);
  }
  TestSequence::sort();
  TestSequence::relativize();
  TestSequence::printSequences(testcount);
  for (int i = 0; i < SETTING_COUNT; i++)
  {
    delay(seqs[i].delayTime);
    digitalWrite(seqs[i].p.portNum, seqs[i].p.state);
  }
  delay(3000);
  testcount++;
}
