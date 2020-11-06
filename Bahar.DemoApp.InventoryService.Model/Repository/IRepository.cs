using System;
using System.Collections.Generic;
using System.Text;

namespace Bahar.DemoApp.InventoryService.Model.Repository
{
    interface IRepository<T>
    {
        public void Save(T entity);

        public void Delete(T entity);
    }
}
