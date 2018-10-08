#ifndef __CONTROLLER_H__
#define __CONTROLLER_H__
#define STATE_IDLE (0)
#define STATE_RUNNING (1)

#define STX ('S')
#define ETX ('E')
#define EOT ('E')
#define CAN ('C')

class Controller
{
  private:
    int testState;
    int testCount;
    void performOnIdle();
    void performOnRunning();
    void setupTest();

  public:
    void init();
    void perform();
    void transit(int state);
};

#endif