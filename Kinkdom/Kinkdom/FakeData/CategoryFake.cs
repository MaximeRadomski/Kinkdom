using Kinkdom.Models;
using Kinkdom.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinkdom.FakeData
{
    public class CategoryFake
    {
        public List<Category> CategoryList;

        public CategoryFake()
        {
            InitializeFakeData();
        }

        private void InitializeFakeData()
        {
            CategoryList = new List<Category>
            {
                new Category { Id = 0, Title = "Toys", ImagePath = "MenuIcon01.png"},
                new Category { Id = 1, Title = "Restraints", ImagePath = "MenuIcon02.png"},
                new Category { Id = 2, Title = "Furnitures", ImagePath = "MenuIcon03.png"},
                new Category { Id = 3, Title = "Outfits", ImagePath = "MenuIcon04.png"},
                new Category { Id = 4, Title = "Practices", ImagePath = "MenuIcon05.png"}
            };
        }
    }
}
