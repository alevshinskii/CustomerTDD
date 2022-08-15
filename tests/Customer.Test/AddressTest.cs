using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private string _longString =
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        [Fact]
        public void SouldValidateAddressLine()
        {
            Address address = new Address();
            address.AddressLine = "Address";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForAddressLine = "Invalid address property: AddressLine";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForAddressLine,validationResult);
            
            address.AddressLine = _longString;
            validationResult = AddressValidator.Validate(address);
            Assert.Contains(errorMessageForAddressLine, validationResult);
        }

        [Fact]
        public void SouldValidateAddressLine2()
        {
            Address address = new Address();
            address.AddressLine2 = "Address";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForAddressLine = "Invalid address property: AddressLine2";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForAddressLine,validationResult);
            
            address.AddressLine2 = _longString;
            validationResult = AddressValidator.Validate(address);
            Assert.Contains(errorMessageForAddressLine, validationResult);

            address.AddressLine2 = null;
            validationResult = AddressValidator.Validate(address);
            Assert.DoesNotContain<string>(errorMessageForAddressLine,validationResult);

        }

        [Fact]
        public void SouldValidateAddressType()
        {
            Address address = new Address();
            address.AddressType = AddressType.Billing;

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForAddressType = "Invalid address property: AddressType";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForAddressType,validationResult);
            
            address.AddressType = AddressType.Unknown;
            validationResult = AddressValidator.Validate(address);
            Assert.Contains(errorMessageForAddressType, validationResult);

        }

        [Fact]
        public void SouldValidateCity()
        {
            Address address = new Address();
            address.City = "New York";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForCity = "Invalid address property: City";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForCity,validationResult);
            
            address.City = _longString;
            validationResult = AddressValidator.Validate(address);
            Assert.Contains(errorMessageForCity, validationResult);

        }

        [Fact]
        public void SouldValidateCountry()
        {
            Address address = new Address();
            address.Country = "United States";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForCountry = "Invalid address property: Country";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForCountry,validationResult);
            
            address.Country = _longString;
            validationResult = AddressValidator.Validate(address);
            Assert.Contains(errorMessageForCountry, validationResult);

        }

        [Fact]
        public void SouldValidatePostalCode()
        {
            Address address = new Address();
            address.PostalCode = "123456";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForPostalCode = "Invalid address property: PostalCode";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForPostalCode,validationResult);
            
            address.PostalCode = _longString;
            validationResult = AddressValidator.Validate(address);
            Assert.Contains(errorMessageForPostalCode, validationResult);

        }

        [Fact]
        public void State()
        {
            Address address = new Address();
            address.State = "State";

            var validationResult = AddressValidator.Validate(address);
            string errorMessageForState = "Invalid address property: State";

            Assert.NotEmpty(validationResult);
            Assert.DoesNotContain<string>(errorMessageForState,validationResult);
            
            address.State = _longString;
            validationResult = AddressValidator.Validate(address);
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
