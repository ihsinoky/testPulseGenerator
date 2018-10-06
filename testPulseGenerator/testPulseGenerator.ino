#include "TestSetting.h"
#include "TestSequence.h"

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
}

void printProcedure(int p, int state, int time)
{
  Serial.print("|");
  Serial.print(p);
  Serial.print("\t|");
  if (state == 1)
  {
    Serial.print("Active  ");
  }
  else
  {
    Serial.print("Inactive");
  }
  Serial.print("\t|");
  Serial.print(time);
  Serial.println("\t|");
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
  for (int i = 0; i < SETTING_COUNT; i++)
  {
    printProcedure(seqs[i].p.portNum, seqs[i].p.state, seqs[i].delayTime);
    delay(seqs[i].delayTime);
    digitalWrite(seqs[i].p.portNum, seqs[i].p.state);
  }
  delay(3000);
}
