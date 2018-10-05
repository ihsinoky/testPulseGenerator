#ifndef __TEST_SEQUENCE_H__
#define __TEST_SEQUENCE_H__
#include "Common.h"
#include "TestSetting.h"

class TestSequence
{
public:
  Port p;
  int delayTime;
  static TestSequence toSequence(TestSetting setting, WorkSpace *work);
  static void sort();
  TestSequence() : p({0, 0, 0}), delayTime(0)
  {
  }
  TestSequence(Port _p, int _d) : p(_p), delayTime(_d)
  {
  }
  TestSequence(const TestSequence &ts) : p(ts.p), delayTime(ts.delayTime)
  {
  }
  bool operator>(const TestSequence &rhs) const;
  bool operator<(const TestSequence &rhs) const;
  bool operator>=(const TestSequence &rhs) const;
  bool operator<=(const TestSequence &rhs) const;
};

extern TestSequence seqs[];
#endif
