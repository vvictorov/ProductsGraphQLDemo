using GraphQL.Types;
using RestaurantGraphQL.Data.Repositories;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Core.Enums;

namespace RestaurantGraphQL.Api.Models
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository categoryRepository, IProductImageRepository productImageRepository)
        {
            Name = "Product";

            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Stock);
            Field<UnitEnumType>("unit", 
                resolve: context => context.Source.UnitEnum);
            Field<NonNullGraphType<CategoryType>>("category",
                resolve: context => categoryRepository.Get(context.Source.CategoryId));
            Field<ProductImageType>("cover",
                resolve: context => productImageRepository.Get(context.Source.CoverId.GetValueOrDefault()));
        }
    }
}