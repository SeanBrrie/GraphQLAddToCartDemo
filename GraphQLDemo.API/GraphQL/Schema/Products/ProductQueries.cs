using System.Security.Cryptography;
using GraphQLDemo.API.Data;
using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.GraphQL.Schema.Products
{

    [ExtendObjectType("Query")]
    public class ProductQueries
    {


        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public ProductQueries(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public async Task<IEnumerable<Product>> GetProducts(
                       CancellationToken cancellationToken)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetProductById(
            [ID(nameof(Product))] int id,
            CancellationToken cancellationToken)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Products.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

    }


}
