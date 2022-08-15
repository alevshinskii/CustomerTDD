using System.Text;

namespace Customer.Test
{
    public class CustomerTest
    {
        [Fact]
        public void SouldBeAbleToCreate()
        {
            Customer customer = new Customer();
        }

        [Fact]
        public void SouldBeAbleToValidate()
        {
            Customer customer = new Customer();
            var validationResult = CustomerValidator.Validate(customer);

        }

        private const string _longString =
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        [Fact]
        public void SouldValidateFirstName()
        {
            Customer customer = new Customer();
            customer.FirstName = "Name";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForFirstName = "Invalid customer property: FirstName";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForFirstName,validationResult);

            customer.FirstName = _longString;

            validationResult = CustomerValidator.Validate(customer);

            Assert.Contains(errorMessageForFirstName,validationResult);
        }

        [Fact]
        public void SouldValidateLastName()
        {
            Customer customer = new Customer();
            customer.LastName = "Name";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForLastName = "Invalid customer property: LastName";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForLastName,validationResult);

            customer.LastName = _longString;

            validationResult = CustomerValidator.Validate(customer);

            Assert.Contains(errorMessageForLastName,validationResult);
        }

        [Fact]
        public void SouldValidateAddresses()
        {
            Customer customer = new Customer();
            customer.Addresses.Add(new Address());

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForAddresses = "Invalid customer property: Addresses";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForAddresses,validationResult);

            customer.Addresses.Clear();

            validationResult = CustomerValidator.Validate(customer);

            Assert.Contains(errorMessageForAddresses,validationResult);

        }

        [Fact]
        public void SouldValidateEmail()
        {
            Customer customer = new Customer();
            customer.Email = "email@gmail.com";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForEmail = "Invalid customer property: Email";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForEmail,validationResult);

            customer.Email = "email@@gmail.com";

            validationResult = CustomerValidator.Validate(customer);

            Assert.Contains(errorMessageForEmail,validationResult);
        }

        [Fact]
        public void SouldValidateNotes()
        {
            Customer customer = new Customer();
            customer.Notes.Add("new note");

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForNotes = "Invalid customer property: Notes";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForNotes,validationResult);
            
            customer.Notes.Clear();

            validationResult = CustomerValidator.Validate(customer);

            Assert.Contains(errorMessageForNotes,validationResult);
        }

        [Fact]
        public void SouldValidatePhoneNumber()
        {
            Customer customer = new Customer();
            customer.PhoneNumber="123456789111";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForPhoneNumber = "Invalid customer property: PhoneNumber";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForPhoneNumber,validationResult);

            customer.PhoneNumber="a1230914234";

            validationResult = CustomerValidator.Validate(customer);

            Assert.Contains(errorMessageForPhoneNumber,validationResult);

            customer.PhoneNumber="1230914234124124124";

            validationResult = CustomerValidator.Validate(customer);

            Assert.Contains(errorMessageForPhoneNumber,validationResult);
        }

        [Fact]
        public void SouldValidateTotalPurchasesAmount()
        {
            Customer customer = new Customer();
            customer.TotalPurchasesAmount=10492194;

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForTotalPurchasesAmount = "Invalid customer property: TotalPurchasesAmount";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForTotalPurchasesAmount,validationResult);
        }

        [Fact]
        public void SouldBeAbleToHaveNullValueInTotalPurchsesAmount()
        {
            Customer customer = new Customer();

            customer.TotalPurchasesAmount = null;

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForInvalidTotalPurchaseAmount = "Invalid customer property: TotalPurchasesAmount";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForInvalidTotalPurchaseAmount,validationResult);
        }

        [Fact]
        public void ShouldValidatorCheckAllFields()
        {
            Customer customer = new Customer();

            var longStringBuilder = new StringBuilder();
            for (int i = 0; i < 101; i++)
            {
                longStringBuilder.Append("a");
            }
            var longString = longStringBuilder.ToString();


            customer.FirstName=longString;
            customer.LastName=longString;
            customer.Addresses.Clear();
            customer.Email = "invalid-email";
            customer.Notes.Clear();
            customer.PhoneNumber = longString;
            customer.TotalPurchasesAmount = -1;

            var validationResult = CustomerValidator.Validate(customer);

            var expectedValidationResult = new List<string>()
            {
                "Invalid customer property: FirstName",
                "Invalid customer property: LastName",
                "Invalid customer property: Addresses",
                "Invalid customer property: PhoneNumber",
                "Invalid customer property: Email",
                "Invalid customer property: Notes",
                "Invalid customer property: TotalPurchasesAmount"
            };

            Assert.Equal(expectedValidationResult,validationResult);
        }

        [Fact]
        public void ShouldValidatorHaveNoErrorsIfValid()
        {
            Customer customer = new Customer();

            var longStringBuilder = new StringBuilder();
            for (int i = 0; i < 101; i++)
            {
                longStringBuilder.Append("a");
            }
            var longString = longStringBuilder.ToString();


            customer.FirstName="Name";
            customer.LastName="Name";
            customer.Addresses.Add(new Address());
            customer.Email = "valid-email@gmail.com";
            customer.Notes.Add("new note");
            customer.PhoneNumber = "0948019348";
            customer.TotalPurchasesAmount = 100;

            var validationResult = CustomerValidator.Validate(customer);

            Assert.Empty(validationResult);
        }
    }
}