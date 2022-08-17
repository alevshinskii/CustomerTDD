using Bogus;
using System.Text;

namespace Customer.Test
{
    public class CustomerTest
    {
        private readonly CustomerValidator _validator = new();
        private Faker faker = new Faker("en");

        [Fact]
        public void ShouldBeAbleToCreate()
        {
            Customer customer = new Customer();
        }

        [Fact]
        public void ShouldBeAbleToValidate()
        {
            Customer customer = new Customer();
            var validationResult = _validator.Validate(customer);

        }

        [Fact]
        public void ShouldValidateFirstName()
        {
            Customer customer = new Customer();
            customer.FirstName = "Name";

            var validationResult = _validator.Validate(customer);
            string errorMessageForFirstName = "Invalid customer property: FirstName";
            
            Assert.DoesNotContain(errorMessageForFirstName,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateNullFirstName()
        {
            Customer customer = new Customer();
            customer.FirstName = null;

            var validationResult = _validator.Validate(customer);
            string errorMessageForFirstName = "Invalid customer property: FirstName";
            
            Assert.DoesNotContain(errorMessageForFirstName,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongFirstName()
        {
            Customer customer = new Customer();
            customer.FirstName = faker.Random.String(51);

            var validationResult = _validator.Validate(customer);
            string errorMessageForFirstName = "Invalid customer property: FirstName";

            Assert.Contains(errorMessageForFirstName,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateLastName()
        {
            Customer customer = new Customer();
            customer.LastName = faker.Random.String(50);

            var validationResult = _validator.Validate(customer);
            string errorMessageForLastName = "Invalid customer property: LastName";

            Assert.DoesNotContain(errorMessageForLastName,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongLastName()
        {
            Customer customer = new Customer();
            customer.LastName = faker.Random.String(51);

            var validationResult = _validator.Validate(customer);
            string errorMessageForLastName = "Invalid customer property: LastName";

            Assert.Contains(errorMessageForLastName,validationResult.Errors.Select(error => error.ErrorMessage));
        }


        [Fact]
        public void ShouldValidateAddresses()
        {
            Customer customer = new Customer();
            customer.Addresses.Add(new Address());

            var validationResult = _validator.Validate(customer);
            string errorMessageForAddresses = "Invalid customer property: Addresses";
            
            Assert.DoesNotContain(errorMessageForAddresses,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongAddresses()
        {
            Customer customer = new Customer();
            customer.Addresses.Clear();

            var validationResult = _validator.Validate(customer);
            string errorMessageForAddresses = "Invalid customer property: Addresses";

            Assert.Contains(errorMessageForAddresses,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateEmail()
        {
            Customer customer = new Customer();
            customer.Email = "email@gmail.com";

            var validationResult = _validator.Validate(customer);
            string errorMessageForEmail = "Invalid customer property: Email";
            
            Assert.DoesNotContain(errorMessageForEmail,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongEmail()
        {
            Customer customer = new Customer();
            customer.Email = "email@@gmail.com";

            var validationResult = _validator.Validate(customer);
            string errorMessageForEmail = "Invalid customer property: Email";

            Assert.Contains(errorMessageForEmail,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateNotes()
        {
            Customer customer = new Customer();
            customer.Notes.Add("new note");

            var validationResult = _validator.Validate(customer);
            string errorMessageForNotes = "Invalid customer property: Notes";
            
            Assert.DoesNotContain(errorMessageForNotes,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongNotes()
        {
            Customer customer = new Customer();
            customer.Notes.Clear();

            var validationResult = _validator.Validate(customer);
            string errorMessageForNotes = "Invalid customer property: Notes";

            Assert.Contains(errorMessageForNotes,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidatePhoneNumber()
        {
            Customer customer = new Customer();
            customer.PhoneNumber = "123456789111";

            var validationResult = _validator.Validate(customer);
            string errorMessageForPhoneNumber = "Invalid customer property: PhoneNumber";
            
            Assert.DoesNotContain(errorMessageForPhoneNumber, validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongPhoneNumber()
        {
            Customer customer = new Customer();
            customer.PhoneNumber = "a123094234";

            var validationResult = _validator.Validate(customer);
            string errorMessageForPhoneNumber = "Invalid customer property: PhoneNumber";

            Assert.Contains(errorMessageForPhoneNumber,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateTooLongPhoneNumber()
        {
            Customer customer = new Customer();
            customer.PhoneNumber = faker.Random.String(16, '0', '9');

            var validationResult = _validator.Validate(customer);
            string errorMessageForPhoneNumber = "Invalid customer property: PhoneNumber";

            Assert.Contains(errorMessageForPhoneNumber,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateTotalPurchasesAmount()
        {
            Customer customer = new Customer();
            customer.TotalPurchasesAmount = 10492194;

            var validationResult = _validator.Validate(customer);
            string errorMessageForTotalPurchasesAmount = "Invalid customer property: TotalPurchasesAmount";
            
            Assert.DoesNotContain(errorMessageForTotalPurchasesAmount,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldBeAbleToHaveNullValueInTotalPurchsesAmount()
        {
            Customer customer = new Customer();

            customer.TotalPurchasesAmount = null;

            var validationResult = _validator.Validate(customer);
            string errorMessageForTotalPurchaseAmount = "Invalid customer property: TotalPurchasesAmount";
            
            Assert.DoesNotContain(errorMessageForTotalPurchaseAmount,validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidatorCheckAllFields()
        {
            Customer customer = new Customer();
            

            customer.FirstName = faker.Random.String(101);
            customer.LastName =faker.Random.String(101);
            customer.Addresses.Clear();
            customer.Email = "invalid-email";
            customer.Notes.Clear();
            customer.PhoneNumber = faker.Random.String(12);
            customer.TotalPurchasesAmount = -1;

            var validationResult = _validator.Validate(customer);

            var expectedValidationResult = new List<string>()
            {
                "Invalid customer property: FirstName",
                "Invalid customer property: LastName",
                "Invalid customer property: Addresses",
                "Invalid customer property: PhoneNumber",
                "Invalid customer property: Notes",
                "Invalid customer property: Email",
                "Invalid customer property: TotalPurchasesAmount"
            };

            Assert.Equal(expectedValidationResult, validationResult.Errors.Select(error => error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidatorHaveNoErrorsIfValid()
        {
            Customer customer = new Customer();

            customer.FirstName = "Name";
            customer.LastName = "Name";
            customer.Addresses.Add(new Address());
            customer.Email = "valid-email@gmail.com";
            customer.Notes.Add("new note");
            customer.PhoneNumber = "094898019348";
            customer.TotalPurchasesAmount = 100;

            var validationResult = _validator.Validate(customer);
            
            Assert.Empty(validationResult.Errors);
        }
    }
}