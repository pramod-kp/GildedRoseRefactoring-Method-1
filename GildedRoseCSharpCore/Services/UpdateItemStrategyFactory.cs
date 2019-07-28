using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GildedRoseCSharpCore.Services
{
    public class UpdateItemStrategyFactory : IUpdateItemStrategyFactory
    {        
        private readonly IServiceProvider serviceProvider;

        public UpdateItemStrategyFactory(IServiceProvider serviceProvider)
        {            
            this.serviceProvider = serviceProvider;
        }

        public IInventoryUpdateStrategy GetStrategy(Inventory item)
        {            
            return (IInventoryUpdateStrategy)serviceProvider.GetRequiredService(item.Strategy);
        }
    }
}
