namespace Bahar.DemoApp.InventoryService.Model.Repository
{
    public class InventoryItemResourceParameters
    {
        public int Inventoryid { get; set; }

        public string SearchQuery { set; get; }

        public int UOM { get; set; }

        public int Quantity { get; set; }
    }
}