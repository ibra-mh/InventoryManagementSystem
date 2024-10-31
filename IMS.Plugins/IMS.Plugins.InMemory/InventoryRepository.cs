using IMS.CoreBusiness;
using IMS.usecases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryID=1, InventoryName= "Bike seat", Quantity = 10, Price=2 },
                new Inventory { InventoryID=2, InventoryName= "Bike body", Quantity = 10, Price=15 },
                new Inventory { InventoryID=3, InventoryName= "Bike wheels", Quantity = 20, Price=8 },
                new Inventory { InventoryID=4, InventoryName= "Bike pedals", Quantity = 20, Price=1 }
            };
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
