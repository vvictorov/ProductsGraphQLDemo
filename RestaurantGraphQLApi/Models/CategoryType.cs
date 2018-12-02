using GraphQL.Types;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api.Models
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Name = "Category";

            Field(x => x.Id);
            Field(x => x.Title);
            Field<ListGraphType<ProductType>>("products",
                resolve: context => productRepository.GetByCategoryId(context.Source.Id));
        }
    }
}