namespace Bahar.DemoApp.InventoryService.Model
{
    public abstract class EntityBase<T> : IEntity<T>
    {
        public T id { get ; set ; }
    }
}
