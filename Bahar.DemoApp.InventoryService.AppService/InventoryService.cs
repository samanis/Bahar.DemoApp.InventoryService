using Bahar.DemoApp.InventoryService.Model;
using Bahar.DemoApp.InventoryService.Model.Repository;
using System;

namespace Bahar.DemoApp.InventoryService.AppService
{
    public class InventoryService : IInventoryService
    {
        IinventoryRepository _iinventoryRepository;

        public InventoryService(IinventoryRepository iinventoryRepository)
        {
            this._iinventoryRepository = iinventoryRepository;
        }

        public void AddInventory(Inventory inventory)
        {
            _iinventoryRepository.Save(inventory);
        }
    }

}
