using System.Collections.Generic;
using System.Threading.Tasks;
using Kinkdom.Models;

namespace Kinkdom.Services.Interfaces
{
    public interface ILocalDatabaseService
    {
        Task ReloadData();

        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryFromId(int id);

        Task<List<Product>> GetProducts();
        Task<Product> GetProductFromId(int id);
        Task<List<Product>> GetProductsFromCategory(int categoryId);
        Task<Product> GetRandomProduct();

        Task<List<Product>> GetFavorites();
        Task AddRemoveFavoriteProduct(Product product);
    }
}