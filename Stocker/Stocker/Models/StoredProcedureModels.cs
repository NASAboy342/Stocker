using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocker.Models
{
    public class SpInsertIntoItems
    {
        public static string spName => "Insert_intoItems";
        public static string paraName => "@items";
    }
    public class SpInsertIntoUdatedDate
    {
        public static string spName => "Insert_intoUdatedDate";
        public static string paraName => "@udatedDate";
    }
    public class SpUpdateStock
    {
        public static string spName => "UpdateStock";
        public static string @updateDate => "@updateDate";
        public static string @input => "@input";
        public static string @outPut => "@outPut";
        public static string @itemId => "@itemId";
    }
}
