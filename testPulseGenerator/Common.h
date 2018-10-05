#ifndef __COMMON_H_
#define __COMMON_H_
#include "Arduino.h"

#define TYPE_FIX (0)
#define TYPE_INCREMENT (1)
#define TYPE_RANDOM (2)

#define INACTIVE (0)
#define ACTIVE (1)

typedef struct _TimeRange
{
  int minVal;
  int maxVal;
  int type;
} TimeRange;

class Port
{
public:
  int portNum;
  int activeLevel;
  int state;
  Port() : portNum(0), activeLevel(LOW), state(INACTIVE)
  {
  }
  Port(int _p, int _al, int _st) : portNum(_p), activeLevel(_al), state(_st)
  {
  }
  Port(const Port &p) : portNum(p.portNum), activeLevel(p.activeLevel), state(p.state)
  {
  }
};

#endif
