using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<List<Product>> All();
        Task<Product> Create(Product product);
        Task<Product> Update(int id, Product product);
        Task<bool> Delete(int id);
        Task<List<Product>> GetByCategoryId(int categoryId);
    }
}