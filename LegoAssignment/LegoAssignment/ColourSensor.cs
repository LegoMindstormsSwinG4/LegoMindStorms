using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoAssignment
{
    class ColourSensor
    {
        float colourSIV;

        public void baseBRCheck(object sender, BrickChangedEventArgs e, Brick brick)
        {
            colourSIV = e.Ports[InputPort.Three].SIValue;

            if (colourSIV == 5) //RED
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -100, 7000, false);
            }
            else if (colourSIV == 2) //BLUE
            {

            }
            else
            {

            }
        }
    }
}
