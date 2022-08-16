using System.Text;
using Bogus;

namespace Customer.Test
{
    public class CustomerTest
    {
        [Fact]
        public void ShouldBeAbleToCreate()
        {
            Customer customer = new Customer();
        }

        [Fact]
        public void ShouldBeAbleToValidate()
        {
            Customer customer = new Customer();
            var validationResult = CustomerValidator.Validate(customer);

        }
        
        [Fact]
        public void ShouldValidateFirstName()
        {
            Customer customer = new Customer();
            customer.FirstName = "Name";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForFirstName = "Invalid customer property: FirstName";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForFirstName,validationResult);
        }

        [Fact]
        public void ShouldValidateNullFirstName()
        {
            Customer customer = new Customer();
            customer.FirstName = null;

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForFirstName = "Invalid customer property: FirstName";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForFirstName,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongFirstName()
        {
            Customer customer = new Customer();
            customer.FirstName = (new Faker()).Random.String(51);

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForFirstName = "Invalid customer property: FirstName";
            
            Assert.Contains(errorMessageForFirstName,validationResult);
        }

        [Fact]
        public void ShouldValidateLastName()
        {
            Customer customer = new Customer();
            customer.LastName = (new Faker()).Random.String(50);

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForLastName = "Invalid customer property: LastName";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForLastName,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongLastName()
        {
            Customer customer = new Customer();
            customer.LastName = (new Faker()).Random.String(51);

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForLastName = "Invalid customer property: LastName";

            Assert.Contains(errorMessageForLastName,validationResult);
        }


        [Fact]
        public void ShouldValidateAddresses()
        {
            Customer customer = new Customer();
            customer.Addresses.Add(new Address());

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForAddresses = "Invalid customer property: Addresses";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForAddresses,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongAddresses()
        {
            Customer customer = new Customer();
            customer.Addresses.Clear();

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForAddresses = "Invalid customer property: Addresses";
            
            Assert.Contains(errorMessageForAddresses,validationResult);
        }

        [Fact]
        public void ShouldValidateEmail()
        {
            Customer customer = new Customer();
            customer.Email = "email@gmail.com";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForEmail = "Invalid customer property: Email";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForEmail,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongEmail()
        {
            Customer customer = new Customer();
            customer.Email = "email@@gmail.com";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForEmail = "Invalid customer property: Email";
            
            Assert.Contains(errorMessageForEmail,validationResult);
        }

        [Fact]
        public void ShouldValidateNotes()
        {
            Customer customer = new Customer();
            customer.Notes.Add("new note");

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForNotes = "Invalid customer property: Notes";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForNotes,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongNotes()
        {
            Customer customer = new Customer();
            customer.Notes.Clear();

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForNotes = "Invalid customer property: Notes";

            Assert.Contains(errorMessageForNotes,validationResult);
        }

        [Fact]
        public void ShouldValidatePhoneNumber()
        {
            Customer customer = new Customer();
            customer.PhoneNumber="123456789111";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForPhoneNumber = "Invalid customer property: PhoneNumber";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForPhoneNumber,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongPhoneNumber()
        {
            Customer customer = new Customer();
            customer.PhoneNumber="a1230914234";

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForPhoneNumber = "Invalid customer property: PhoneNumber";

            Assert.Contains(errorMessageForPhoneNumber,validationResult);
        }

        [Fact]
        public void ShouldValidateTooLongPhoneNumber()
        {
            Customer customer = new Customer();
            customer.PhoneNumber = (new Faker()).Random.String(16, '0','9');

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForPhoneNumber = "Invalid customer property: PhoneNumber";

            Assert.Contains(errorMessageForPhoneNumber,validationResult);
        }

        [Fact]
        public void ShouldValidateTotalPurchasesAmount()
        {
            Customer customer = new Customer();
            customer.TotalPurchasesAmount=10492194;

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForTotalPurchasesAmount = "Invalid customer property: TotalPurchasesAmount";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForTotalPurchasesAmount,validationResult);
        }

        [Fact]
        public void ShouldBeAbleToHaveNullValueInTotalPurchsesAmount()
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