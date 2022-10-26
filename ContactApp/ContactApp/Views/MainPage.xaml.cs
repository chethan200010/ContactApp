using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.RealmObjects;
using ContactApp.ViewModels;
using Realms;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()

        {
            InitializeComponent();
           
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MainViewModel)BindingContext).RefreshCommand.Execute(null);
           
        }


       
    }
}
