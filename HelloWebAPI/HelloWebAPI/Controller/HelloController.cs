using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace HelloWebAPI.Controller
{
    public class Student
    {
        public string student_id, student_name, univ_id;
    }

    public class HelloController : ApiController
    {
        

        SqlConnection con = new SqlConnection("Data Source=E; database=SQLEXPRESS;Integrated Security=True");
        List<Student> list_students = new List<Student>();

        

        [HttpGet]
        [Route("api/Student")]
        public HttpResponseMessage Get()
        {

            using (con)
            {
                SqlCommand cmd = new SqlCommand(
                   "SELECT * FROM Student;", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.student_id = reader.GetString(0);
                        student.student_name = reader.GetString(1);
                        student.univ_id = reader.GetString(2);

                        list_students.Add(student);
                    }
                    con.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, list_students);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There are no students");
                }
                
            }
            
        }

        [HttpGet]
        [Route("api/Student/{student_id}")]
        public HttpResponseMessage Get(int student_id)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand(
                  "SELECT * FROM Student WHERE student_id = @student_id;", con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.student_id = reader.GetString(0);
                        student.student_name = reader.GetString(1);
                        student.univ_id = reader.GetString(2);

                        list_students.Add(student);
                    }
                    con.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, list_students);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There are no students with that id.");
                }

            }
        }

        [HttpPost]
        [Route("api/Student/{student_id}")]
        public HttpResponseMessage Post(int student_id, [FromBody] string student_name)
        {
            try
            {
                using (con)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = new SqlCommand();
                    string queryString = "INSERT INTO Student VALUES (@student_id, @student_name);";
                    

                    SqlCommand cmd = new SqlCommand(
                      queryString);
                    cmd.Parameters.Add("@student_id", System.Data.SqlDbType.Int, 5).Value = student_id;
                    cmd.Parameters.Add("@student_name", System.Data.SqlDbType.VarChar, 40).Value = student_name;
                    adapter.InsertCommand = cmd;

                    


                    return Request.CreateResponse(HttpStatusCode.Created, "Student: " + student_name + " is created.");

                    


                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student with that ide already exists " );
            }
        }

        [HttpPut]
        [Route("api/Student/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] string value)
        {
            try
            {
                using (con)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.UpdateCommand = new SqlCommand();
                    SqlCommand cmd = new SqlCommand(
                      "UPDATE Student SET student_id = @student_id,student_name = @student_name " +
                        "WHERE student_id = @student_id", con);



                    cmd.Parameters.Add("@student_id", System.Data.SqlDbType.Int, 5, "student_id");
                    cmd.Parameters.Add("@student_name", System.Data.SqlDbType.VarChar, 40, "student_name");
                    SqlParameter parameter = cmd.Parameters.Add(
                        "@student_id", System.Data.SqlDbType.Int, 5, "student_id");


                    adapter.UpdateCommand = cmd;
                    return Request.CreateResponse(HttpStatusCode.OK, "Student is updated.");
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student with that id does not exists ");
            }
            
            

        }

        [HttpDelete]
        [Route("api/Student/{student_id}")]
        public HttpResponseMessage Delete(int student_id)
        {
            try
            {
                using (con)
                {
                    
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.DeleteCommand = new SqlCommand();
                    string queryString = "DELETE FROM Student.student_name WHERE student_id= @student_id;";

                    SqlCommand cmd = new SqlCommand(
                      queryString);
                    cmd.Parameters.Add("@student_id", System.Data.SqlDbType.Int, 11, "@student_id");
                    
                    adapter.DeleteCommand = cmd;




                    return Request.CreateResponse(HttpStatusCode.OK, "Student is deleted.");




                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student with that id does not exists ");
            }
        }
    }
}
