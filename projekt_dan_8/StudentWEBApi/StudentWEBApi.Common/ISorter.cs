using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWEBApi.Common
{
    public interface ISorter
    {
        string OrderBy { get; set; }
        string Order { get; set; }
        string SortBy(string OrderBy, string Order);
    }
}
