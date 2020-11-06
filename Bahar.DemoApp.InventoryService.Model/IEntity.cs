using System;
using System.Collections.Generic;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Model
{
    interface IEntity<T>
    {
        T id { get; set; }
    }
}
