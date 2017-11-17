using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoAssignment
{
    class MyBrick
    {
        Brick brick = new Brick(new UsbCommunication());
        float distanceSIV;

        public async Task brickConnect()
        {
            await brick.ConnectAsync();

            await brick.DirectCommand.PlayToneAsync(50, 15, 666);
        }

        private void OnBrickChangedTaskOne(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;

            if (distanceSIV > 20)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 40, 1000, true);
            }
            else if (distanceSIV <= 20)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 0, 1000, true);
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -100, 5000, true);
            }
        }

        public void taskOne()
        {
             brick.BrickChanged += OnBrickChangedTaskOne;
        }
    }
}
