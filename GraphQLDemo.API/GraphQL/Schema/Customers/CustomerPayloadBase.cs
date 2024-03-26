using GraphQLDemo.API.Common;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.GraphQL.Schema.Customers
{
    public class CustomerPayloadBase : Payload
    {
        protected CustomerPayloadBase(Customer customer)
        {
            Customer = customer;
        }

        protected CustomerPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {

        }

        public Customer? Customer { get; }

    }
}
