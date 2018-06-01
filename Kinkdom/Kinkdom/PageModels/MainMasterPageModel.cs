using Kinkdom.Models;
using Kinkdom.Pages;
using Kinkdom.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Kinkdom.Services.Interfaces;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    class MainMasterPageModel : MasterDetailPage
    {
        public List<Category> MenuItems { get; set; }

        private readonly ILocalDatabaseService _localDatabaseService;

        public MainMasterPageModel()
        {
            _localDatabaseService = App.Container.Resolve<ILocalDatabaseService>();
            LoadItems();
        }

        public async void LoadItems()
        {
            MenuItems = await _localDatabaseService.GetCategories();
        }

        public ICommand ItemClickCommand => new Command<object>(async (item) =>
        {
            await App.MainMasterPage.Detail.Navigation.PushAsync(new CategoryPage(((Category)item).Id));
            App.MainMasterPage.IsPresented = false;
        });

        public ICommand ReturnToMainmenuCommand => new Command(async () =>
        {
            await App.MainMasterPage.Detail.Navigation.PopToRootAsync();
            App.MainMasterPage.IsPresented = false;
        });
    }
}
