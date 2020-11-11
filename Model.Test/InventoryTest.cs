using Bahar.DemoApp.InventoryService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Model.Test
{
    public class InventoryTest
    {
        Inventory _inventory = new Inventory();
        [Theory]
        [InlineData("Inventory Toronto")]
        [InlineData("Inventory")]
        public void Ctor_Should_Assign_Name_Value_Properly(string name)
        {
            _inventory.InventoryName = name;
            _inventory.CurrentAddress = "address";
            _inventory.PhoneNumber = "1234567893";

            Assert.Equal(_inventory.InventoryName, name);

        }

        [Fact]
        public void Empty_Name_Throws_Exception()
        {

            _inventory.InventoryName = "";
            _inventory.CurrentAddress = "address";
            _inventory.PhoneNumber = "1234567893";


            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventory, new ValidationContext(_inventory), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Inventory Name can not be null or empty string.", msg.ErrorMessage);

        }


        [Theory]
        [InlineData("6987458257412587458djxjxjjxjjxjxjjxjjxjjxjxjjxjxjxjjxjxjjxjxjxjjxjxjxjjxjxjkskskkskssskskskkskskskskkskskskskkskksksksk")]
        public void InventoryName_More_Than64_Throws_Exception(string name)
        {
            _inventory.InventoryName = name;
            _inventory.CurrentAddress = "address";
            _inventory.PhoneNumber = "1234567893";

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventory, new ValidationContext(_inventory), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Inventory Name can not be more than 64 charachter.", msg.ErrorMessage);

        }



        [Theory]
        [InlineData("Address One")]
        [InlineData("Address")]
        public void Ctor_Should_Assign_Address_Value_Properly(string currentAddress)
        {
            // Inventory inventory = new Inventory("inventory Nmae", currentAddress, "6478596321");
            _inventory.InventoryName = "Inventory6";
            _inventory.CurrentAddress = currentAddress;
            _inventory.PhoneNumber = "1234567893";
            Assert.Equal(_inventory.CurrentAddress, currentAddress);

        }
        [Fact]
        public void Empty_Address_shoud_Throw_Exception()
        {

            _inventory.InventoryName = "Inventory1";
            _inventory.CurrentAddress = "";
            _inventory.PhoneNumber = "1234567893";

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventory, new ValidationContext(_inventory), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Address can not be empty or null string.", msg.ErrorMessage);
        }


        [Theory]
        [InlineData("1234567893")]

        public void Ctor_Should_Assign_Phone_Number_Properly(string phoneNumber)
        {
            _inventory.InventoryName = "Inventory1";
            _inventory.CurrentAddress = "";
            _inventory.PhoneNumber = phoneNumber;

            Assert.Equal(_inventory.PhoneNumber, phoneNumber);

        }
        [Fact]
        public void Empty_PhoneNumber_shoud_Throw_Exception()
        {
            _inventory.InventoryName = "Inventory1";
            _inventory.CurrentAddress = "Address3";


            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventory, new ValidationContext(_inventory), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Phone Number can not be null or empty string.", msg.ErrorMessage);
        }

        [Theory]
        [InlineData("12345678988883")]
        [InlineData("123883")]
        public void PhoneNumber_Less_Than_10_shoud_Throw_Exception(string phoneNumber)
        {
            _inventory.InventoryName = "Inventory1";
            _inventory.CurrentAddress = "Address6";
            _inventory.PhoneNumber = phoneNumber;

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventory, new ValidationContext(_inventory), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Phone Number should be just 10 character (No more or less).", msg.ErrorMessage);
        }

        [Fact]
        public void Throws_Exception_When_Address_Phone_Invalid()
        {

            _inventory.InventoryName = "Inventory1";
            _inventory.CurrentAddress = "";
            _inventory.PhoneNumber = "123456";

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventory, new ValidationContext(_inventory), validationResults, true);

            var msg = validationResults[0];


            Assert.Equal("Address can not be empty or null string.Phone Number should be just 10 character (No more or less).", msg.ErrorMessage);
        }
        [Fact]
        public void Throws_Exception_When_InventoryName_Phone_Invalid()
        {
            _inventory.CurrentAddress = " Address3";
            _inventory.PhoneNumber = "";

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventory, new ValidationContext(_inventory), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Inventory Name can not be null or empty string.Phone Number can not be null or empty string.", msg.ErrorMessage);

        }
    }
}
