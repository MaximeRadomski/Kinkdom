using Kinkdom.Models;
using Kinkdom.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    class MainDetailPageModel : ContentPage
    {
        public MainDetailPageModel()
        {
        }

        public new INavigation Navigation { get; set; }

        public ICommand PushCategoryCommand => new Command<string>(async (categoryId) =>
        {
            await Navigation.PushAsync(new CategoryPage(Int32.Parse(categoryId)));
        });

        public ICommand PushAboutCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new CategoryPage(0));
        });
    }
}
