using System;
using System.Collections.Generic;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Repository.SQLServer
{
    public class InventoryNotFoundException : Exception
    {
        private string v;

        public InventoryNotFoundException(string message, string v) : base(message)
        {
            this.v = v;
        }
    }
}
