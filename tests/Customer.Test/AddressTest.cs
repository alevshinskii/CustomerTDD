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
        [Fact]
        public void ShouldBeAbleToCreate()
        {
            Address address = new Address();
        }

        [Fact]
        public void ShouldBeAbleToValidate()
        {
            Address address = new Address();
            var validationResult = AddressValidator.Validate(address);
        }

        [Fact]
        public void ShouldValidateAddressLine()
        {
            Address address = new Address();
            address.AddressLine = "Address";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForAddressLine = "Invalid address property: AddressLine";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForAddressLine,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongAddressLine()
        {
            Address address = new Address();
            address.AddressLine = (new Faker()).Random.String(102);

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForAddressLine = "Invalid address property: AddressLine";
            
            Assert.Contains(errorMessageForAddressLine, validationResult);
        }

        [Fact]
        public void ShouldValidateAddressLine2()
        {
            Address address = new Address();
            address.AddressLine2 = "Address";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForAddressLine = "Invalid address property: AddressLine2";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForAddressLine,validationResult);

            address.AddressLine2 = null;
            validationResult = AddressValidator.Validate(address);
            Assert.DoesNotContain<string>(errorMessageForAddressLine,validationResult);

        }

        [Fact]
        public void ShouldValidateNullAddressLine2()
        {
            Address address = new Address();
            address.AddressLine2 = null;

            string errorMessageForAddressLine = "Invalid address property: AddressLine2";
            var validationResult = AddressValidator.Validate(address);

            Assert.DoesNotContain<string>(errorMessageForAddressLine,validationResult);

        }

        [Fact]
        public void ShouldValidateWrongAddressLine2()
        {
            Address address = new Address();
            address.AddressLine2 = (new Faker()).Random.String(101);

            string errorMessageForAddressLine = "Invalid address property: AddressLine2";
            var  validationResult = AddressValidator.Validate(address);

            Assert.Contains(errorMessageForAddressLine, validationResult);
        }

        [Fact]
        public void ShouldValidateAddressType()
        {
            Address address = new Address();
            address.AddressType = AddressType.Billing;

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForAddressType = "Invalid address property: AddressType";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForAddressType,validationResult);
        }

        [Fact]
        public void ShouldValidateUnknownAddressType()
        {
            Address address = new Address();
            address.AddressType = AddressType.Unknown;

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForAddressType = "Invalid address property: AddressType";

            Assert.Contains(errorMessageForAddressType, validationResult);
        }

        [Fact]
        public void ShouldValidateCity()
        {
            Address address = new Address();
            address.City = "New York";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForCity = "Invalid address property: City";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForCity,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongCity()
        {
            Address address = new Address();
            address.City = (new Faker()).Random.String(51);

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForCity = "Invalid address property: City";
            
            validationResult = AddressValidator.Validate(address);
            Assert.Contains(errorMessageForCity, validationResult);
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

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForCountry = "Invalid address property: Country";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForCountry,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongCountry()
        {
            Address address = new Address();
            address.Country = (new Faker()).Random.String(20);

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForCountry = "Invalid address property: Country";

            Assert.Contains(errorMessageForCountry, validationResult);
        }

        [Fact]
        public void ShouldValidatePostalCode()
        {
            Address address = new Address();
            address.PostalCode = "123456";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForPostalCode = "Invalid address property: PostalCode";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForPostalCode,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongPostalCode()
        {
            Address address = new Address();
            
            address.PostalCode = (new Faker()).Random.String(7);

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForPostalCode = "Invalid address property: PostalCode";

            Assert.Contains(errorMessageForPostalCode, validationResult);

        }

        [Fact]
        public void ShouldValidateState()
        {
            Address address = new Address();
            address.State = "State";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForState = "Invalid address property: State";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForState,validationResult);
        }

        [Fact]
        public void ShouldValidateWrongState()
        {
            Address address = new Address();
            address.State = (new Faker()).Random.String(21);

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForState = "Invalid address property: State";
            
            Assert.Contains(errorMessageForState, validationResult);
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

            var validationResult = AddressValidator.Validate(address);

            Assert.Empty(validationResult);
        }
    }
}
