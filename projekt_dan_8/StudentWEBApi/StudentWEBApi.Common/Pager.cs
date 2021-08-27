using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWEBApi.Common
{
    public class Pager : IPager
    {
        public int Pager_number { get; set; }
        public int Pager_size { get; set; }
        public string Paging(int Pager_number, int Pager_size)
        {
            if (Pager_number > 0 && Pager_size > 0)
            {
                return String.Format(" OFFSET {0} ROWS FETCH NEXT {1} ROW ONLY ", Pager_size * (Pager_number - 1), Pager_size);
            }
            return "";
        }
    }
}
