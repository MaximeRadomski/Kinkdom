﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Kinkdom.Models;
using Kinkdom.Services.Interfaces;
using SQLite;

namespace Kinkdom.Services
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
        public SQLiteConnection Db;

        private readonly IFakeDataService _fakeDataService;

        public LocalDatabaseService()
        {
            _fakeDataService = new FakeDataService();
            LoadDatabase();
            LoadTables();
        }

        #region LoadDataRegion

        private void LoadDatabase()
        {
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "kinkdom.db3");
            Db = new SQLiteConnection(dbPath);
        }

        public async void LoadTables()
        {
            Db.CreateTable<Category>();
            if (!Db.Table<Category>().Any() || Db.Table<Category>().Count() < await _fakeDataService.CountAllCategories())
            {
                Db.DeleteAll<Category>();
                List<Category> allCategories = await _fakeDataService.SetAllCategories();
                foreach (var category in allCategories)
                {
                    Db.Insert(category);
                }
            }

            Db.CreateTable<Product>();
            if (!Db.Table<Product>().Any() || Db.Table<Product>().Count() < await _fakeDataService.CountAllProducts())
            {
                Db.DeleteAll<Product>();
                List<Product> allProducts = await _fakeDataService.SetAllProducts();
                foreach (var product in allProducts)
                {
                    Db.Insert(product);
                }
            }
        }

        public async Task ReloadData()
        {
            Db.DeleteAll<Product>();
            Db.DeleteAll<Category>();
            LoadTables();
            await Task.CompletedTask;
        }

        #endregion

        #region CategoriesRegion

        public async Task<List<Category>> GetCategories()
        {
            List<Category> tmpList = new List<Category>();
            var table = Db.Table<Category>();
            foreach (var item in table)
            {
                Debug.Write("|     [DEBUG]     | " + item.Id + " - " + item.Title);
                tmpList.Add(item);
            }

            await Task.CompletedTask;
            return tmpList;
        }

        public async Task<Category> GetCategoryFromId(int id)
        {
            var tmp = Db.Get<Category>(id);
            await Task.CompletedTask;
            if (tmp != null)
                return Db.Get<Category>(id);
            return null;
        }

        #endregion

        #region ProductsRegion

        public async Task<List<Product>> GetProducts(string searchName)
        {
            List<Product> tmpList = new List<Product>();
            if (searchName == null)
            {
                var table = Db.Table<Product>();
                foreach (var item in table)
                {
                    tmpList.Add(item);
                }
            }
            else
            {
                TableQuery<Product> query = new TableQuery<Product>(Db);
                query = from product in Db.Table<Product>()
                where product.Name.ToLower().Contains(searchName.ToLower())
                orderby product.Name
                select product;
                foreach (Product product in query)
                {
                    tmpList.Add(product);
                }
            }

            await Task.CompletedTask;
            return tmpList;
        }

        public async Task<Product> GetProductFromId(int id)
        {
            var tmp = Db.Get<Product>(id);
            await Task.CompletedTask;
            return tmp;
        }

        public async Task<List<Product>> GetProductsFromCategory(int categoryId, string searchName)
        {
            TableQuery<Product> query = new TableQuery<Product>(Db);
            if (searchName == null)
            {
                query = from product in Db.Table<Product>()
                where product.Category01.Equals(categoryId) ||
                      product.Category02.Equals(categoryId) ||
                      product.Category03.Equals(categoryId)
                orderby product.Name
                select product;
            }
            else
            {
                query = from product in Db.Table<Product>()
                where (product.Category01.Equals(categoryId) ||
                      product.Category02.Equals(categoryId) ||
                      product.Category03.Equals(categoryId)) &&
                      product.Name.ToLower().Contains(searchName.ToLower())
                orderby product.Name
                select product;
            }
            
            List<Product> tmpList = new List<Product>();
            foreach (Product product in query)
            {
                tmpList.Add(product);
            }

            await Task.CompletedTask;
            return tmpList;
        }

        public async Task<Product> GetRandomProduct()
        {
            await Task.CompletedTask;
            return Db.Query<Product>("SELECT * FROM Product ORDER BY RANDOM() LIMIT 1;")[0];
        }

        #endregion

        #region Favorites

        public async Task<List<Product>> GetFavorites()
        {
            var query = from product in Db.Table<Product>()
                where product.IsFavorite == true
                orderby product.Name
                select product;
            List<Product> tmpList = new List<Product>();
            foreach (var item in query)
            {
                tmpList.Add(item);
            }
            await Task.CompletedTask;
            return tmpList;
        }

        public async Task AddRemoveFavoriteProduct(Product product)
        {
            Db.Update(product);
            await Task.CompletedTask;
        }

        #endregion
    }
}