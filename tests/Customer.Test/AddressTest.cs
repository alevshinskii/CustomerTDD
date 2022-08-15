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

        [Fact]
        public void ShouldValidatorCheckAllFields()
        {
            Address address = new Address();

            var longStringBuilder = new StringBuilder();
            for (int i = 0; i < 101; i++)
            {
                longStringBuilder.Append("a");
            }
            var longString = longStringBuilder.ToString();


            address.AddressLine = longString;
            address.AddressLine2 = longString;
            address.AddressType = AddressType.Unknown;
            address.City = longString;
            address.Country = "Russia";
            address.PostalCode= longString;
            address.State= longString;


            var validationResult = AddressValidator.Validate(address);

            var expectedValidationResult = new List<string>()
            {
                "Invalid address property: AddressLine",
                "Invalid address property: AddressLine2",
                "Invalid address property: AddressType",
                "Invalid address property: City",
                "Invalid address property: Country",
                "Invalid address property: PostalCode",
                "Invalid address property: State"
            };

            Assert.Equal(expectedValidationResult,validationResult);
        }
    }
}
