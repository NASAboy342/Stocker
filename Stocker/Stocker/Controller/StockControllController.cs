using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocker.Models;
using Stocker.Models.Response;
using Stocker.Services;
using Stocker.Services.Interfaces;

namespace Stocker.Controller
{
    class StockControllController
    {
        StockItemsService stockItemsService = new StockItemsService();
        StockUpdateService stockUpdateService = new StockUpdateService();
        public List<ItemsModels> GetStockItems()
        {
            return stockItemsService.GetStockItems();
        }

        public ErrorResponse UpdateStock(UpdateStockRequest req)
        {
            return stockUpdateService.UpdateStock(req);
        }
    }
}
