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
                new Category { Id = 4, Title = "Practices", ImagePath = "MenuIcon05.png"}
            };
            _products = new List<Product>
            {
                new Product {Name = "Test01",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "MenuIcon01.png"},
                new Product {Name = "Test02",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "MenuIcon01.png"},
                new Product {Name = "Test03",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "MenuIcon01.png"},
                new Product {Name = "Test04",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "MenuIcon01.png"},
                new Product {Name = "Test05",
                    Desc01 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc02 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Desc03 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce efficitur, lectus vel tristique scelerisque, elit justo tempor purus, vel accumsan magna lorem eget est. Pellentesque ac mattis lorem. Vivamus magna sem, feugiat consectetur elit in, pretium facilisis dui.",
                    Category01 = 0,
                    Image01 = "MenuIcon01.png"},
            };
        }

        public async Task<List<Category>> SetAllCategories()
        {
            await Task.CompletedTask;
            return _categories;
        }
    }
}