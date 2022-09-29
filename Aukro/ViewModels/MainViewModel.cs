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
        private ObservableCollection<Auction>? _auctions;
        private ObservableCollection<Auction>? _yourAuctions;
        private ObservableCollection<User>? _users;
        private string _currentUser = "Nepřihlášen";
        private string? _LoginErrorMessage;
        private bool _isLoggedIn = false;
        private Auction _selectedAuction;
        private Auction _yourSelectedAuction;
        private Auction _newAuction;
        //public RelayCommand ShowCommand { get; set; }
        //public ParametrizedRelayCommand<User> LoginCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
           

            GetAuctionsComand = new RelayCommand(
                 () =>
                     {
                         var auctions = Db.Auctions.ToList();
                         Auctions = new ObservableCollection<Auction>(auctions);
                     }

                );
            GetYourAuctionsComand = new RelayCommand(
                () =>
                {
                    if (_isLoggedIn == true)
                    {
                        var yourAuctions = Db.Auctions.Where(x => x.CreatorId == User.Id).ToList();
                        YourAuctions = new ObservableCollection<Auction>(yourAuctions);
                    }
                    else 
                    {
                        YourAuctions = null;
                    }
                   
                }

               );
            AddCommand = new ParametrizedRelayCommand<Auction>(
                async (newproduct) => {
                    newproduct.CreatorId = User.Id;
                    newproduct.LastUserId = User.Id;
                    newproduct.DateOfCreation = DateTime.Now;
                    Db.Auctions.Add(newproduct);
                    Db.SaveChanges();
                    GetUsers();
                    GetAuctionsComand.Execute(null);
                    GetYourAuctionsComand.Execute(null);
                }
               );

            DeleteAuctionCommand = new ParametrizedRelayCommand<int>(
                (id) =>
                    {
                        var x = Db.Auctions.Where(x => x.AuctionId == id).FirstOrDefault();
                        Db.Auctions.Remove(x);
                        Db.SaveChanges();
                        GetAuctionsComand.Execute(null);
                        GetYourAuctionsComand.Execute(null);
                    }
                );
        }

        public void GetUsers()
        {
            var users = Db.Users.ToList();
            Users = new ObservableCollection<User>(users);
        }

        public RelayCommand GetAuctionsComand { get; set; }
        public RelayCommand GetYourAuctionsComand { get; set; }
        public ParametrizedRelayCommand<Auction> AddCommand { get; set; }
        public ParametrizedRelayCommand<int> DeleteAuctionCommand { get; set; }
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

        public ObservableCollection<Auction>? Auctions
        {
            get { return _auctions; }
            set { _auctions = value; NotifyPropertyChanged(); }
        }

        public Auction SelectedAuction
        {
            get { return _selectedAuction; }
            set { _selectedAuction = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<User>? Users 
        
        {
            get { return _users; }
            set { _users = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<Auction>? YourAuctions
        {
            get { return _yourAuctions; }
            set { _yourAuctions = value; NotifyPropertyChanged(); }
        }

        public Auction YourSelectedAuction
        {
            get { return _yourSelectedAuction; }
            set { _yourSelectedAuction = value; NotifyPropertyChanged(); }
        }

        public Auction NewAuction 
        {
            get {return _newAuction;}
            set { _newAuction = value; NotifyPropertyChanged(); }
        }
    }
}
