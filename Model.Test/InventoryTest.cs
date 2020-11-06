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
        [InlineData("")]
        [InlineData("                                                                                                                         ")]
        [InlineData("Inventory")]
        public void Ctor_Should_Assign_Name_Value_Properly(string name)
        {
            Inventory inventory = new Inventory(name, "address", "6478596321");
        }

        public void Ctor_Should_Assign_Phone_Number_Properly()
        {
         
        }

        public void Ctor_Should_Assign_CurrentAddress_Properly()
        {

        }
    }
}
