using System;
using System.Collections.Generic;
using System.Text;
using Bahar.DemoApp.InventoryService.Model;
using Bahar.DemoApp.InventoryService.Model.Repository;

namespace Bahar.DemoApp.InventoryService.Repository.SQLServer
{
    public class InventoryRepository: IinventoryRepository
    {
        private InventoryContext _context;

        public InventoryRepository( InventoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public Inventory GetInventory(int Id)
        {
           var findedItem= _context.Inventory.Find(Id);
            return findedItem;
        }

      

        public void Save(Inventory entity)
        {
            _context.Inventory.Add(entity);
            _context.SaveChanges();
        }
    }
}
