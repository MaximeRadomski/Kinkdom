using System;
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
            if (!Db.Table<Category>().Any())
            {
                List<Category> allCategories = await _fakeDataService.SetAllCategories();
                foreach (var category in allCategories)
                {
                    Db.Insert(category);
                }
            }
        }

        public async Task<Category> GetCategoryFromId(int id)
        {
            var tmp = Db.Get<Category>(id);
            await Task.CompletedTask;
            if (tmp != null)
                return Db.Get<Category>(id);
            return null;
        }

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
    }
}