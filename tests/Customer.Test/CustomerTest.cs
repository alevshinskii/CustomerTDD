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
        public void SouldBeAbleToHaveNullValueInTotalPurchsesAmount()
        {
            Customer customer = new Customer();

            customer.TotalPurchasesAmount = null;

            var validationResult = CustomerValidator.Validate(customer);
            string errorMessageForInvalidTotalPurchaseAmount = "Invalid customer property: TotalPurchasesAmount";

            Assert.DoesNotContain<string>(errorMessageForInvalidTotalPurchaseAmount,validationResult);
        }
    }
}