using Bahar.DemoApp.InventoryService.AppService.Dtos;
using Bahar.DemoApp.InventoryService.Model;
using System.Collections.Generic;

namespace Bahar.DemoApp.InventoryService.AppService.interfaces
{
    public interface IInventoryService
    {
        public InventoryDto AddInventory(InventoryForCreationDto inventory);

        public InventoryDto FindbyId(int Id);

        public IEnumerable<InventoryDto> ReturnAllRows();
    }

}
