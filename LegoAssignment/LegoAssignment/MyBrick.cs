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


    }

    Brick brick = new Brick(new UsbCommunication());

    public async void connect()
    {
        Console.WriteLine("Connecting, One Sec");

        await brick.ConnectAsync();
        brick.BrickChanged += OnBrickChanged;

        await brick.DirectCommand.PlayToneAsync(50, 15, 666);

        Console.WriteLine("Succsesfully Connected");
    }

}
