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
using Student.Service.Common;

namespace StudentWEBApi.Controllers
{
    public class StudentController : ApiController
    {
        IStudentService<Students> studentService;
        //StudentService studentService = new StudentService();
        public StudentController(IStudentService<Students> _studentService)
        {
            studentService = _studentService;
        }
        // GET 
        [HttpGet]
        [Route("api/Student")]
        public async Task<HttpResponseMessage> GetAsync()
        {
            //List<Students> student = studentService.GetStudents();
            List<Students> student = await studentService.GetStudentsAsync();
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There are no students");
            }
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        // GET by id
        [HttpGet]
        [Route("api/Student/{Student_id}")]
        public async Task<HttpResponseMessage> GetByIdAsync(int student_id)
        {
            //Students student = studentService.GetStudentById(student_id);
            Students student = await studentService.GetStudentByIdAsync(student_id);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student with id " + Convert.ToString(student_id) + "does not exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }


        // POST 
        [HttpPost]
        [Route("api/Student")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] Students student)
        {
            bool response = await studentService.CreateStudentAsync(student);
            if (response != true)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"Student with " + Convert.ToString(student.University_id) + " id already exists.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Student is succesfully created");
        }




        // PUT for given id modifies student info
        [HttpPut]
        [Route("api/Student/{student_id}")]
        public async Task<HttpResponseMessage> PutAsync(int student_id, [FromBody] Students student)
        {
            //bool feedback = studentService.UpdateStudent(student_id, student);
            bool response = await studentService.UpdateStudentAsync(student_id, student);
            if (response != true)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There is no student with id " + Convert.ToString(student_id) );
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Student is modified");
        }


        // DELETE 
        [HttpDelete]
        [Route("api/Student/{student_id}")]
        public async Task<HttpResponseMessage> DeleteAsync(int student_id)
        {
            //bool response = studentService.DeleteStudent(student_id);
            bool response = await studentService.DeleteStudentAsync(student_id);
            if (response != true)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There is no student with id " + Convert.ToString(student_id));
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Student with id " + student_id + " is deleted");
        }
    }
}
