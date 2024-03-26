using GraphQLDemo.API.Data;
using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.GraphQL.Schema.Customers
{

    [ExtendObjectType("Mutation")]
    public class CustomerMutations
    {

        public async Task<CustomerPayloads> AddCustomer(
            CustomerInput input,
            [Service] IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {

            await using var context = dbContextFactory.CreateDbContext();
            var customer = new Customer()
            {
                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
            };

            context.Customers.Add(customer);
            context.Carts.Add(customer.Cart);
            await context.SaveChangesAsync();

            return new CustomerPayloads(customer);
        }
    }
}
