using ContactApp.RealmObjects;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ContactApp.ViewModels
{
    public class AddContactViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChange(nameof(FirstName)); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChange(nameof(LastName)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChange(nameof(Email)); }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChange(nameof(PhoneNumber)); }
        }

        public ICommand SaveCommand { get; }

        public AddContactViewModel()
        {
            SaveCommand = new Command(Save);
           
        }
        
        private void Save()
        {
            if (ValidateSave())
            {
                var realm = Realms.Realm.GetInstance();
                realm.Write(() =>
                {
                    realm.Add(new ContactObject()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = FirstName,
                        LastName = LastName,
                        Email = Email,
                        Number = PhoneNumber,
                    });
                });
                Shell.Current.GoToAsync("..");
            }          
        }     
        private bool ValidateSave()
        {
              return !String.IsNullOrWhiteSpace(FirstName)
                && !String.IsNullOrWhiteSpace(LastName)
                && !String.IsNullOrWhiteSpace(PhoneNumber)
               && !String.IsNullOrWhiteSpace(Email);               
        }

    }

}
