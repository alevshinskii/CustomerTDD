using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Customer.Test
{
    public class AddressTest
    {
        private AddressValidator Validator = new();
        private Faker Faker = new("en");

        [Fact]
        public void ShouldBeAbleToCreate()
        {
            Address address = new Address();
        }

        [Fact]
        public void ShouldBeAbleToValidate()
        {
            Address address = new Address();
            var validationResult = Validator.Validate(address);
        }

        [Fact]
        public void ShouldValidateAddressLine()
        {
            Address address = new Address();
            address.AddressLine = "Address";

            var validationResult = Validator.Validate(address);
            string errorMessageForAddressLine = "Invalid address property: AddressLine";
            
            Assert.DoesNotContain(errorMessageForAddressLine,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongAddressLine()
        {
            Address address = new Address();
            address.AddressLine = Faker.Random.String(102);

            var validationResult = Validator.Validate(address);
            string errorMessageForAddressLine = "Invalid address property: AddressLine";
            
            Assert.Contains(errorMessageForAddressLine,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateAddressLine2()
        {
            Address address = new Address();
            address.AddressLine2 = "Address";

            var validationResult = Validator.Validate(address);
            string errorMessageForAddressLine = "Invalid address property: AddressLine2";
            
            Assert.DoesNotContain(errorMessageForAddressLine,validationResult.Errors.Select(error=>error.ErrorMessage));

        }

        [Fact]
        public void ShouldValidateNullAddressLine2()
        {
            Address address = new Address();
            address.AddressLine2 = null;

            string errorMessageForAddressLine = "Invalid address property: AddressLine2";
            var validationResult = Validator.Validate(address);

            Assert.DoesNotContain(errorMessageForAddressLine,validationResult.Errors.Select(error=>error.ErrorMessage));

        }

        [Fact]
        public void ShouldValidateWrongAddressLine2()
        {
            Address address = new Address();
            address.AddressLine2 = Faker.Random.String(101);

            string errorMessageForAddressLine = "Invalid address property: AddressLine2";
            var  validationResult = Validator.Validate(address);

            Assert.Contains(errorMessageForAddressLine,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateAddressType()
        {
            Address address = new Address();
            address.AddressType = AddressType.Billing;

            var validationResult = Validator.Validate(address);
            string errorMessageForAddressType = "Invalid address property: AddressType";
            
            Assert.DoesNotContain(errorMessageForAddressType,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateUnknownAddressType()
        {
            Address address = new Address();
            address.AddressType = AddressType.Unknown;

            var validationResult = Validator.Validate(address);
            string errorMessageForAddressType = "Invalid address property: AddressType";

            Assert.Contains(errorMessageForAddressType,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateCity()
        {
            Address address = new Address();
            address.City = "New York";

            var validationResult = Validator.Validate(address);
            string errorMessageForCity = "Invalid address property: City";
            
            Assert.DoesNotContain(errorMessageForCity,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongCity()
        {
            Address address = new Address();
            address.City = Faker.Random.String(51);

            var validationResult = Validator.Validate(address);
            string errorMessageForCity = "Invalid address property: City";
            
            validationResult = Validator.Validate(address);
            Assert.Contains(errorMessageForCity,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Theory]
        [InlineData("United States")]
        [InlineData("united states")]
        [InlineData("Canada")]
        [InlineData("canada")]
        public void ShouldValidateCountry(string countryName)
        {
            Address address = new Address();
            address.Country = countryName;

            var validationResult = Validator.Validate(address);
            string errorMessageForCountry = "Invalid address property: Country";
            
            Assert.DoesNotContain(errorMessageForCountry,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongCountry()
        {
            Address address = new Address();
            address.Country = Faker.Random.String(20);

            var validationResult = Validator.Validate(address);
            string errorMessageForCountry = "Invalid address property: Country";

            Assert.Contains(errorMessageForCountry,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidatePostalCode()
        {
            Address address = new Address();
            address.PostalCode = "123456";

            var validationResult = Validator.Validate(address);
            string errorMessageForPostalCode = "Invalid address property: PostalCode";
            
            Assert.DoesNotContain(errorMessageForPostalCode,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongPostalCode()
        {
            Address address = new Address();
            
            address.PostalCode = Faker.Random.String(7);

            var validationResult = Validator.Validate(address);
            string errorMessageForPostalCode = "Invalid address property: PostalCode";

            Assert.Contains(errorMessageForPostalCode,validationResult.Errors.Select(error=>error.ErrorMessage));

        }

        [Fact]
        public void ShouldValidateState()
        {
            Address address = new Address();
            address.State = "State";

            var validationResult = Validator.Validate(address);
            string errorMessageForState = "Invalid address property: State";
            
            Assert.DoesNotContain(errorMessageForState,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidateWrongState()
        {
            Address address = new Address();
            address.State = Faker.Random.String(21);

            var validationResult = Validator.Validate(address);
            string errorMessageForState = "Invalid address property: State";
            
            Assert.Contains(errorMessageForState,validationResult.Errors.Select(error=>error.ErrorMessage));
        }

        [Fact]
        public void ShouldValidatorHaveNoErrorsIfValid()
        {
            Address address = new Address();

            address.AddressLine = "Address";
            address.AddressLine2 = "Address";
            address.State = "State";
            address.City = "New York";
            address.Country = "United States";
            address.PostalCode = "123456";
            address.AddressType = AddressType.Shipping;

            var validationResult = Validator.Validate(address);

            Assert.True(validationResult.IsValid);
            Assert.Empty(validationResult.Errors);
        }
    }
}
