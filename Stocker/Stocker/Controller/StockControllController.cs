using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocker.Models;
using Stocker.Services;
using Stocker.Services.Interfaces;

namespace Stocker.Controller
{
    class StockControllController
    {
        StockItemsService stockItemsService = new StockItemsService();
        public List<ItemsModels> GetStockItems()
        {
            return stockItemsService.GetStockItems();
        }
    }
}
