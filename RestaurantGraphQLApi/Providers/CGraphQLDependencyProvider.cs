using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using RestaurantGraphQL.Api.Models;
using RestaurantGraphQL.Core.Interfaces;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api.Providers
{
    public static class CGraphQLDependencyProvider
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ProductType>();
            services.AddSingleton<CategoryType>();
            services.AddSingleton<ProductInputType>();
            services.AddSingleton<UnitEnumType>();
            services.AddSingleton<ProductImageType>();

            services.AddSingleton<RestaurantGraphQLQuery>();
            services.AddSingleton<RestaurantGraphQLMutation>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RestaurantGraphQLSchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }
    }
}