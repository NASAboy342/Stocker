using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stocker.Models;
using Stocker.Models.Response;
using Stocker.Repository;

namespace Stocker.Services
{
    class StockUpdateService
    {
        UpdateStockRepo updateStockRepo = new UpdateStockRepo();
        DateTime now = DateTime.Now;
        public ErrorResponse UpdateStock(UpdateStockRequest req)
        {
            try
            {
                if (req.UpdateDate == now)
                {
                    req.UpdateDate = now;
                }
                if (req.ItemId == 0)
                {
                    throw new Exception("Item connod be found!");
                }
                updateStockRepo.UpdateStock(req);

            }catch(Exception e)
            {
                return new ErrorResponse()
                {
                    ErrorCode = ErrorCodeModel.Error,
                    ErrorMessage = $"Update Error! [{e.Message}]"
                };
            }

            return new ErrorResponse()
            {
                ErrorCode = ErrorCodeModel.Success,
                ErrorMessage = "Update Success"
            };
        }
    }
}
