using GraphQLDemo.API.Common;
using GraphQLDemo.API.Entities;
using System.Collections.Generic;


namespace GraphQLDemo.API.GraphQL.Schema.Products
{
    public class ProductPayloads : ProductPayloadBase
    {
        public ProductPayloads(Product product)
            : base(product)
        {
        }

        public ProductPayloads(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}