using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Kinkdom.Models;
using Kinkdom.Services.Interfaces;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    public class ProductPageModel : ContentPage
    {
        public Product Product { get; set; }
        public bool IsLoading { get; set; }
        public string Categories { get; set; }

        private readonly ILocalDatabaseService _localDatabaseService;
        private readonly INavigation _navigation;

        public ProductPageModel(int productId, INavigation navigation)
        {
            _navigation = navigation;
            _localDatabaseService = App.Container.Resolve<ILocalDatabaseService>();
            LoadItems(productId);
        }

        public async void LoadItems(int productId)
        {
            IsLoading = true;
            Product = await _localDatabaseService.GetProductFromId(productId);
            Categories = _localDatabaseService.GetCategoryFromId(Product.Category01).Result.Title;
            if (Product.Category02 != null)
                Categories += ", " + _localDatabaseService.GetCategoryFromId((int)Product.Category02).Result.Title;
            if (Product.Category03!= null)
                Categories += ", " + _localDatabaseService.GetCategoryFromId((int)Product.Category03).Result.Title;
            IsLoading = false;
        }
    }
}