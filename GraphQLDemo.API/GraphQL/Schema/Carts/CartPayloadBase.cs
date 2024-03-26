using GraphQLDemo.API.Common;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.GraphQL.Schema.Carts
{
    public class CartPayloadBase : Payload
    {
        protected CartPayloadBase(Cart cart)
        {
            Cart = cart;
        }

        protected CartPayloadBase(IReadOnlyList<UserError> errors) : base(errors) { }


        public Cart? Cart { get; }

    }
}
