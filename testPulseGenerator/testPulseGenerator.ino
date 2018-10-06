#include "TestSetting.h"
#include "TestSequence.h"
#include "Controller.h"

Controller ctrl;

void setup()
{
  ctrl.init();
}

void loop()
{
  byte ctrlCode[1];
  if (Serial.readBytes(ctrlCode, 1) != 0)
  {
    ctrl.transit(ctrlCode[0]);
  }
  ctrl.perform();
}
