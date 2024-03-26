using GraphQLDemo.API.Data;
using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.GraphQL.Schema.Products
{

    [ExtendObjectType("Mutation")]
    public class ProductMutations
    {

        public async Task<ProductPayloads> AddProduct(
            ProductInput input,
            [Service] IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {

            await using var context = dbContextFactory.CreateDbContext();
            var product = new Product()
            {
                Title = input.Title,
                Description = input.Description,
                Price = input.Price,
                Stock = input.Stock
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return new ProductPayloads(product);
        }
    }
}
