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
    public class MainViewModel : INotifyPropertyChanged
    {
        public ApplicationDbContext Db { get; set; } = new ApplicationDbContext();
        private User? _user;
        private ObservableCollection<Auction> _auctions;
        private string _currentUser = "Nepřihlášen";
        private string? _LoginErrorMessage;
        private bool _isLoggedIn = false;

        public RelayCommand ShowCommand { get; set; }
        public ParametrizedRelayCommand<User> LoginCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
           
        }


        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; NotifyPropertyChanged(); }
        }
        public string? LoginErrorMessage 
        {
            get { return _LoginErrorMessage; }
            set { _LoginErrorMessage = value; NotifyPropertyChanged(); }
        }
        public string CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; NotifyPropertyChanged(); }
        }

        public User? User
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
