using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using RestaurantGraphQL.Application;
using RestaurantGraphQL.Core.Interfaces;
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

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddCors();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.GetName()
                        .Name
                        .StartsWith("RestaurantGraphQL")
                );

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(t => t.IsClass && t.IsPublic && t.Name.Contains("DependencyProvider")); // You can create your own convention here, make sure it won't conflict with other class names that are not meant to be installers

                var installerTypes = types.ToList();
                if (!installerTypes.Any()) continue;

                foreach (var installerType in installerTypes)
                {
                    LoadInstaller(installerType, services);
                }
            }
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

        void LoadInstaller(Type type, IServiceCollection services)
        {
            var installMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(mi => mi.Name == "RegisterDependencies");

            var installMethod = installMethods.FirstOrDefault();

            if (installMethod == null)
            {
                return;
            }

            installMethod.Invoke(null, new object[] { services });
        }
    }
}
