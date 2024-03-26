namespace GraphQLDemo.API.GraphQL.Schema.Customers
{
    public record CustomerInput(
        string Name,
        string Email,
        string Phone
    );
}
