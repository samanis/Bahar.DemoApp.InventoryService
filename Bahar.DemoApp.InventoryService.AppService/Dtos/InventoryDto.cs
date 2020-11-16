using System;
using System.Collections.Generic;
using System.Text;

namespace Bahar.DemoApp.InventoryService.AppService.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public string InventoryName { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentAddress { get; set; }
    }
}
