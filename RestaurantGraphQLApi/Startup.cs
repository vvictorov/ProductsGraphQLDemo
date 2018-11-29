using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RestaurantGraphQL.Api.Models;
using RestaurantGraphQL.Data;
using RestaurantGraphQL.Data.Repositories;

namespace RestaurantGraphQL.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ProductsDbContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql);
                })
            );

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ProductType>();
            services.AddSingleton<CategoryType>();
            services.AddSingleton<ProductInputType>();
            services.AddSingleton<UnitEnumType>();
            services.AddSingleton<ProductImageType>();

            services.AddSingleton<RestaurantGraphQLQuery>();
            services.AddSingleton<RestaurantGraphQLMutation>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RestaurantGraphQLSchema(new FuncDependencyResolver(type => sp.GetService(type))));

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
