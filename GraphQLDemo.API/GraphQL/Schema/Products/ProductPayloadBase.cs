using GraphQLDemo.API.Common;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.GraphQL.Schema.Products
{
    public class ProductPayloadBase : Payload
    {
        protected ProductPayloadBase(Product product)
        {
            Product = product;
        }

        protected ProductPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {

        }

        public Product? Product { get; }

    }
}
