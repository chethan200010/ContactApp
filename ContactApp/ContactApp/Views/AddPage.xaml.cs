using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactAddPage : ContentPage
    {
        public ContactAddPage()
        {
            InitializeComponent();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }      
    }
}