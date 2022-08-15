namespace Customer
{
    public class AddressValidator
    {
        private const int _addressLineMaxLength = 100;
        private const int _cityMaxLength = 50;
        private static List<string> _allowedCountries = new List<string>() { "United States", "Canada" };
        private const int _postalCodeMaxLength = 6;
        private const int _stateMaxLength = 20;

        public static List<string> Validate(Address address)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(address.AddressLine) || address.AddressLine.Length > _addressLineMaxLength)
            {
                errors.Add("Invalid address property: AddressLine");
            }
            if (address.AddressLine2!=null && address.AddressLine2.Length > _addressLineMaxLength)
            {
                errors.Add("Invalid address property: AddressLine2");
            }
            if (address.AddressType == AddressType.Unknown)
            {
                errors.Add("Invalid address property: AddressType");
            }
            if (string.IsNullOrEmpty(address.City) || address.City.Length > _cityMaxLength)
            {
                errors.Add("Invalid address property: City");
            }
            if (!_allowedCountries.Contains(address.Country))
            {
                errors.Add("Invalid address property: Country");
            }
            if (string.IsNullOrEmpty(address.PostalCode) || address.PostalCode.Length > _postalCodeMaxLength)
            {
                errors.Add("Invalid address property: PostalCode");
            }
            if (string.IsNullOrEmpty(address.State) || address.State.Length > _stateMaxLength)
            {
                errors.Add("Invalid address property: State");
            }
            
            return errors;
        }
    }
}
