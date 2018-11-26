using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api.Models
{
    public class RestaurantGraphQLQuery : ObjectGraphType
    {
        public RestaurantGraphQLQuery(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            Name = "Queries";
            
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.All()
            );

            Field<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => productRepository.Get(context.GetArgument<int>("id"))
            );
            
            Field<ListGraphType<CategoryType>>(
                "categories",
                resolve: context => categoryRepository.All()
            );
            
            Field<CategoryType>("category",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => categoryRepository.Get(context.GetArgument<int>("id"))
            );
        }
    }
}
