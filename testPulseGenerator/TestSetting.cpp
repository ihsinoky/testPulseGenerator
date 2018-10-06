#include "TestSetting.h"

/* 0:Infinity */
const int TEST_COUNT = 10;

TestSetting testsetting[SETTING_COUNT] = {
    /* {PortSettins}, {TimeRange} */
    {{13, LOW, ACTIVE}, {100, 200, TYPE_RANDOM}},
    {{13, LOW, INACTIVE}, {300, 400, TYPE_INCREMENT}},
    {{11, LOW, ACTIVE}, {100, 200, TYPE_RANDOM}},
    {{11, LOW, INACTIVE}, {400, 400, TYPE_FIX}},
};
WorkSpace workspace[SETTING_COUNT] = {0};
