using Bahar.DemoApp.InventoryService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bahar.DemoApp.InventoryService.AppService
{
    public class InventoryItemForCreationDto : IValidatableObject
    {
        private string _errormessage = string.Empty;
        public string Name { get; set; }
        public string SKU { get; set; }

        public UnitOfMesure UOM { get; set; }
        public int Quentity { get; set; }

        public int Inventoryid { get; set; }
        [ForeignKey("Inventoryid")]
        public Inventory inventory { get; set; }

        public void ValidateInventoryItemName(string name)
        {
            if ((name is null) || string.IsNullOrEmpty(name.Trim()))
            {
                _errormessage += "Inventory Item Name can not be null or empty string.";
            }
        }

        public void ValidateItemSKU(string sku)
        {
            if ((sku is null) || string.IsNullOrEmpty(sku.Trim()))
            {
                _errormessage += "Item SKU can not be null or empty string.";
            }
        }

        public void ValidateItemUOM(UnitOfMesure uom)
        {
            int ConvertTointUOM = (int)uom.GetHashCode();

            if (ConvertTointUOM < 0 || ConvertTointUOM > 2)
            {
                _errormessage += "Unit of Mesure Should be 0 or 1 or 2";
            }

        }
        public void ValidateQty(int qty)
        {
            if ((qty <= 0))
            {
                _errormessage += "Quentity can not be 0 or Less than 0";
            }
        }
       /* public void ValidateInventoryId(int inventoryid)
        {
            if (inventoryid == 0)
            {
                _errormessage += "Erorrrrr";
            }
        }*/

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidateInventoryItemName(Name);
            ValidateItemSKU(SKU);
            ValidateQty(Quentity);
            ValidateItemUOM(UOM);
         //   ValidateInventoryId(Inventoryid);

            if (!string.IsNullOrEmpty(_errormessage))
                yield return new ValidationResult(_errormessage);
        }
    }

    public enum UnitOfMesure
    {
        Centimeter,
        Meter,
        Each
    }
}
