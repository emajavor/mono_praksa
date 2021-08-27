using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;
using StudentWEBApi.Common;

namespace Student.Service.Common
{
    public interface IStudentService<Students>
    {
        Task<List<Students>> GetStudentsAsync(Sorter sorter, Pager pager, Student_filter studentFilter);

        Task<Students> GetStudentByIdAsync(int id);

        Task<bool> CreateStudentAsync(Students student);

        Task<bool> UpdateStudentAsync(int id, Students student);

        Task<bool> DeleteStudentAsync(int id);
    }
}
