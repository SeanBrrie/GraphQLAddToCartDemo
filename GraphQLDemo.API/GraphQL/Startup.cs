using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.API.Carts;
using GraphQLDemo.API.Data;
using GraphQLDemo.API.GraphQL.Schema.Carts;
using GraphQLDemo.API.GraphQL.Schema.Customers;
using GraphQLDemo.API.GraphQL.Schema.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLDemo.API.GraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
  
            services.AddPooledDbContextFactory<ApplicationDbContext>(
                options => options.UseNpgsql(_configuration.GetConnectionString("PostgreSQL")));


            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<CartQueries>()
                    .AddTypeExtension<CustomerQueries>()
                    .AddTypeExtension<ProductQueries>()

                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<CustomerMutations>()
                    .AddTypeExtension<CartMutations>()
                    .AddTypeExtension<ProductMutations>()

                .AddDataLoader<CartDataLoaders>()
                .AddFiltering();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}