using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Student.Model;
using Student.Service;
using System.Threading.Tasks;

namespace StudentWEBApi.Controllers
{
    public class UniversityController : ApiController
    {
        UniversityService universityService = new UniversityService();

        // GET 
        [HttpGet]
        [Route("api/University")]
        public async Task<HttpResponseMessage> GetAsync()
        {
            List<University> university =await universityService.GetUniversitiesAsync();

            if (university == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There are no universities");
            }
            return Request.CreateResponse(HttpStatusCode.OK, university);
        }

        // GET by id
        [HttpGet]
        [Route("api/University/{University_id}")]
        public async Task<HttpResponseMessage> GetByIdAsync(int university_id)
        {
            University university = await universityService.GetUniversityByIdAsync(university_id);

            if (university == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There is no university with id " + Convert.ToString(university_id));
            }

            return Request.CreateResponse(HttpStatusCode.OK, university);
        }


        // POST 
        [HttpPost]
        [Route("api/University")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] University university)
        {
            bool response = await universityService.CreateUniversityAsync(university);
            if (response != true)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "University with that id already exists.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "University is created");
        }




        // PUT for given id modifies adress 
        [HttpPut]
        [Route("api/University/{university_id}")]
        public async Task<HttpResponseMessage> PutAsync(int university_id, [FromBody] University university)
        {
            bool response =await universityService.UpdateUniversityAsync(university_id, university);

            if (response != true)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "University with id " + Convert.ToString(university_id) + " does not exist.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "University is modified.");
        }


        // DELETE 
        [HttpDelete]
        [Route("api/University/{university_id}")]
        public async Task<HttpResponseMessage> DeleteAsync(int university_id)
        {
            bool response = await universityService.DeleteUniversityAsync(university_id);
            if (response != true)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There is no university with id: " + Convert.ToString(university_id));
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Adress with id " + university_id + " is deleted");
        }
    }
}
