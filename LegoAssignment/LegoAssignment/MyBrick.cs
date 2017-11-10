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

        public async Task Connect()
        {
            await brick.ConnectAsync();
            brick.BrickChanged += OnBrickChanged;

            await brick.DirectCommand.PlayToneAsync(50, 15, 666);
        }

        private void OnBrickChanged(object sender, BrickChangedEventArgs e)
        {

        }
    }
}
