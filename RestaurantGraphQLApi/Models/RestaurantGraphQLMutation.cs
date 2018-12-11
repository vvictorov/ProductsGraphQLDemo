using System.Threading.Tasks;
using GraphQL.Types;
using RestaurantGraphQL.Application;
using RestaurantGraphQL.Application.Dto;
using RestaurantGraphQL.Core.Interfaces;
using RestaurantGraphQL.Core.Models;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api.Models
{
    public class RestaurantGraphQLMutation : ObjectGraphType
    {
        public RestaurantGraphQLMutation(IProductsAppService _productsAppService)
        {
            Name = "Mutation";
            
            FieldAsync<ProductType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
                ),
                resolve: async context =>
                {
                    var input = context.GetArgument<ProductInput>("product");
                    var result = await _productsAppService.CreateProduct(input);

                    return result.Entity;
                });

            FieldAsync<ProductType>(
                "updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
                ),
                resolve: async context =>
                {
                    var input = context.GetArgument<ProductInput>("product");
                    var result = await _productsAppService.UpdateProduct(input);

                    return result.Entity;
                });
        }
    }
}