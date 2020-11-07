using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Model
{
    public class Inventory : EntityBase<int>
    {
        private string _errormessage = string.Empty;
        public Inventory()
        {
        }

        public Inventory(string inventoryName, string currentAddress, string phoneNumber)
        {
            ValidateInventoryName(inventoryName);
            InventoryName = inventoryName;

            ValidateInventoryAddress(currentAddress);
            CurrentAddress = currentAddress;

            ValidatePhoneNumber(phoneNumber);
            Validate();
            PhoneNumber = string.Format("({0}) {1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6, 4));


        }

        public string InventoryName { get; set; }

        public string CurrentAddress { get; set; }

        public string PhoneNumber { get; set; }

        public void ValidateInventoryName(string Inventoryname)
        {

            if (string.IsNullOrEmpty(Inventoryname.Trim()))
                _errormessage += "Inventory Name can not be null or empty string.";


            if (Inventoryname.Count() > 64)
                _errormessage += "Inventory Name can not be more than 64 charachter.";

        }

        public void ValidateInventoryAddress(string currentAddress)
        {
            if (string.IsNullOrEmpty(currentAddress.Trim()))
                _errormessage += "Address can not be empty or null string.";
        }

        public void ValidatePhoneNumber(string phonenumber)
        {

            if (string.IsNullOrEmpty(phonenumber.Trim()))
                _errormessage += "Phone Number can not be null or empty string.";

            else if (phonenumber.Count() < 10 || phonenumber.Count() > 10)
                _errormessage += "Phone Number should be just 10 character (No more or less).";

        }

        private void Validate()
        {
            if (!string.IsNullOrEmpty(_errormessage))
                throw new ArgumentException(_errormessage);
        }
    }
}
