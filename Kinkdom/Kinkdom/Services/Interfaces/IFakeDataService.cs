using System.Collections.Generic;
using System.Threading.Tasks;
using Kinkdom.Models;

namespace Kinkdom.Services.Interfaces
{
    public interface IFakeDataService
    {
        Task<List<Category>> SetAllCategories();
        Task<int> CountAllCategories();
        Task<List<Product>> SetAllProducts();
        Task<int> CountAllProducts();
    }
}