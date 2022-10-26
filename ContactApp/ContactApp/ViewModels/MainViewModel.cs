using ContactApp.Models;
using ContactApp.RealmObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Converters;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ContactModel> _contacts;
       
       
        public ObservableCollection<ContactModel> Contacts
        {
            get => _contacts;
            set
            {
                _contacts = value;
                OnPropertyChange(nameof(Contacts));
            }
        }
        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChange(nameof(SelectedContact));
            }
        }
        private bool _buttonVisible;
        private bool _searchBarVisible;
        private bool _isRefreshing;
        public bool IsRefreshing { get => _isRefreshing; set { _isRefreshing = value; OnPropertyChange(nameof(IsRefreshing)); } }
        public ICommand RefreshCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand DialCommand { get; }
        public ICommand ItemSelectedCommand { get; }
        public ICommand SearchButtonCommand { get; }
        public ICommand SearchCommand { get; }

        public MainViewModel()
        {
            
            AddButtonCommand = new Command(Add);
            RefreshCommand = new Command(Refresh);
            DialCommand = new Command<ContactModel>(Dial);
            ItemSelectedCommand = new Command<ContactModel>(ItemSelected);
            Contacts = new ObservableCollection<ContactModel>();
            SelectedContact = new ContactModel();
            SearchButtonCommand = new Command(Access);
            SearchCommand = new Command<string>(Search);

        }
        public bool ButtonVisible
        {
            get => _buttonVisible;
            set
            {
                _buttonVisible = value;
                OnPropertyChange(nameof(ButtonVisible));
            }
        }
        public bool SearchBarVisible
        {
            get => _searchBarVisible;
            set
            {
                _searchBarVisible = value;
                OnPropertyChange(nameof(SearchBarVisible));
            }
        }

        public void Refresh(object obj)
        {
            ButtonVisible = true;
            SearchBarVisible = false;
            IsRefreshing = true;
            var realm = Realms.Realm.GetInstance();
            var allContacts = realm.All<ContactObject>().ToList();

            Contacts.Clear();

            foreach (var contact in allContacts)
            {
                Contacts.Add(new ContactModel()
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Number = contact.Number
                });
            }
            IsRefreshing = false;
        }
        public void Add(object obj)
        {
            Shell.Current.GoToAsync(nameof(ContactAddPage));
        }
        public void Dial(ContactModel obj)
        {
            PhoneDialer.Open(obj.Number);
        }
        public void ItemSelected(ContactModel obj)
        {
            SelectedContact = obj;
            Shell.Current.GoToAsync($"{nameof(ContactPersonDetail)}?Number={SelectedContact.Number}");
        }
        public void Access()
        {
            ButtonVisible = false;
            SearchBarVisible = true;
        }
        public void Search(string name)
        {
            var realm = Realms.Realm.GetInstance();
            var contacts = realm.All<ContactObject>().Where(c => c.FirstName.ToLower().Contains(name.ToLower()));
            Contacts.Clear();
            foreach (var contact in contacts)
            {
                Contacts.Add(new ContactModel()
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Number = contact.Number
                });

            }
            ButtonVisible= true;
            SearchBarVisible= false;


        }
    }
}