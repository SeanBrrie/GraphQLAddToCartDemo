using GraphQLDemo.API.Common;
using GraphQLDemo.API.Entities;
using System.Collections.Generic;


namespace GraphQLDemo.API.GraphQL.Schema.Customers
{
    public class CustomerPayloads : CustomerPayloadBase
    {
        public CustomerPayloads(Customer customer)
            : base(customer)
        {
        }

        public CustomerPayloads(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}