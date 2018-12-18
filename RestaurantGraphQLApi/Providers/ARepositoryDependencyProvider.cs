using Microsoft.Extensions.DependencyInjection;
using RestaurantGraphQL.Core.Interfaces;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api.Providers
{
    public static class ARepositoryDependencyProvider
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
        }
    }
}