using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            brick.BrickChanged += OnBrickChanged;

            await brick.DirectCommand.PlayToneAsync(50, 15, 666);
        }

        private void OnBrickChanged(object sender, BrickChangedEventArgs e)
        {
            distanceSIV = e.Ports[InputPort.Two].SIValue;

            lblDistanceValue.Content = distanceSIV;
        }
    }
}
