using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<List<Product>> All();
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(int id);
        Task<List<Product>> GetByCategoryId(int categoryId);
    }
}