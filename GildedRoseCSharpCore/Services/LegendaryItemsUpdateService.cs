using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;

namespace GildedRoseCSharpCore.Services
{
    public class LegendaryItemsUpdateService : ILegendaryItemsUpdateService
    {
        public void UpdateItem(Inventory item)
        {
            item.SellIn = item.SellIn;
            item.Quality = item.Quality;
        }
    }
}