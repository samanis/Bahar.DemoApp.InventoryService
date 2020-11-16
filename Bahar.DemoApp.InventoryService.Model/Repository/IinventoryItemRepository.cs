using System;
using System.Collections.Generic;
using System.Text;
using Bahar.DemoApp.InventoryService.Model;
using Bahar.DemoApp.InventoryService.Model.Repository;

namespace Bahar.DemoApp.InventoryService.Model.Repository
{
    public interface IinventoryItemRepository : IRepository<InventoryItem, int>
    {
        void SaveInventoryItem(int InventoryId, InventoryItem inventoryItem);
        bool InventoryExists(int InventoryId);

        IEnumerable<InventoryItem> GetInventoryItems(InventoryItemResourceParameters inventoryItemResourceParameters);

    }
}
