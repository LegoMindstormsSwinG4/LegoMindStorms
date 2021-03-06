﻿using System;
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

        MyBrick Lego = new MyBrick();

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            await Lego.brickConnect();
        }

        private void btnBase1_Click(object sender, RoutedEventArgs e)
        {
            Lego.BaseBlueRed();
        }

        private void btnBase2_Click(object sender, RoutedEventArgs e)
        {
            Lego.BaseBlackRed();
        }

        private void btnBase3_Click(object sender, RoutedEventArgs e)
        {
            Lego.BaseBlackYellow();
        }

        private void btnBase4_Click(object sender, RoutedEventArgs e)
        {
            Lego.BaseYellowBlue();
        }


        // black1, red5, blue2, yellow7
    }
}
