using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;
using Student.Repository;
using Student.Service.Common;
using Student.Repository.Common;




namespace Student.Service
{
    public class StudentService :IStudentService<Students>
    {
        IStudentRepository<Students> studentRepository ;
        public StudentService(IStudentRepository<Students> _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        public async Task<List<Students>> GetStudentsAsync()
        {
            return await studentRepository.GetStudentsAsync();
        }
        public async Task<Students> GetStudentByIdAsync(int id)
        {
            return await studentRepository.GetStudentByIdAsync(id);
        }
        public async Task<bool> CreateStudentAsync(Students student)
        {
            return await studentRepository.CreateStudentAsync(student);
        }
        public async Task<bool> UpdateStudentAsync(int id, Students student)
        {
            return await studentRepository.UpdateStudentAsync(id, student);
        }
        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await studentRepository.DeleteStudentAsync(id);
        }
    }
}
