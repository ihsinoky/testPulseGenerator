#ifndef __TEST_SETTING_H__
#define __TEST_SETTING_H__
#include "Common.h"

#define SETTING_COUNT (4)

typedef struct _TestSetting
{
  Port p;
  TimeRange range;
} TestSetting;

typedef struct _WorkSpace
{
  int prevTime;
} WorkSpace;

extern const int TEST_COUNT;
extern TestSetting testsetting[];
extern WorkSpace workspace[];

#endif
