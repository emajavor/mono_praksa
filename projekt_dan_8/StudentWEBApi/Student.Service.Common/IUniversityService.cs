using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;
using StudentWEBApi.Common;

namespace Student.Service.Common
{
    public interface IUniversityService<University>
    {
        Task<List<University>> GetUniversitiesAsync(Sorter sorter, Pager pager, University_filter universityFilter);

        Task<University> GetUniversityByIdAsync(int id);

        Task<bool> CreateUniversityAsync(University university);

        Task<bool> UpdateUniversityAsync(int id, University university);

        Task<bool> DeleteUniversityAsync(int id);
    }
}
