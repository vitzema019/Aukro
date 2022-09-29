using Aukro.Data;
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
        private MainViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = (MainViewModel)DataContext;
            _vm.GetAuctionsComand.Execute(null);
            _vm.GetUsers();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(_vm);
            loginWindow.DataContext = _vm;
            _vm.LoginErrorMessage = null;
            //_vm.User = new();
            loginWindow.ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            _vm.User = null;
            _vm.CurrentUser = "Nepřihlášen";
            _vm.IsLoggedIn = false;
            _vm.GetYourAuctionsComand.Execute(null);
            MessageBox.Show("Byli jste úspěšně odhlášeni");
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register(_vm);
            registerWindow.DataContext = _vm;
            _vm.LoginErrorMessage = null;
            registerWindow.ShowDialog();
        }

        private void Bid_Click(object sender, RoutedEventArgs e) 
        {
            if (_vm.SelectedAuction != null)
            {
                _vm.LoginErrorMessage = null;
                BidWindow bidWindow = new BidWindow(_vm);
                bidWindow.DataContext = _vm;
                var b = _vm.Auctions.Where(x => x.AuctionId == _vm.SelectedAuction.AuctionId).Select(x => x.MinimumPrice).FirstOrDefault();
                _vm.BeforeBid = b;
                bidWindow.ShowDialog();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _vm.LoginErrorMessage = null;
            AddWindow addWindow = new AddWindow(_vm);
            addWindow.DataContext = _vm;
            _vm.LoginErrorMessage = null;
            _vm.NewAuction = new();
            addWindow.ShowDialog();
        }

        private void DeleteYourAuction_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
