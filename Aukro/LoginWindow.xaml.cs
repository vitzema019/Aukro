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
    /// Interakční logika pro LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainViewModel _vm;
        public LoginWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            _vm = vm;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            _vm.LoginErrorMessage = null;
            if(nameBox.Text.Length == 0) 
            {
                _vm.LoginErrorMessage = "Pole nesmí být prázdné";
                nameBox.Focus();
            }
            else 
            {
                if(passwordBox.Password.Length == 0) 
                {
                    _vm.LoginErrorMessage = "Pole nesmí být prázdné";
                    passwordBox.Focus();
                }
                else 
                {
                    if (_vm.Db != null)
                    {

                        var user = _vm.Db.Users.Where(x => x.Username == nameBox.Text && x.Password == passwordBox.Password).SingleOrDefault();
                        if (user != null)
                        {
                            _vm.User = user;
                            _vm.CurrentUser = user.Username;
                            _vm.IsLoggedIn = true;
                            _vm.LoginErrorMessage = null;
                            _vm.GetYourAuctionsComand.Execute(null);
                            this.Close();
                            MessageBox.Show("Vítej uživateli " + _vm.User.Username);
                        }
                        else
                        {
                            ;
                            _vm.LoginErrorMessage = "Špatné přihlašovací údaje!";
                        }
                    }
                }   
            } 
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
