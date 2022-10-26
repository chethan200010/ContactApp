using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPersonDetail : ContentPage
    {
        public ContactPersonDetail()
        {
            InitializeComponent();
        }   
    }
}