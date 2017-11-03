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

        public async void Connect()
        {
            
            await brick.ConnectAsync();
            brick.BrickChanged += OnBrickChanged;

            await brick.DirectCommand.PlayToneAsync(50, 15, 666);

            
        }

        private void OnBrickChanged(object sender, BrickChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public async void Drive(object sender, BrickChangedEventArgs e)
        {
            float lightSIV = e.Ports[InputPort.Three].SIValue;
            if (lightSIV > 10)
                {
                await brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.A, 100);
                await brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.D, 100);
            }
            else if(lightSIV <= 10)
                {
                await brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.A, 0);
                await brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.D, 0);
            }
        }
    }

  

}
