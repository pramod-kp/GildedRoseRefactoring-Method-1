using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;
using System;
using System.Collections.Generic;

namespace GildedRoseCSharpCore
{
    public static class Helper
    {
        public static List<Inventory> GetDefaultInventory()
        {
            return new List<Inventory>
                {
                    new Inventory {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Strategy = typeof(IStandardItemsUpdateService)},
                    new Inventory {Name = "Aged Brie", SellIn = 2, Quality = 0, Strategy = typeof(IAgedBrieUpdateService)},
                    new Inventory {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Strategy = typeof(IStandardItemsUpdateService)},
                    new Inventory {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Strategy = typeof(ILegendaryItemsUpdateService)},
                    new Inventory {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Strategy = typeof(IBackStagePassesUpdateService)},
                    new Inventory {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Strategy = typeof(IConjuredUpdateService)}
                };
        }

        public static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
