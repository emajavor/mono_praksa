using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;
using Student.Repository;
using Student.Service.Common;
using Student.Repository.Common;
using StudentWEBApi.Common;

namespace Student.Service
{
    public class UniversityService : IUniversityService<University>
    {
        IUniversityRepository universityRepository ;
        public UniversityService(IUniversityRepository _universityRepository)
        {
            universityRepository = _universityRepository;
        }
        public async Task<List<University>> GetUniversitiesAsync(Sorter sorter, Pager pager, University_filter universityFilter)
        {
            return await universityRepository.GetUniversitiesAsync(sorter, pager, universityFilter);

        }

        public async Task<University> GetUniversityByIdAsync(int id)
        {
            return await universityRepository.GetUniversityByIdAsync(id);
        }

        public async Task<bool> CreateUniversityAsync(University university)
        {
            return await universityRepository.CreateUniversityAsync(university);
        }

        public async Task<bool> UpdateUniversityAsync(int id, University university)
        {
            return await universityRepository.UpdateUniversityAsync(id, university);
        }

        public async Task<bool> DeleteUniversityAsync(int id)
        {
            return await universityRepository.DeleteUniversityAsync(id);
        }
    }
}
