using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;

namespace GildedRoseCSharpCore.Services
{
    public class StandardItemsUpdateService : IStandardItemsUpdateService
    {
        public void UpdateItem(Inventory item)
        {
            item.SellIn--;
            if (item.Quality > 0) item.Quality--;
            if (item.SellIn < 0)
            {
                if (item.Quality > 0) item.Quality--;
            }
        }
    }
}