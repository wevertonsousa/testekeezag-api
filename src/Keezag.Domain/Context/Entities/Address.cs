namespace Keezag.Domain.Context.Entities
{
    public class Address
    {
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FederatedUnit { get; set; }
    }
}
