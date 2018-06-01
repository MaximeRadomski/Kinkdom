using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Kinkdom.Models;
using Kinkdom.Services.Interfaces;

namespace Kinkdom.Services
{
    public class FakeDataService : IFakeDataService
    {
        private List<Category> _categoryList;

        public FakeDataService()
        {
            InitializeFakeData();
        }

        private void InitializeFakeData()
        {
            _categoryList = new List<Category>
            {
                new Category { Id = 0, Title = "Toys", ImagePath = "MenuIcon01.png"},
                new Category { Id = 1, Title = "Restraints", ImagePath = "MenuIcon02.png"},
                new Category { Id = 2, Title = "Furnitures", ImagePath = "MenuIcon03.png"},
                new Category { Id = 3, Title = "Outfits", ImagePath = "MenuIcon04.png"},
                new Category { Id = 4, Title = "Practices", ImagePath = "MenuIcon05.png"}
            };
        }

        public async Task<List<Category>> SetAllCategories()
        {
            await Task.CompletedTask;
            return _categoryList;
        }
    }
}