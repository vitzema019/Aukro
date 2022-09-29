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
using System.Windows.Shapes;

namespace Aukro
{
    /// <summary>
    /// Interakční logika pro BidWindow.xaml
    /// </summary>
    public partial class BidWindow : Window
    {
        private MainViewModel _vm;
        public BidWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            _vm = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_vm.SelectedAuction.MinimumPrice > _vm.BeforeBid) 
            {
                _vm.BidCommand.Execute(_vm.SelectedAuction);
                this.Close();
            }
            else 
            {
                _vm.SelectedAuction.MinimumPrice = _vm.BeforeBid;
                _vm.GetAuctionsComand.Execute(null);
                _vm.LoginErrorMessage = "Částku musí být větší než momentální částka!!";
            }
            
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
