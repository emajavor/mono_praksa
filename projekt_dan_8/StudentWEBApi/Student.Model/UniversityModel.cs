using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model.Common;

namespace Student.Model
{
    public class University : IUniversity
    {

        //public University() { }

        //public University(int _university_id, string _university_name, string _city)
        //{
        //    University_id = _university_id;
        //    University_name = _university_name;
        //    City = _city;
            
        //}

        public int University_id { get; set; }
        public string University_name { get; set; }     
        public string City { get; set; }
        
    }
}
