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
    public class UniversityService : IuniversityService<University>
    {
        IUniversityRepository<University> universityRepository ;
        public UniversityService(IUniversityRepository<University> _universityRepository)
        {
            universityRepository = _universityRepository;
        }
        public async Task<List<University>> GetUniversitiesAsync()
        {
            return await universityRepository.GetUniversitiesAsync();

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
