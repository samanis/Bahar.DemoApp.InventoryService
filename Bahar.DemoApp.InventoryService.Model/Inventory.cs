using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Model
{
    public class Inventory : EntityBase<int> ,IValidatableObject
    {
        private string _errormessage = string.Empty;
        
        public Inventory()
        {

        }

      
        public string InventoryName { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentAddress { get; set; }



        public void ValidateInventoryName(string Inventoryname)
        {

            if ((InventoryName is null)|| string.IsNullOrEmpty(Inventoryname.Trim()))
                _errormessage += "Inventory Name can not be null or empty string.";
            else

            if (Inventoryname.Count() > 64)
                _errormessage += "Inventory Name can not be more than 64 charachter.";

        }

        public void ValidateInventoryAddress(string currentAddress)
        {
            if ((currentAddress is null)|| string.IsNullOrEmpty(currentAddress.Trim()))
                _errormessage += "Address can not be empty or null string.";
        }

        public bool ValidatePhoneNumber(string phonenumber)
        {
            bool value = true;
            if ((phonenumber is null) || string.IsNullOrEmpty(phonenumber.Trim()))
            {
                _errormessage += "Phone Number can not be null or empty string.";
                value = false;
            }
            else if (phonenumber.Count() < 10 || phonenumber.Count() > 10)
            {
                _errormessage += "Phone Number should be just 10 character (No more or less).";
                value = false;
            }
            return value;

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidateInventoryName(InventoryName);
            ValidateInventoryAddress(CurrentAddress);
            if (ValidatePhoneNumber(PhoneNumber))
            {
                PhoneNumber = string.Format("({0}) {1}-{2}", PhoneNumber.Substring(0, 3), PhoneNumber.Substring(3, 3), PhoneNumber.Substring(6, 4));
            }
                if (!string.IsNullOrEmpty(_errormessage))
                yield return new ValidationResult(_errormessage);
        }
    }
}
