using Kinkdom.Models;
using Kinkdom.Pages;
using Kinkdom.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    class MainMasterPageModel : MasterDetailPage
    {
        public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

        public MainMasterPageModel()
        {
            MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
                {
                    new MainPageMenuItem { Id = 0, Title = "Toys", ImagePath = "MenuIcon01.png", Category = CategoryEnum.Toys, TargetType = typeof(CategoryPage)},
                    new MainPageMenuItem { Id = 1, Title = "Restraints", ImagePath = "MenuIcon02.png", Category = CategoryEnum.Restraints, TargetType = typeof(CategoryPage)},
                    new MainPageMenuItem { Id = 2, Title = "Furnitures", ImagePath = "MenuIcon03.png", Category = CategoryEnum.Furnitures, TargetType = typeof(CategoryPage)},
                    new MainPageMenuItem { Id = 3, Title = "Outfits", ImagePath = "MenuIcon04.png", Category = CategoryEnum.Outfits, TargetType = typeof(CategoryPage)},
                    new MainPageMenuItem { Id = 4, Title = "Practices", ImagePath = "MenuIcon05.png", Category = CategoryEnum.Practices, TargetType = typeof(CategoryPage)}
                });
        }

        public new INavigation Navigation { get; set; }

        public ICommand ItemClickCommand => new Command<object>(async (item) =>
        {
            await App.MainMasterPage.Detail.Navigation.PushAsync(new CategoryPage(((MainPageMenuItem)item).Id));
            App.MainMasterPage.IsPresented = false;
        });

        public ICommand ReturnToMainmenuCommand => new Command(async () =>
        {
            await App.MainMasterPage.Detail.Navigation.PopToRootAsync();
            App.MainMasterPage.IsPresented = false;
        });
    }
}
