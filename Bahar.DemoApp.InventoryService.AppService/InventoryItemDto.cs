using System;
using System.Collections.Generic;
using System.Text;

namespace Bahar.DemoApp.InventoryService.AppService
{
    public class InventoryItemDto 

    {
        public int id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string QTYUOM { get; set; }

        public int Inventoryid { get; set; }
    }
}
