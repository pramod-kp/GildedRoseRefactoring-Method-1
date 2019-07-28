using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;

namespace GildedRoseCSharpCore.Services
{
    public class BackStagePassesUpdateService : IBackStagePassesUpdateService
    {
        public void UpdateItem(Inventory item)
        {
            item.SellIn--;

            if (item.Quality < 50) item.Quality++;

            if (item.SellIn < 10)
            {
                if (item.Quality < 50) item.Quality++;
            }
            if (item.SellIn < 5)
            {
                if (item.Quality < 50) item.Quality++;
            }
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}