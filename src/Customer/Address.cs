namespace Customer
{
    public class Address
    {

        public string AddressLine { get; set; }

        public string? AddressLine2 { get; set; }

        public AddressType AddressType { get; set; } = AddressType.Unknown;

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
