using RestaurantGraphQL.Application.Dto;
using System.Threading.Tasks;

namespace RestaurantGraphQL.Application
{
    public interface IProductsAppService
    {
        Task<CrudProductOutput> CreateProduct(ProductInput input);
        Task<CrudProductOutput> UpdateProduct(ProductInput input);
    }
}