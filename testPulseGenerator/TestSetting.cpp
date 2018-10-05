#include "TestSetting.h"

TestSetting testsetting[SETTING_COUNT] = {
    /* {PortSettins}, {TimeRange} */
    {{13, LOW, ACTIVE}, {100, 200, TYPE_RANDOM}},
    {{13, LOW, INACTIVE}, {300, 400, TYPE_INCREMENT}},
};
WorkSpace workspace[SETTING_COUNT] = {0};
