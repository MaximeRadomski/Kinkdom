using System.Collections.Generic;
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
        public bool IsFavorite { get; set; }

        public string CurrentImage { get; set; }
        public bool HasMultipleImages { get; set; }
        public bool HasThreeImages { get; set; }
        public bool ButtonImageSlideShow01 { get; set; } = true;
        public bool ButtonImageSlideShow02 { get; set; }
        public bool ButtonImageSlideShow03 { get; set; }

        private readonly ILocalDatabaseService _localDatabaseService;
        private readonly INavigation _navigation;
        private int _nbImages;

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
            IsFavorite = Product.IsFavorite;
            CurrentImage = Product.Image01;
            if (Product.Image02 != null)
            {
                HasMultipleImages = true;
                if (Product.Image03 != null)
                    HasThreeImages = true;
            }
            IsLoading = false;
        }

        public ICommand AddRemoveFavoriteCommand => new Command(async () =>
        {
            if (!Product.IsFavorite)
            {
                Product.IsFavorite = true;
            }
            else
            {
                Product.IsFavorite = false;
            }
            await _localDatabaseService.AddRemoveFavoriteProduct(Product);
            IsFavorite = Product.IsFavorite;
        });

        public ICommand GetRandomProductCommand => new Command(async () =>
        {
            if (!HasMultipleImages)
                return;
            if (CurrentImage == Product.Image01)
            {
                ButtonImageSlideShow01 = false;
                ButtonImageSlideShow02 = true;
                CurrentImage = Product.Image02;
            }
            else if (CurrentImage == Product.Image02 && HasThreeImages)
            {
                ButtonImageSlideShow02 = false;
                ButtonImageSlideShow03 = true;
                CurrentImage = Product.Image03;
            }
            else
            {
                ButtonImageSlideShow01 = true;
                ButtonImageSlideShow02 = false;
                ButtonImageSlideShow03 = false;
                CurrentImage = Product.Image01;
            }
        });
    }
}