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
            Task.Run(async () => await LoadTables());
        }

        private void LoadDatabase()
        {
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "kinkdom.db3");
            Db = new SQLiteConnection(dbPath);
        }

        public async Task LoadTables()
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
            for (int i = 0; i < Db.Table<Category>().Count(); i++)
            {
                Debug.WriteLine("   [Debug] : " + Db.Get<Category>(i).Description);
            }
            Category tmp;
            try
            {
                tmp = Db.Get<Category>(id);
            }
            catch (Exception e)
            {
                return null;
            }
            if (tmp != null)
                return Db.Get<Category>(id);
            return null;
        }
    }
}