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
        Brick brick = new Brick(new BluetoothCommunication("COM3"));

        float distanceSIV;
        float colourSIV;

        public async Task brickConnect()
        {
            await brick.ConnectAsync();

            await brick.DirectCommand.PlayToneAsync(50, 15, 666);
        }

        public void OnBrickChangedBlueRed(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;

            if (distanceSIV > 7)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 50, 1000, false);
            }
            else
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 0, 1000, false);
                baseBRCheck(sender, e);
                brick.BrickChanged -= OnBrickChangedBlueRed;
            }
        }

        public void OnBrickChangedBlackRed(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;

            if (distanceSIV > 7)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 50, 1000, false);
            }
            else
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 0, 1000, false);
                baseBLRCheck(sender, e);
                brick.BrickChanged -= OnBrickChangedBlackRed;
            }
        }

        public void OnBrickChangedBlackYellow(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;

            if (distanceSIV > 7)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 50, 1000, false);
            }
            else
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 0, 1000, false);
                baseBLYCheck(sender, e);
                brick.BrickChanged -= OnBrickChangedBlackYellow;
            }
        }

        public void OnBrickChangedYellowBlue(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;

            if (distanceSIV > 7)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 50, 1000, false);
            }
            else
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 0, 1000, false);
                baseYBCheck(sender, e);
                brick.BrickChanged -= OnBrickChangedYellowBlue;
            }
        }

        public void OnBrickChangedFinalDrive(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;

            if (distanceSIV > 7)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 50, 1000, false);
            }
            else
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 0, 1000, false);
                brick.BrickChanged -= OnBrickChangedFinalDrive;
                brick.DirectCommand.PlayToneAsync(50, 50, 666);
            }
        }

        public void BaseBlueRed()
        {
             brick.BrickChanged += OnBrickChangedBlueRed;
        }

        public void BaseBlackRed()
        {
            brick.BrickChanged += OnBrickChangedBlackRed;
        }

        public void BaseBlackYellow()
        {
            brick.BrickChanged += OnBrickChangedBlackYellow;
        }

        public void BaseYellowBlue()
        {
            brick.BrickChanged += OnBrickChangedYellowBlue;
        }

        public void FinalDrive()
        {
            brick.BrickChanged += OnBrickChangedFinalDrive;
        }

        public async void baseBRCheck(object sender, BrickChangedEventArgs e)
        {
            try
            {
                colourSIV = await brick.DirectCommand.ReadySIAsync(InputPort.Three, 2);
            }
            catch (Exception)
            {
                return;
            }

            if (colourSIV == 5) //RED
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -50, 1200, false);

                await Task.Delay(1400);

                FinalDrive();
            }
            else if (colourSIV == 2) //BLUE
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, -50, 1200, false);

                await Task.Delay(1400);

                FinalDrive();
            }
            else 
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, -50, 1200, false);

                await Task.Delay(1400);

                brick.BrickChanged += OnBrickChangedBlueRed;
            }
        }

        public async void baseBLRCheck(object sender, BrickChangedEventArgs e)
        {
            try
            {
                colourSIV = await brick.DirectCommand.ReadySIAsync(InputPort.Three, 2);
            }
            catch (Exception)
            {
                return;
            }

            if (colourSIV == 5) //RED
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, -50, 1200, false);

                await Task.Delay(1400);

                FinalDrive();
            }
            else if (colourSIV == 1) //BLACK
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -50, 1200, false);

                await Task.Delay(1400);

                FinalDrive();
            }
            else
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -50, 1200, false);

                await Task.Delay(1400);

                brick.BrickChanged += OnBrickChangedBlackRed;
            }
        }

        public async void baseBLYCheck(object sender, BrickChangedEventArgs e)
        {
            try
            {
                colourSIV = await brick.DirectCommand.ReadySIAsync(InputPort.Three, 2);
            }
            catch (Exception)
            {
                return;
            }

            if (colourSIV == 7) //YELLOW
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -50, 1200, false);

                await Task.Delay(1400);

                FinalDrive();
            }
            else if (colourSIV == 1) //BLACK
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, -50, 1200, false);

                await Task.Delay(1400);

                FinalDrive();
            }
            else
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, -50, 1200, false);

                await Task.Delay(1400);

                brick.BrickChanged += OnBrickChangedBlackYellow;
            }
        }

        public async void baseYBCheck(object sender, BrickChangedEventArgs e)
        {
            try
            {
                colourSIV = await brick.DirectCommand.ReadySIAsync(InputPort.Three, 2);
            }
            catch (Exception)
            {
                return;
            }

            if (colourSIV == 7) //YELLOW
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, -50, 1200, false);

                await Task.Delay(1400);

                FinalDrive();
            }
            else if (colourSIV == 2) //BLUE
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -50, 1200, false);

                await Task.Delay(1400);

                FinalDrive();
            }
            else
            {
                await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -50, 1200, false);

                await Task.Delay(1400);

                brick.BrickChanged += OnBrickChangedYellowBlue;
            }
        }
    }
}
