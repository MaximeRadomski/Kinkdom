using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Kinkdom.Models;
using Kinkdom.Services.Interfaces;

namespace Kinkdom.Services
{
    public class FakeDataService : IFakeDataService
    {
        private List<Category> _categories;
        private List<Product> _products;

        public FakeDataService()
        {
            InitializeFakeData();
        }

        private void InitializeFakeData()
        {
            _categories = new List<Category>
            {
                new Category { Id = 0, Title = "Toys", ImagePath = "MenuIcon01.png"},
                new Category { Id = 1, Title = "Restraints", ImagePath = "MenuIcon02.png"},
                new Category { Id = 2, Title = "Furnitures", ImagePath = "MenuIcon03.png"},
                new Category { Id = 3, Title = "Outfits", ImagePath = "MenuIcon04.png"},
                new Category { Id = 4, Title = "Practices", ImagePath = "MenuIcon05.png"},
                new Category { Id = 5, Title = "About", ImagePath = "MenuIcon06.png"},
                new Category { Id = 6, Title = "Favorites", ImagePath = "Favorite04.png"}
            };
            _products = new List<Product>
            {
                new Product {Name = "Test01",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test02",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test03",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test04",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 1,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Butt Plug",
                    Desc01 = " - Designed to be inserted into the rectum. The anal cavity has a lot of nerves, therefore it is a good toy to enjoy anal pleasure.\n - If you have a penis, you can use it to stimulate your prostate.\n - If you have a vagina, it is used to fill the anal cavity and therefore making the vagina tighter.",
                    Desc02 = " - This toy is for a hole not lubricating naturally, understand here that lubricant is more than adviced.\n - The membrane between the vagina and the rectum being very small, the vaginal penetration while having a butt plug is very stimulating both of your magick holes.\n - ",
                    Desc03 = " - Butt plugs have a flanged end to prevent them being lost inside the rectum, do not use anything for anal penetration.\n - Do not start too big, your sphincters have to be trained before being able to handle tank shells.",
                    Category01 = 0,
                    Category02 = 1,
                    Image01 = "ButtPlug01.png",
                    Level = 1},
                new Product {Name = "Test05",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test06",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test07",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test08",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test09",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test10",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test11",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test12",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test13",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test14",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test15",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test16",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test17",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test18",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test19",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test20",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test21",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test22",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test23",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test24",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
                new Product {Name = "Test25",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "Unknown.png",
                    Level = 0},
            };
        }

        public async Task<List<Category>> SetAllCategories()
        {
            await Task.CompletedTask;
            return _categories;
        }

        public async Task<int> CountAllCategories()
        {
            await Task.CompletedTask;
            return _categories.Count;
        }

        public async Task<List<Product>> SetAllProducts()
        {
            await Task.CompletedTask;
            return _products;
        }

        public async Task<int> CountAllProducts()
        {
            await Task.CompletedTask;
            return _products.Count;
        }
    }
}