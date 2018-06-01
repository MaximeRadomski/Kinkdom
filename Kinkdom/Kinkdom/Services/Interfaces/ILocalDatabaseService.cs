using System.Collections.Generic;
using System.Threading.Tasks;
using Kinkdom.Models;

namespace Kinkdom.Services.Interfaces
{
    public interface ILocalDatabaseService
    {
        Task<Category> GetCategoryFromId(int id);
        Task<List<Category>> GetCategories();
    }
}