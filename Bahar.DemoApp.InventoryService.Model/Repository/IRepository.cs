using System;
using System.Collections.Generic;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Model.Repository
{
    public interface IRepository<T,J>
    {
        public void Save(T entity);

        public void Delete(T entity);

        public T GetInventory(J Id);
    }
}
