using FluentValidation;

namespace Customer
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private const int FirstNameMaxLength = 50;
        private const int LastNameMaxLength = 50;
        private const int PhoneNumberMaxLength = 15;

        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).MaximumLength(FirstNameMaxLength).WithMessage("Invalid customer property: FirstName");

            RuleFor(customer => customer.LastName).NotNull().MaximumLength(LastNameMaxLength)
                .WithMessage("Invalid customer property: LastName");

            RuleFor(customer => customer.Addresses).NotEmpty().WithMessage("Invalid customer property: Addresses");

            RuleFor(customer => customer.PhoneNumber).Matches(@"^\d{12,15}$").WithMessage("Invalid customer property: PhoneNumber").MaximumLength(PhoneNumberMaxLength).WithMessage("Invalid customer property: PhoneNumber");

            RuleFor(customer => customer.Notes).NotEmpty().WithMessage("Invalid customer property: Notes");

            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Invalid customer property: Email");

            RuleFor(customer => customer.TotalPurchasesAmount).GreaterThanOrEqualTo(0)
                .WithMessage("Invalid customer property: TotalPurchasesAmount");
        }
    }
}
