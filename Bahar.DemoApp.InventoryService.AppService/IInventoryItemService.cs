using Bahar.DemoApp.InventoryService.Model;
using Bahar.DemoApp.InventoryService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;


namespace Bahar.DemoApp.InventoryService.AppService
{
    public interface IInventoryItemService
    {
        public InventoryItemDto AddInventoryItem(int invetoryId, InventoryItemForCreationDto inventoryItem);

        public InventoryItemDto FindbyId(int Id);

        public IEnumerable<InventoryItemDto> GetInventoryItems(InventoryItemResourceParameters inventoryItemResourceParameters);
       
    }
}
