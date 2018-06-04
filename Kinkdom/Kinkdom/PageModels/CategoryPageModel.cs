﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Kinkdom.Models;
using Kinkdom.Pages;
using Kinkdom.Services.Interfaces;
using Xamarin.Forms;

namespace Kinkdom.PageModels
{
    class CategoryPageModel : ContentPage
    {
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
        public bool IsLoading { get; set; }

        private readonly ILocalDatabaseService _localDatabaseService;
        private readonly INavigation _navigation;
        private readonly int _categoryId;

        public CategoryPageModel(int categoryId, INavigation navigation)
        {
            _categoryId = categoryId;
            _navigation = navigation;
            _localDatabaseService = App.Container.Resolve<ILocalDatabaseService>();
            LoadItems(_categoryId);
        }

        public async void LoadItems(int categoryId)
        {
            IsLoading = true;
            Category = await _localDatabaseService.GetCategoryFromId(categoryId);
            Products = await _localDatabaseService.GetProductsFromCategory(Category.Id);
            IsLoading = false;
        }

        public void CustomOnAppearing()
        {
            LoadItems(_categoryId);
        }

        public ICommand ItemClickCommand => new Command<object>(async (item) =>
        {
            await _navigation.PushAsync(new ProductPage(((Product)item).Id));
        });

        public ICommand ReloadDataCommand => new Command<object>(async (item) =>
        {
            await _localDatabaseService.ReloadData();
            LoadItems(_categoryId);
            await Task.CompletedTask;
        });
    }
}