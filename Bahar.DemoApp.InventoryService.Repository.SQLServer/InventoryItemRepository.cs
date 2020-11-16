using System;
using System.Collections.Generic;
using System.Text;
using Bahar.DemoApp.InventoryService.Model.Repository;
using Bahar.DemoApp.InventoryService.Model;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace Bahar.DemoApp.InventoryService.Repository.SQLServer
{
    public class InventoryItemRepository : IinventoryItemRepository
    {
      
        private InventoryContext _context;

        public InventoryItemRepository(InventoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public void Delete(InventoryItem entity)
        {
            throw new NotImplementedException();
        }

        public InventoryItem FindbyId(int Id)
        {
            return _context.inventoryItem.Find(Id);

        }

        public bool InventoryExists(int InventoryId)
        {
            if (InventoryId <= 0)
            {
                throw new ArgumentNullException(nameof(InventoryId));
            }
            return _context.Inventory.Any(a => a.id == InventoryId);

        }

        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            return _context.inventoryItem.ToList();
        }

        public void Save(InventoryItem entity)
        {
            throw new NotImplementedException();
        }
        public void SaveInventoryItem(int InventoryId, InventoryItem entity)
        {
            if (!InventoryExists(InventoryId))
            {
              
                throw new ArgumentOutOfRangeException(nameof(InventoryId), "This Inventory Id is not exist in database.");
            }

            if (InventoryId <= 0)
            {
                throw new ArgumentNullException(nameof(InventoryId));
            }
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Inventoryid = InventoryId;
            _context.inventoryItem.Add(entity);
            _context.SaveChanges();
                }

        public IEnumerable<InventoryItem> GetInventoryItems(InventoryItemResourceParameters inventoryItemResourceParameters)
        {
            string searchQuery = inventoryItemResourceParameters.SearchQuery;

            IQueryable<InventoryItem> inventoryItems = _context.inventoryItem;

            inventoryItems = inventoryItems.Where(x => x.UOM == (UnitOfMesure)inventoryItemResourceParameters.UOM 
            || x.SKU.Contains(searchQuery)
            || x.Quentity == inventoryItemResourceParameters.Quantity
            || x.Name.Contains(searchQuery));

            return inventoryItems.ToList();

        }

        public IEnumerable<InventoryItem> ReturnAllRows()
        {
            throw new NotImplementedException();
        }
    }
}
