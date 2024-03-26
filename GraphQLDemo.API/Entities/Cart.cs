namespace GraphQLDemo.API.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    }
}
