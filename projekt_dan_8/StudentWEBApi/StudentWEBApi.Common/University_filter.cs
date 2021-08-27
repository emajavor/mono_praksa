using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWEBApi.Common
{
    public class University_filter :IUniversity_filter
    {
        public string Filter { get; set; }
        public string Filtering(string Filter)
        {
            if(Filter != "")
            {
                return String.Format(" WHERE City LIKE '%{0}' ", Filter);
            }
            return "";
        }
    }
}
