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

static void TestSequence::relativize()
{
  int prevTime = 0;
  int diffTime = 0;
  for (int i = 0; i < SETTING_COUNT; i++)
  {
    diffTime = seqs[i].delayTime - prevTime;
    prevTime = seqs[i].delayTime;
    seqs[i].delayTime = diffTime;
  }
}

void TestSequence::printProcedure(int p, int state, int t)
{
  Serial.print("|");
  Serial.print(p);
  Serial.print("\t|");
  if (state == 1)
  {
    Serial.print(" ■ ");
  }
  else
  {
    Serial.print(" □ ");
  }
  Serial.print("\t|");
  Serial.print(t);
  Serial.println("\t|");
}

static void TestSequence::printSequences(int testcount)
{
  Serial.println("--------------------");
  Serial.println(testcount);
  Serial.println("--------------------");
  for (int i = 0; i < SETTING_COUNT; i++)
  {
    TestSequence::printProcedure(seqs[i].p.portNum, seqs[i].p.state, seqs[i].delayTime);
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
