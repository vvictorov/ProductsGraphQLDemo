using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> Get(int id);
        Task<List<Category>> All();
        Task<Category> Create(Category category);
        Task<Category> Update(int id, Category category);
        Task<bool> Delete(int id);
    }
}