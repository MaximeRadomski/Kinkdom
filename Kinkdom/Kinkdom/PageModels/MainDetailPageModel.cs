using Kinkdom.Models;
using Kinkdom.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Autofac;
using Kinkdom.Services.Interfaces;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    class MainDetailPageModel : ContentPage
    {
        public List<Category> MenuItems { get; set; }

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
        }

        public ICommand PushCategoryCommand => new Command<int>(async (categoryId) =>
        {
            await _navigation.PushAsync(new CategoryPage(categoryId));
        });

        public ICommand PushAboutCommand => new Command(async () =>
        {
            await _navigation.PushAsync(new CategoryPage(0));
        });
    }
}
