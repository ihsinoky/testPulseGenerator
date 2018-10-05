#include "Arduino.h"
#include "TestSequence.h"

TestSequence seqs[SETTING_COUNT];

static TestSequence TestSequence::toSequence(TestSetting setting, WorkSpace *work)
{
  TestSequence sequence;
  sequence.p = setting.p;
  switch (setting.range.type)
  {
  case TYPE_FIX:
    sequence.delayTime = setting.range.maxVal;
    break;
  case TYPE_RANDOM:
    sequence.delayTime = random(setting.range.minVal, setting.range.maxVal);
    break;
  case TYPE_INCREMENT:
    if (work->prevTime == 0 ||
        work->prevTime == setting.range.maxVal)
    {
      sequence.delayTime = setting.range.minVal;
    }
    else
    {
      sequence.delayTime = work->prevTime + 1;
    }
    work->prevTime = sequence.delayTime;
    break;
  }
  return sequence;
}

static void TestSequence::sort()
{
  TestSequence tmp;
  for (int i = 0; i < SETTING_COUNT; i++)
  {
    for (int j = 0; j < SETTING_COUNT - 1 - i; j++)
    {
      if (seqs[j].delayTime > seqs[j + 1].delayTime)
      {
        tmp = seqs[j];
        seqs[j] = seqs[j + 1];
        seqs[j + 1] = tmp;
      }
    }
  }
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
