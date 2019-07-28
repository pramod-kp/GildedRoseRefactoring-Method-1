using GildedRoseCSharpCore.Entity;
using GildedRoseCSharpCore.Interfaces;
using GildedRoseCSharpCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GildedRoseCSharpCore
{
    public class Program
    {        
        public IList<Inventory> Items;
        private IUpdateItemStrategyFactory _updateStrategy;

        public Program(IUpdateItemStrategyFactory updateStrategy, List<Inventory> items)
        {
            _updateStrategy = updateStrategy;
            Items = items;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            // register exception handler
            AppDomain.CurrentDomain.UnhandledException += Helper.UnhandledExceptionTrapper;

            // register services / dependencies
            IServiceCollection serviceCollection = new ServiceCollection()
                .AddSingleton<IUpdateItemStrategyFactory, UpdateItemStrategyFactory>()
                .AddTransient<IAgedBrieUpdateService, AgedBrieUpdateService>()
                .AddTransient<IBackStagePassesUpdateService, BackStagePassesUpdateService>()
                .AddTransient<IConjuredUpdateService, ConjuredUpdateService>()
                .AddTransient<ILegendaryItemsUpdateService, LegendaryItemsUpdateService>()
                .AddTransient<IStandardItemsUpdateService, StandardItemsUpdateService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            var updateStrategy = serviceProvider.GetService<IUpdateItemStrategyFactory>();
            var app = new Program(updateStrategy, Helper.GetDefaultInventory());            

            app.UpdateInventory();

            Console.ReadKey();
            app.DisposeServices(serviceCollection);
        }

        public void UpdateInventory()
        {
            foreach (var item in Items)
            {
                var strategy = _updateStrategy.GetStrategy(item);
                strategy.UpdateItem(item);
            }
        }

        private void DisposeServices(IServiceCollection services)
        {
            foreach (var service in services)
            {
                if (service == null)
                    return;
                if (service is IDisposable)
                    ((IDisposable)service).Dispose();
            }
        }
    }
}
