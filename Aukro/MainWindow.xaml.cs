﻿using Aukro.Data;
using Aukro.ViewModels;
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

namespace Aukro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm;
        internal MainWindow()
        {
            InitializeComponent();
            vm = (MainViewModel)DataContext;
            vm.ShowCommand.Execute(null);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.DataContext = vm;
                vm.User = new();
                loginWindow.ShowDialog();
        }
    }
}
