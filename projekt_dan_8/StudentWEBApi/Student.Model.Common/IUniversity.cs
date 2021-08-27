using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model.Common
{
    public interface IUniversity
    {
        int University_id { get; set; }
        string University_name { get; set; }
        string City { get; set; }
    }
}

