using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _db;

        public ProductRepository(ProductsDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Product> Get(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<List<Product>> All()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> Create(Product product)
        {
            var addedProduct = await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            
            return product;
        }

        public async Task<Product> Update(int id, Product input)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            product.Title = input.Title;
            product.Stock = input.Stock;
            product.Unit = input.Unit;
            product.CategoryId = input.CategoryId;

            _db.Products.Update(product);
            await _db.SaveChangesAsync();

            return product;
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Product>> GetByCategoryId(int categoryId)
        {
            return await _db.Products
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}