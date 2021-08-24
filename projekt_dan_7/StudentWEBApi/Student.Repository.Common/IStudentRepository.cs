using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;
using Student.Model.Common;

namespace Student.Repository.Common
{
    public interface IStudentRepository<Students>
    {
        Task<List<Students>> GetStudentsAsync();

        Task<Students> GetStudentByIdAsync(int id);

        Task<bool> CreateStudentAsync(Students student);

        Task<bool> UpdateStudentAsync(int id, Students student);

        Task<bool> DeleteStudentAsync(int id);
    }
}
