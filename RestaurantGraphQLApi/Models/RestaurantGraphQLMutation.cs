using GraphQL.Types;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api.Models
{
    public class RestaurantGraphQLMutation : ObjectGraphType
    {
        public RestaurantGraphQLMutation(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            Name = "Mutation";
            
            Field<ProductType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
                ),
                resolve: context =>
                {
                    var product = context.GetArgument<Product>("product");
                    var test = "";
                    return productRepository.Create(product);
                });
        }
    }
}