using System;
using System.Collections.Generic;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Model
{
    public class Inventory:EntityBase<int>
    {
        public Inventory()
        {
        }

        public Inventory(string inventoryName, string currentAddress, string phoneNumber)
        {
            InventoryName = inventoryName;
            CurrentAddress = currentAddress;
            PhoneNumber = phoneNumber;



        }

        public string InventoryName { get; set; }

        public string CurrentAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
