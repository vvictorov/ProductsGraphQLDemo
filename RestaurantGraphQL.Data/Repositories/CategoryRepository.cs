using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantGraphQL.Core.Interfaces;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductsDbContext _db;

        public CategoryRepository(ProductsDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Category> Get(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<List<Category>> All()
        {
            return await _db.Categories.ToListAsync();
        }

        public List<Category> AllSynchronous()
        {
            return _db.Categories.ToList();
        }

        public async Task<Category> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(int id, Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
