#ifndef __TEST_SEQUENCE_H__
#define __TEST_SEQUENCE_H__
#include "Common.h"
#include "TestSetting.h"

class TestSequence
{
private:
  static void printProcedure(int p, int state, int t);

public:
  Port p;
  int delayTime;
  static TestSequence toSequence(TestSetting setting, WorkSpace *work);
  static void sort();
  static void relativize();
  static void printSequences(int testcount);
  TestSequence() : p({0, 0, 0}), delayTime(0)
  {
  }
  TestSequence(Port _p, int _d) : p(_p), delayTime(_d)
  {
  }
  TestSequence(const TestSequence &ts) : p(ts.p), delayTime(ts.delayTime)
  {
  }
};

extern TestSequence seqs[];
#endif
