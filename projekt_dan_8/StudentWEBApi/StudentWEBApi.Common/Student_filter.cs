using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWEBApi.Common
{
    public class Student_filter : IStudent_filter
    {
        public string Filter { get; set; }
        public string Filtering(string Filter)
        {
            if (Filter != "")
            {
                return String.Format(" WHERE First_Name LIKE '%{0}%' ", Filter);
            }
            return "";
        }
    }
}
