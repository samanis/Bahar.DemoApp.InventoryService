using Bahar.DemoApp.InventoryService.Model;
using System;
using System.Reflection;
using Xunit;

namespace Model.Test
{
    public class InventoryTest
    {
        [Theory]
        [InlineData("Inventory Toronto")]
        [InlineData("Inventory")]
        public void Ctor_Should_Assign_Name_Value_Properly(string name)
        {
            Inventory inventory = new Inventory(name, "address", "6478596321");
            Assert.Equal(inventory.InventoryName, name);

        }

        [Fact]
        public void Empty_Name_Throws_Exception()
        {
            ArgumentException exception = Assert.
                Throws<ArgumentException>(() => new Inventory("", "address1", "1234567893"));
            Assert.Equal("Inventory Name can not be null or empty string", exception.Message);
        }


        [Theory]
        [InlineData("6987458257412587458djxjxjjxjjxjxjjxjjxjjxjxjjxjxjxjjxjxjjxjxjxjjxjxjxjjxjxjkskskkskssskskskkskskskskkskskskskkskksksksk")]
        public void InventoryName_More_Than64_Throws_Exception(string name)
        {
            ArgumentException exception = Assert.
               Throws<ArgumentException>(() => new Inventory(name, "address1", "1234567893"));
            Assert.Equal("Inventory Name can not be more than 64 charachter", exception.Message);
        }



        [Theory]
        [InlineData("Address One")]
        [InlineData("Address")]
        public void Ctor_Should_Assign_Address_Value_Properly(string currentAddress)
        {
            Inventory inventory = new Inventory("inventory Nmae", currentAddress, "6478596321");
            Assert.Equal(inventory.CurrentAddress, currentAddress);

        }
        [Fact]
        public void Empty_Address_shoud_Throw_Exception()
        {
            ArgumentException exception = Assert.
                Throws<ArgumentException>(() => new Inventory("Inventory Name", "", "1478523696"));
            Assert.Equal("Address can not be empty or null string", exception.Message);
        }


        [Theory]
        [InlineData("1234567893")]

        public void Ctor_Should_Assign_Phone_Number_Properly(string phoneNumber)
        {
            Inventory inventory = new Inventory("inventory Nmae", "Address 1", phoneNumber);
            var FormattedPhoneNumber = string.Format("({0}) {1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6, 4));
            Assert.Equal(inventory.PhoneNumber, FormattedPhoneNumber);

        }
        [Fact]
        public void Empty_PhoneNumber_shoud_Throw_Exception()
        {
            ArgumentException exception = Assert.
                Throws<ArgumentException>(() => new Inventory("Inventory Name", "address ", ""));
            Assert.Equal("Phone Number can not be null or empty string", exception.Message);
        }

        [Theory]
        [InlineData("12345678988883")]
        [InlineData("123883")]
        public void PhoneNumber_Less_Than_10_shoud_Throw_Exception(string phoneNumber)
        {
            ArgumentException exception = Assert.
                Throws<ArgumentException>(() => new Inventory("Inventory Name", "address ", phoneNumber));
            Assert.Equal("Phone Number should be just 10 character (No more or less)", exception.Message);
        }

    }
}
