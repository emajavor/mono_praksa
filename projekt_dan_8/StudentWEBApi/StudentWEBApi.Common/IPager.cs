using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWEBApi.Common
{
    public interface IPager
    {
        int Pager_number { get; set; }
        int Pager_size { get; set; }
        string Paging(int Pager_number, int Pager_size);
    }
}
