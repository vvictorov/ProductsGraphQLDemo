using GraphQL.Types;
using RestaurantGraphQL.Data.Repositories;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Api.Models
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository categoryRepository, IProductImageRepository productImageRepository)
        {
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Stock);
            Field(x => x.Unit);
            Field<CategoryType>("category",
                resolve: context => categoryRepository.Get(context.Source.CategoryId));
            Field<ProductImageType>("cover",
                resolve: context => productImageRepository.Get(context.Source.CoverId.GetValueOrDefault()));
        }
    }
}