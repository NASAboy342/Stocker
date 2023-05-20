using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocker.Models;

namespace Stocker.Services.Interfaces
{
    interface IStockItemsService
    {
        List<ItemsModels> GetStockItems();
    }
}
