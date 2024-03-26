namespace GraphQLDemo.API.Entities
{
    public class BillingAddress
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}