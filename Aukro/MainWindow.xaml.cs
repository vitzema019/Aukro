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
        internal MainWindow()
        {
            InitializeComponent();
            _vm = (MainViewModel)DataContext;
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
            MessageBox.Show("Byli jste úspěšně odhlášeni");
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register(_vm);
            registerWindow.DataContext = _vm;
            _vm.LoginErrorMessage = null;
            registerWindow.ShowDialog();
        }
    }
}
