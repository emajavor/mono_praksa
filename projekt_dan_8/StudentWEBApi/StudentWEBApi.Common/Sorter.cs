using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWEBApi.Common
{
    public class Sorter : ISorter
    {
        public string OrderBy { get; set; }
        public string Order { get; set; }

        public string SortBy(string OrderBy, string Order)
        {
            if (OrderBy != "" && Order != "")
            {
                return String.Format(" ORDER BY {0} {1} ", OrderBy, Order);
            }
            return " ORDER BY First_name asc ";
        }
    }
}
