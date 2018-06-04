using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinkdom.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kinkdom.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoritesPage : ContentPage
	{
		public FavoritesPage ()
		{
		    BindingContext = new FavoritesPageModel(Navigation);
		    InitializeComponent();
        }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        ((FavoritesPageModel)BindingContext).CustomOnAppearing();
        }
    }
}