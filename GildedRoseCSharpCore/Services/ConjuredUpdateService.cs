using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;

namespace GildedRoseCSharpCore.Services
{
    public class ConjuredUpdateService : IConjuredUpdateService
    {
        public void UpdateItem(Inventory item)
        {            
            item.SellIn--;
            if (item.Quality >= 2)
                item.Quality -= 2;
            else if (item.Quality == 1)
                item.Quality = 0;
        }
    }
}