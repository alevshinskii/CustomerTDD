using FluentValidation;

namespace Customer
{
    public class AddressValidator : AbstractValidator<Address>
    {
        private const int AddressLineMaxLength = 100;
        private const int CityMaxLength = 50;
        private static readonly List<string> AllowedCountries = new() { "United States", "Canada" };
        private const int PostalCodeMaxLength = 6;
        private const int StateMaxLength = 20;


        public AddressValidator()
        {

            RuleFor(address => address.AddressLine).NotNull().MaximumLength(AddressLineMaxLength).WithMessage("Invalid address property: AddressLine");

            RuleFor(address => address.AddressLine2).MaximumLength(AddressLineMaxLength).WithMessage("Invalid address property: AddressLine2");

            RuleFor(address => address.AddressType).NotEqual(AddressType.Unknown).WithMessage("Invalid address property: AddressType");

            RuleFor(address => address.City).MaximumLength(CityMaxLength).WithMessage("Invalid address property: City");

            RuleFor(address => address.Country).Must(country => AllowedCountries.Contains(country,StringComparer.OrdinalIgnoreCase)).WithMessage("Invalid address property: Country");

            RuleFor(address => address.PostalCode).MaximumLength(PostalCodeMaxLength).WithMessage("Invalid address property: PostalCode");

            RuleFor(address => address.State).MaximumLength(StateMaxLength).WithMessage("Invalid address property: State");

        }
    }

}

