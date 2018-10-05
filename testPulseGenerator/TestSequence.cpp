#include "Arduino.h"
#include "TestSequence.h"
#include <stdio.h>

TestSequence seqs[SETTING_COUNT];

static TestSequence TestSequence::toSequence(TestSetting setting)
{
  TestSequence sequence;
  sequence.p = setting.p;
  sequence.delayTime = random(setting.range.minVal, setting.range.maxVal);
  return sequence;
}

bool TestSequence::operator<(const TestSequence &rhs) const
{
  return delayTime < rhs.delayTime;
}

bool TestSequence::operator>(const TestSequence &rhs) const
{
  return delayTime > rhs.delayTime;
}

bool TestSequence::operator<=(const TestSequence &rhs) const
{
  return delayTime <= rhs.delayTime;
}

bool TestSequence::operator>=(const TestSequence &rhs) const
{
  return delayTime >= rhs.delayTime;
}
