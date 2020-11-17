using Bahar.DemoApp.InventoryService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.Text;
using Xunit;

namespace Model.Test
{
    public class InventoryItemTest
    {
        InventoryItem _inventoryItem = new InventoryItem();
        [Theory]
        [InlineData("Inventory Toronto")]
        [InlineData("Inventory")]
        public void Ctor_Should_Assign_Name_Value_Properly(string name)
        {
            _inventoryItem.Name = name;
            _inventoryItem.SKU = "D147852";
            _inventoryItem.UOM =UnitOfMesure.Centimeter;
            _inventoryItem.Quentity = 10;


            Assert.Equal(_inventoryItem.Name, name);

        }

        [Fact]
        public void Empty_Name_Throws_Exception()
        {

            _inventoryItem.Name = "";
            _inventoryItem.SKU = "D147852";
            _inventoryItem.UOM = UnitOfMesure.Centimeter;
            _inventoryItem.Quentity = 10;


            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventoryItem, new ValidationContext(_inventoryItem), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Inventory Item Name can not be null or empty string.", msg.ErrorMessage);

        }
        [Fact]
        public void Empty_SKU_Throws_Exception()
        {

            _inventoryItem.Name = "Inventory Item1";
      
            _inventoryItem.UOM = UnitOfMesure.Centimeter;
            _inventoryItem.Quentity = 10;


            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventoryItem, new ValidationContext(_inventoryItem), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Item SKU can not be null or empty string.", msg.ErrorMessage);

        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]

        public void Empty_QTy_Throws_Exception(int qty)
        {

            _inventoryItem.Name = "sssss";
            _inventoryItem.SKU = "D147852";
            _inventoryItem.UOM = UnitOfMesure.Centimeter;
            _inventoryItem.Quentity = qty;


            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(_inventoryItem, new ValidationContext(_inventoryItem), validationResults, true);

            var msg = validationResults[0];
            Assert.Equal("Quentity can not be 0 or Less than 0", msg.ErrorMessage);

        }



    }
}
