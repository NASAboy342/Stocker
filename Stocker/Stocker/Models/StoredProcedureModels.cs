using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocker.Models
{
    public class InsertIntoItems
    {
        public static string spName => "Insert_intoItems";
        public static string paraName => "@items";
    }
    public class InsertIntoUdatedDate
    {
        public static string spName => "Insert_intoUdatedDate";
        public static string paraName => "@udatedDate";
    }
}
