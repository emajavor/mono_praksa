using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWEBApi.Common
{
    public interface IUniversity_filter
    {
        string Filter { get; set; }
        string Filtering(string Filter);
    }
}
