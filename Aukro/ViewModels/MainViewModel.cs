using Aukro.Data;
using Aukro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aukro.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ApplicationDbContext Db { get; set; } = new ApplicationDbContext();
        private User _user;
        private ObservableCollection<Auction> _auctions;
        private string _currentUser;
        private int? _UserId;
        private string? _LoginErrorMessage;

        public RelayCommand ShowCommand { get; set; }
        public ParametrizedRelayCommand<User> LoginCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            ShowCommand = new RelayCommand(
                () => { 
                    if (Db != null)
                    {
                        if (_user != null)
                        {
                            User u = Db.Users.Where(x => x.Id == _UserId).SingleOrDefault();
                            CurrentUser = u.Username;
                        }
                        else
                        {
                            CurrentUser = "Nepřihlášen";
                        }
                    }
                }
                );


            LoginCommand = new ParametrizedRelayCommand<User>(
                async (user) => {
                    if (Db != null)
                    {

                        User u = Db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).SingleOrDefault();
                        if(u != null) 
                        {
                            CurrentUser = u.Username;
                        }
                        else 
                        {
                            MessageBox.Show("Unable to Login, incorrect credentials.");
                        }
                            


                            

                        
                    }
                }
                );
        }

        

        public string LoginErrorMessage 
        {
            get { return _LoginErrorMessage; }
            set { _LoginErrorMessage = value; NotifyPropertyChanged(); }
        }
        public string CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; NotifyPropertyChanged(); }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; NotifyPropertyChanged(); }
        }
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
