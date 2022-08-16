namespace Customer
{
    public class Customer : Person
    {

        public override string? FirstName { get; set; } = String.Empty;
        public override string LastName { get; set; } = String.Empty;

        public List<Address> Addresses { get; set; } = new List<Address>();

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<string> Notes { get; set; } = new List<string>();
        public decimal? TotalPurchasesAmount { get; set; }
    }
}