using ContactApp.Models;
using ContactApp.RealmObjects;
using Realms;
using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;

namespace ContactApp.ViewModels
{
    [QueryProperty(nameof(Number), nameof(Number))]
    public class PersonDetailViewModel : BaseViewModel
    {
        private string _number;
        private ContactModel contact;
        
        public ICommand DeleteCommand { get; }
        public ICommand DialCommand { get; }
        public ICommand Messagecommand { get; }
        public string Number
        {
            get => _number; set
            {
                _number = value;
                OnPropertyChange(nameof(Number));
                GetContactFromNumber();
            }
        }

        public ContactModel Contact
        {
            get => contact;
            set
            {
                contact = value;
                OnPropertyChange(nameof(Contact));
            }
        }

        public PersonDetailViewModel()
        {   
            Contact = new ContactModel();
            DeleteCommand = new Command<ContactModel>(Delete);
            DialCommand = new Command(Dial);
            Messagecommand = new Command(Message);
        }


        private void GetContactFromNumber()
        {
            var realm = Realms.Realm.GetInstance();
            var contact = realm.All<ContactObject>().FirstOrDefault(i => i.Number == Number);
            Contact = new ContactModel()
            {
                Number = contact.Number,
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName
            };
        }
        public async void Delete(ContactModel obj)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Alert!", "Do you really want to Delete?", "Yes", "No");

            if (result)
            {
                var realm = Realms.Realm.GetInstance();
                var contact = realm.All<ContactObject>().FirstOrDefault(i => i.Number == Number);
                {

                    using (var transaction = realm.BeginWrite())
                    {
                        realm.Remove(contact);
                        transaction.Commit();
                    }
                };

              await  Shell.Current.GoToAsync("..");
            }

        }
        public void Dial(object obj)
        { 
            PhoneDialer.Open(Contact.Number);
        }
        public void Message(object obj)
        {

            Sms.ComposeAsync(new SmsMessage
            {
                Recipients = new List<string> { Contact.Number }
            });
        }
    }
}


