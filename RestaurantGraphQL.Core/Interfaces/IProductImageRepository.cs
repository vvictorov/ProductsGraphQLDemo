using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Core.Interfaces
{
    public interface IProductImageRepository
    {
        Task<ProductImage> Get(int id);
        Task<List<ProductImage>> All();
        Task<ProductImage> Create(ProductImage image);
        Task<ProductImage> Update(int id, ProductImage image);
        Task<bool> Delete(int id);
        Task<List<ProductImage>> GetByProductId(int productId);
    }
}