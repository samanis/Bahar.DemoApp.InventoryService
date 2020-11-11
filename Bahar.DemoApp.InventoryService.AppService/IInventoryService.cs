using Bahar.DemoApp.InventoryService.Model;

namespace Bahar.DemoApp.InventoryService.AppService
{
    public interface IInventoryService
    {
        public void AddInventory(Inventory inventory);

        public Inventory GetInventory(int Id);
    }

}
