using Bahar.DemoApp.InventoryService.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bahar.DemoApp.InventoryService.AppService.Dtos
{
    public class InventoryItemOps
    {
        public InventoryItem InventoryItem { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
