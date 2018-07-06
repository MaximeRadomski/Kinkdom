using Kinkdom.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kinkdom.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoryPage : ContentPage
	{
	    private bool _entryVisible = false;

		public CategoryPage (int categoryId)
		{
            BindingContext = new CategoryPageModel(categoryId, Navigation);
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        ((CategoryPageModel)BindingContext).CustomOnAppearing();
        }

	    private void Entry_OnCompleted(object sender, EventArgs e)
	    {
	        ((CategoryPageModel)BindingContext).SearchByName();
        }

	    private void MenuItem_OnClicked(object sender, EventArgs e)
	    {
	        if (!_entryVisible)
	        {
	            _entryVisible = true;
	            SearchEntry.Focus();
            }
	        else
	        {
	            _entryVisible = false;
            }
	    }
	}
}