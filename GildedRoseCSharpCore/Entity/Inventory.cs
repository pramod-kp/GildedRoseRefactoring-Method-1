
using GildedRoseCSharpCore.Interfaces;
using System;

namespace GildedRoseCSharpCore.Entity
{
    public class Inventory : Item
    {
        public Type Strategy { get; set; } = typeof(IStandardItemsUpdateService);        
    }
}
