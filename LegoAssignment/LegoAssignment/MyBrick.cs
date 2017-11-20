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
        ColourSensor sensor = new ColourSensor();
        float distanceSIV;

        public async Task brickConnect()
        {
            await brick.ConnectAsync();

            await brick.DirectCommand.PlayToneAsync(50, 15, 666);
        }

        private void OnBrickChangedBlueRed(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;

            if (distanceSIV > 7)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 50, 1000, false);
            }
            else
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 0, 1000, false);
                sensor.baseBRCheck(sender, e, brick);
            }
        }

        public void BaseBlueRed()
        {
             brick.BrickChanged += OnBrickChangedBlueRed;
        }
    }
}
