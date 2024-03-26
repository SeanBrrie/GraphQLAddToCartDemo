namespace GraphQLDemo.API.GraphQL.Schema.Products
{
    public record ProductInput(
        string Title,
        string Description,
        float Price,
        int Stock
    );
}
