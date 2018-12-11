using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantGraphQL.Core.Interfaces;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Data.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ProductsDbContext _db;

        public ProductImageRepository(ProductsDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<ProductImage> Get(int id)
        {
            return await _db.ProductImages.FindAsync(id);
        }

        public async Task<List<ProductImage>> All()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProductImage> Create(ProductImage image)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProductImage> Update(int id, ProductImage image)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProductImage>> GetByProductId(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}