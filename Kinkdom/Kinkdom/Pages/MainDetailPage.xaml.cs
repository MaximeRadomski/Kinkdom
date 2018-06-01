using Kinkdom.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kinkdom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDetailPage : ContentPage
    {
        public MainDetailPage()
        {
            MainDetailPageModel pm = new MainDetailPageModel();
            pm.Navigation = Navigation;
            BindingContext = pm;
            InitializeComponent();
        }
    }
}