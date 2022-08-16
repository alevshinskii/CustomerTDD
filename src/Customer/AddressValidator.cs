using StringExtension;

namespace Customer
{
    public class AddressValidator
    {
        private const int AddressLineMaxLength = 100;
        private const int CityMaxLength = 50;
        private static readonly List<string> AllowedCountries = new() { "United States", "Canada" };
        private const int PostalCodeMaxLength = 6;
        private const int StateMaxLength = 20;

        public static List<string> Validate(Address address)
        {
            var errors = new List<string>();

            if (address.AddressLine.ValidateNullAndMaxLength(AddressLineMaxLength))
            {
                errors.Add("Invalid address property: AddressLine");
            }
            if (address.AddressLine2?.Length > AddressLineMaxLength)
            {
                errors.Add("Invalid address property: AddressLine2");
            }
            if (address.AddressType == AddressType.Unknown)
            {
                errors.Add("Invalid address property: AddressType");
            }
            if (address.City.ValidateNullAndMaxLength(CityMaxLength))
            {
                errors.Add("Invalid address property: City");
            }
            if (!AllowedCountries.Contains(address.Country, StringComparer.OrdinalIgnoreCase))
            {
                errors.Add("Invalid address property: Country");
            }
            if (address.PostalCode.ValidateNullAndMaxLength(PostalCodeMaxLength))
            {
                errors.Add("Invalid address property: PostalCode");
            }
            if (address.State.ValidateNullAndMaxLength(StateMaxLength))
            {
                errors.Add("Invalid address property: State");
            }

            return errors;
        }
    }

}

