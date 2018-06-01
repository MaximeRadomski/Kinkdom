using System.Threading.Tasks;
using Autofac;
using Kinkdom.Models;
using Kinkdom.Services.Interfaces;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    class CategoryPageModel : ContentPage
    {
        public Category Category { get; set; }

        private readonly ILocalDatabaseService _localDatabaseService;
        private readonly INavigation _navigation;

        public CategoryPageModel(int categoryId, INavigation navigation)
        {
            _navigation = navigation;
            _localDatabaseService = App.Container.Resolve<ILocalDatabaseService>();
            LoadItems(categoryId);
        }

        public async void LoadItems(int categoryId)
        {
            Category = await _localDatabaseService.GetCategoryFromId(categoryId);
        }
    }
}