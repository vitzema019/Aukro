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
using System.Windows.Shapes;
using Aukro.ViewModels;

namespace Aukro
{
    /// <summary>
    /// Interakční logika pro AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private MainViewModel _vm;
        public AddWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            _vm = vm;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _vm.AddCommand.Execute(_vm.NewAuction);
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
