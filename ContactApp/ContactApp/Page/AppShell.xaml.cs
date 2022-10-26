using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ContactAddPage", typeof(ContactAddPage));
            Routing.RegisterRoute("ContactPersonDetail", typeof(ContactPersonDetail));
          //  Routing.RegisterRoute("MainPage",typeof(MainPage));

        }
    }
}