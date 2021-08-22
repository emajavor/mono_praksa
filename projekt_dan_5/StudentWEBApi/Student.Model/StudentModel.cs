using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Model
{
    public class Students
    {
        public Students() { }

        public Students(int _student_id, string _first_name, string _last_name, int _university_id)
        {
            Student_id = _student_id;
            First_name = _first_name;
            Last_name = _last_name;
            University_id = _university_id;
        }

        public int Student_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int University_id { get; set; }
    }
}
