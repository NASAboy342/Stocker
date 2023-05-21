using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocker.Models.Response
{
    class UpdateStockRequest
    {
        public DateTime UpdateDate { get; set; }
        public int Input { get; set; }
        public int Output { get; set; }
        public int ItemId { get; set; }
    }
}
