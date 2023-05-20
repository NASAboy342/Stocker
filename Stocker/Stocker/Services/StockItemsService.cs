using Stocker.Models;
using Stocker.Repository;
using Stocker.Repository.Interfaces;
using Stocker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocker.Services
{
    class StockItemsService : IStockItemsService
    {
        DataBaseDataRepo dataBaseDataRepo = new DataBaseDataRepo();
        public List<ItemsModels> GetStockItems()
        {
            var stockItems = new List<ItemsModels>();
            try
            {
                stockItems = dataBaseDataRepo.SelectAllFromItems();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return stockItems;
        }
    }
}
