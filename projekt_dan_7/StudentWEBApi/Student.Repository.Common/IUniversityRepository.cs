using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;
using Student.Model.Common;

namespace Student.Repository.Common
{
    public interface IUniversityRepository<University>
    {
        Task<List<University>> GetUniversitiesAsync();

        Task<University> GetUniversityByIdAsync(int id);

        Task<bool> CreateUniversityAsync(University university);

        Task<bool> UpdateUniversityAsync(int id, University university);

        Task<bool> DeleteUniversityAsync(int id);
    }
}
