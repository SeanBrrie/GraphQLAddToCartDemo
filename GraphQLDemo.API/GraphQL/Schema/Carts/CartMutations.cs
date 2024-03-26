using GraphQLDemo.API.Common;
using GraphQLDemo.API.Data;
using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GraphQLDemo.API.GraphQL.Schema.Carts
{

    [ExtendObjectType("Mutation")]
    public class CartMutations
    {

        public async Task<CartPayload> UpdateCart(
            ProductCartInput input,
            [Service] IDbContextFactory<ApplicationDbContext> dbContextFactory
         )
        {
            await using var context = dbContextFactory.CreateDbContext();

            // Finds and returns the cart by id
            var cart = await FindCartAsync(context, input.CartId);
            if (cart == null) return new CartPayload(new List<UserError> { new UserError("Cart not found.", "NOT_FOUND") });

            // Finds and returns the product by id
            var product = await FindProductAsync(context, input.ProductId);
            if (product == null) return new CartPayload(new List<UserError> { new UserError("Product not found.", "NOT_FOUND") });

            // Finds and returns the cart_product by cart id and product id
            var cartProduct = FindOrCreateCartProduct(cart, product);

            // Adjusts the quantity of the cart_product based on the operation type
            AdjustQuantity(cart, cartProduct, input.Quantity, input.OperationType);

            await context.SaveChangesAsync();
            return new CartPayload(cart);
        }

        private async Task<Cart> FindCartAsync(ApplicationDbContext context, int cartId)
        {
            return await context.Carts
                .Include(c => c.CartProducts)
                .FirstOrDefaultAsync(c => c.Id == cartId);
        }

        private async Task<Product> FindProductAsync(ApplicationDbContext context, int productId)
        {
            // Finds and returns the product with the specified ID, or null if not found.
            return await context.Products.FindAsync(productId);
        }

        private CartProduct FindOrCreateCartProduct(Cart cart, Product product)
        {
            // Finds a CartProduct for the given cart and product and creates it if it doesn't exist.
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == product.Id);
            if (cartProduct == null)
            {
                cartProduct = new CartProduct
                {
                    CartId = cart.Id,
                    Cart = cart,
                    ProductId = product.Id,
                    Product = product,
                    Quantity = 0 // Initialize with 0 since quantity will be adjusted later.
                };
                cart.CartProducts.Add(cartProduct);
            }
            return cartProduct;
        }

        private void AdjustQuantity(Cart cart, CartProduct cartProduct, int quantity, OperationType operation)
        {
            // Adjusts the quantity of a CartProduct based on the operation type.
            switch (operation)
            {
                case OperationType.ADD:
                    cartProduct.Quantity += quantity;
                    break;
                case OperationType.REMOVE:
                    cartProduct.Quantity -= quantity;
                    if (cartProduct.Quantity < 0) cart.CartProducts.Remove(cartProduct);
                    break;

            }
        }


    }


}
