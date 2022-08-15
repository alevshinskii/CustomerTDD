using System.Text.RegularExpressions;

namespace Customer
{
    public class CustomerValidator
    {
        private const int _firstNameMaxLength = 50;
        private const int _lastNameMaxLength = 50;
        private const int _addressesMinCount = 1;
        private const int _notesMinCount = 1;
        private const int _phoneNumberMaxLength = 15;
        private static Regex _emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public static List<string> Validate(Customer customer)
        {
            var errors = new List<string>();

            if (customer.FirstName != null && customer.FirstName.Length > _firstNameMaxLength)
            {
                errors.Add("Invalid customer property: FirstName");
            }
            if (string.IsNullOrEmpty(customer.LastName) || customer.LastName.Length > _lastNameMaxLength)
            {
                errors.Add("Invalid customer property: LastName");
            }
            if (customer.Addresses.Count < _addressesMinCount)
            {
                errors.Add("Invalid customer property: Addresses");
            }
            if (customer.PhoneNumber != null && customer.PhoneNumber.Length > _phoneNumberMaxLength)
            {
                errors.Add("Invalid customer property: PhoneNumber");
            }
            if (customer.Email != null && !_emailRegex.IsMatch(customer.Email))
            {
                errors.Add("Invalid customer property: Email");
            }
            if (customer.Notes.Count < _notesMinCount)
            {
                errors.Add("Invalid customer property: Notes");
            }
            if (customer.TotalPurchasesAmount!=null && customer.TotalPurchasesAmount<0)
            {
                errors.Add("Invalid customer property: TotalPurchasesAmount");
            }


            return errors;
        }
    }
}
