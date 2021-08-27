using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model.Common
{
    public interface IStudent
    {
        int Student_id { get; set; }
        string First_name { get; set; }
        string Last_name { get; set; }
        int University_id { get; set; }
    }
}
