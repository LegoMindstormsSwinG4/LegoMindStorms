using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.Diagnostics;

namespace LegoAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Brick brick = new Brick(new UsbCommunication());
        float distanceSIV;

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            await brick.ConnectAsync();

            await brick.DirectCommand.PlayToneAsync(50, 15, 666);
        }

        private void OnBrickChangedTaskOne(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;
            lblDistanceValue.Content = distanceSIV;

            if (distanceSIV > 20)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 25, 1000, true);
            }
            else if (distanceSIV <= 20)
            {
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 0, 1000, true);
                brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -100, 3000, true);
            }

          /*  private void btnTask1_Click(object sender, RoutedEventArgs e)
            {
                brick.BrickChanged += OnBrickChangedTaskOne;
            }*/
        }


    }
}
