using Aukro.Models;
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
    /// Interakční logika pro Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private MainViewModel _vm;
        public Register(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            _vm = vm;
        }

        private void Regsiter_Click(object sender, RoutedEventArgs e)
        {
            _vm.LoginErrorMessage = null;
            if (nameBox.Text.Length == 0)
            {
                _vm.LoginErrorMessage = "Zadejte uživatelské jméno";
                nameBox.Focus();
            }
            else if(passwordBox.Password.Length == 0) 
            {
                _vm.LoginErrorMessage = "Zadejte heslo";
                passwordBox.Focus();
            }
            else if(confirmPasswordBox.Password.Length == 0) 
            {
                _vm.LoginErrorMessage = "Zadejte heslo pro kontrolu";
                confirmPasswordBox.Focus();
            }
            else 
            {
                if (_vm.Db != null) 
                {
                    var confirmUsername = _vm.Db.Users.Where(u => u.Username == nameBox.Text).FirstOrDefault();
                    if (confirmUsername != null) 
                    {
                        _vm.LoginErrorMessage = "Uživatelské jméno je obsazeno";
                        nameBox.Focus();
                    }
                    else if(passwordBox.Password != confirmPasswordBox.Password) 
                    {
                        _vm.LoginErrorMessage = "Hesla se neshodují!";
                        passwordBox.Focus();
                    }
                    else if(nameBox.Text.Length < 3)
                    {
                        _vm.LoginErrorMessage = "Uživatelké jméno musí obsahovat více jak 3 znaky";
                        nameBox.Focus();
                    }
                    else if(passwordBox.Password.Length < 5) 
                    {
                        _vm.LoginErrorMessage = "Heslo musí obsahovat více jak 5 znaků";
                        passwordBox.Focus();
                    }
                    else 
                    {
                        User newUser = new User()
                        {
                            Username = nameBox.Text,
                            Password = passwordBox.Password,
                        };

                        _vm.LoginErrorMessage = null;
                        _vm.Db.Users.Add(newUser);
                        _vm.Db.SaveChanges();
                        this.Close();
                        MessageBox.Show("Registrace uživatele " + newUser.Username + " proběhla úspěšně");

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
