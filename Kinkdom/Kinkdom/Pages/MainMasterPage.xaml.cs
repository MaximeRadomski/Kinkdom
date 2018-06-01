using Kinkdom.PageModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kinkdom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPage : ContentPage
    {
        public MainMasterPage()
        {
            MainMasterPageModel pm = new MainMasterPageModel();
            pm.Navigation = Navigation;
            BindingContext = pm;
            InitializeComponent();
        }
    }
}