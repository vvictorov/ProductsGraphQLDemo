using Microsoft.Extensions.DependencyInjection;
using RestaurantGraphQL.Application;
using RestaurantGraphQL.Core.Interfaces;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api.Providers
{
    public static class BServiceDependencyProvider
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProductsAppService, ProductsAppService>();
        }
    }
}