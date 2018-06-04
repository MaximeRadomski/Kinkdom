using System.Collections.Generic;
using System.Windows.Input;
using Autofac;
using Kinkdom.Models;
using Kinkdom.Pages;
using Kinkdom.Services.Interfaces;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    public class FavoritesPageModel : ContentPage
    {
        public List<Product> Products { get; set; }
        public bool IsLoading { get; set; }

        private readonly ILocalDatabaseService _localDatabaseService;
        private readonly INavigation _navigation;

        public FavoritesPageModel(INavigation navigation)
        {
            _navigation = navigation;
            _localDatabaseService = App.Container.Resolve<ILocalDatabaseService>();
            LoadItems();
        }

        public async void LoadItems()
        {
            IsLoading = true;
            Products = await _localDatabaseService.GetFavorites();
            IsLoading = false;
        }

        public void CustomOnAppearing()
        {
            LoadItems();
        }

        public ICommand ItemClickCommand => new Command<object>(async (item) =>
        {
            await _navigation.PushAsync(new ProductPage(((Product)item).Id));
        });
    }
}