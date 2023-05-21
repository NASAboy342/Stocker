using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocker.Models.Response
{
    class ErrorCodeModel
    {
        public static int Error => 1;
        public static int Success => 0;
    }
    class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
