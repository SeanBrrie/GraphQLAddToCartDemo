using System.Security.Cryptography;
using GraphQLDemo.API.Carts;
using GraphQLDemo.API.Data;
using GraphQLDemo.API.Entities;

namespace GraphQLDemo.API.GraphQL.Schema.Carts
{

    [ExtendObjectType("Query")]
    public class CartQueries
    {

        public Task<Cart> GetCartByIdAsync(
            [ID(nameof(Cart))] int id,
            CartDataLoaders dataLoader,
            CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);

    }


}
