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
		public CategoryPage (int categoryId)
		{
            BindingContext = new CategoryPageModel(categoryId, Navigation);
			InitializeComponent ();
		}
	}
}