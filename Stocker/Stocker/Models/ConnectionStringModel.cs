using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Stocker.Models
{
    class ConnectionStringModel
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
    }
}
