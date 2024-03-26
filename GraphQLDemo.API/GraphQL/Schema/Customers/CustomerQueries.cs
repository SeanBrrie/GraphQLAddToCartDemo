using System.Security.Cryptography;
using GraphQLDemo.API.GraphQL.Schema.Carts;
using GraphQLDemo.API.Data;
using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.GraphQL.Schema.Customers
{

    [ExtendObjectType("Query")]
    public class CustomerQueries
    {

        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public CustomerQueries(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Customer> GetCustomerByIdAsync(
            [ID(nameof(Customer))] int id,
            CancellationToken cancellationToken)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

    }
}
