using GraphQLDemo.API.Common;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.GraphQL.Schema.Carts
{
    public class CartPayload : CartPayloadBase
    {
        public CartPayload(Cart cart)
            : base(cart)
        {
        }

        public CartPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }

}