namespace Customer
{
    public class Address
    {

        public string AddressLine { get; set; } = String.Empty;

        public string? AddressLine2 { get; set; }

        public AddressType AddressType { get; set; } = AddressType.Unknown;

        public string City { get; set; } = String.Empty;

        public string PostalCode { get; set; } = String.Empty;

        public string State { get; set; } = String.Empty;

        public string Country { get; set; } = String.Empty;
    }
}
