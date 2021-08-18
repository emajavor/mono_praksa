using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWebAPI.Controller
{
    public class Dictionary_students
    {
        public static Dictionary<int, string> students = new Dictionary<int, string>();
    }

    public class HelloController : ApiController
    {
        

        [HttpGet]
        [Route("api/Student")]
        public HttpResponseMessage Get()
        {
            if(Dictionary_students.students.Count == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There are no students found.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, Dictionary_students.students);
            }
        }

        [HttpGet]
        [Route("api/Student/{id}")]
        public HttpResponseMessage Get(int id)
        {
            if (Dictionary_students.students.Count() < id)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with ID " + id.ToString() + " not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, Dictionary_students.students[id]);
            }
        }

        [HttpPost]
        [Route("api/Student/{id}")]
        public HttpResponseMessage Post(int id, [FromBody] string value)
        {
            if (Dictionary_students.students.Count() < id)
            {
                Dictionary_students.students.Add(id, value);
                return Request.CreateResponse(HttpStatusCode.Created, Dictionary_students.students[id]);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with ID " + id.ToString() + " already exists");
            }
        }

        [HttpPut]
        [Route("api/Student/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] string value)
        {
            if (Dictionary_students.students.Count() < id)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with ID " + id.ToString() + " does not exists");
            }
            else
            {
                Dictionary_students.students[id] = value;
                return Request.CreateResponse(HttpStatusCode.OK, "Student with ID " + id.ToString() + " is updated");
            }

        }

        [HttpDelete]
        [Route("api/Student/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if (Dictionary_students.students.Count() < id)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is not a student with  id:" + Convert.ToString(id));
            }
            else
            {
                Dictionary_students.students.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
