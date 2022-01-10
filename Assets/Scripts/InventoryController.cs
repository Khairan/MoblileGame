using System;
using System.Linq;
using Tools;


internal class InventoryController : BaseController, IInventoryController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "DataSource/Upgrades/UpgradeItemConfigDataSource" };

   private readonly IInventoryModel _inventoryModel;
   private readonly IItemsRepository _itemsRepository;
   private readonly IInventoryView _inventoryWindowView;

   public InventoryController(IInventoryModel inventoryModel, IItemsRepository itemsRepository, IInventoryView inventoryView)
   {
       _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
       _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
       _inventoryWindowView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
   }

    public void HideInventory()
    {
        throw new NotImplementedException();
    }

    public void ShowInventory(Action callback)
    {
        _inventoryWindowView.Display(_itemsRepository.Items.Values.ToList());
    }
}
