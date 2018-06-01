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

        public CategoryPageModel(int categoryId)
        {
            _localDatabaseService = App.Container.Resolve<ILocalDatabaseService>();
            Task.Run(async () => await LoadItems(categoryId));
        }

        public async Task LoadItems(int categoryId)
        {
            Category = await _localDatabaseService.GetCategoryFromId(categoryId);
        }
    }
}