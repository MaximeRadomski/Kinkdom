using Kinkdom.Models;
using Kinkdom.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Kinkdom.Services.Interfaces;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    class MainDetailPageModel : ContentPage
    {
        public List<Category> MenuItems { get; set; }
        public Product RandomProduct { get; set; }
        public string RandomProductCategories { get; set; }

        private readonly ILocalDatabaseService _localDatabaseService;
        private readonly INavigation _navigation;

        public MainDetailPageModel(INavigation navigation)
        {
            _navigation = navigation;
            _localDatabaseService = App.Container.Resolve<ILocalDatabaseService>();
            LoadItems();
        }

        public async void LoadItems()
        {
            MenuItems = await _localDatabaseService.GetCategories();
            await LoadRandomProduct();
        }

        public async Task LoadRandomProduct()
        {
            RandomProduct = await _localDatabaseService.GetRandomProduct();
            RandomProductCategories = _localDatabaseService.GetCategoryFromId(RandomProduct.Category01).Result.Title;
            if (RandomProduct.Category02 != null)
                RandomProductCategories += ", " + _localDatabaseService.GetCategoryFromId((int)RandomProduct.Category02).Result.Title;
            if (RandomProduct.Category03 != null)
                RandomProductCategories += ", " + _localDatabaseService.GetCategoryFromId((int)RandomProduct.Category03).Result.Title;
        }

        public ICommand PushCategoryCommand => new Command<int>(async (categoryId) =>
        {
            await _navigation.PushAsync(new CategoryPage(categoryId));
        });

        public ICommand PushAboutCommand => new Command(async () =>
        {
            await _navigation.PushAsync(new CategoryPage(0));
        });

        public ICommand GetRandomProductCommand => new Command(async () =>
        {
            await LoadRandomProduct();
        });

        public ICommand PushRandomProductCommand => new Command<int>(async (productId) =>
        {
            await _navigation.PushAsync(new ProductPage(productId));
        });
    }
}
