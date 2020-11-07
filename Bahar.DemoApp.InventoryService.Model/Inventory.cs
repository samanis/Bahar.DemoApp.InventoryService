using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Model
{
    public class Inventory : EntityBase<int>
    {
        public Inventory()
        {
        }

        public Inventory(string inventoryName, string currentAddress, string phoneNumber)
        {
            ValidateInventoryName_Address(inventoryName, currentAddress);
            InventoryName = inventoryName;
            CurrentAddress = currentAddress;

            ValidatePhoneNumber(phoneNumber);
            PhoneNumber = string.Format("({0}) {1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6, 4));


        }

        public string InventoryName { get; set; }

        public string CurrentAddress { get; set; }

        public string PhoneNumber { get; set; }

        public void ValidateInventoryName_Address(string Inventoryname, string currentAddress)
        {
            string errormessage = string.Empty;

            if (string.IsNullOrEmpty(Inventoryname.Trim()))
                errormessage = "Inventory Name can not be null or empty string";


            if (Inventoryname.Count() > 64)
                errormessage = "Inventory Name can not be more than 64 charachter";

            if (string.IsNullOrEmpty(currentAddress.Trim()))
                errormessage = "Address can not be empty or null string";

            if (!string.IsNullOrEmpty(errormessage))
                throw new ArgumentException(errormessage.Trim());
        }


        public void ValidatePhoneNumber(string phonenumber)
        {
            string errormessage = string.Empty;

            if (string.IsNullOrEmpty(phonenumber.Trim()))
                errormessage = "Phone Number can not be null or empty string";

            else if (phonenumber.Count() < 10 || phonenumber.Count() > 10)
                errormessage = "Phone Number should be just 10 character (No more or less)";


            if (!string.IsNullOrEmpty(errormessage))
                throw new ArgumentException(errormessage.Trim());

        }
    }
}
