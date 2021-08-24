using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Student.Model;
using System.Threading.Tasks;
using Student.Repository.Common;
//
namespace Student.Repository
{
    public class StudentRepository : IStudentRepository<Students>
    {
        SqlConnection con = new SqlConnection("Data Source=E\\SQLEXPRESS;Initial Catalog=uni_stud;Integrated Security=True");


        public async Task<List<Students>> GetStudentsAsync()
        {

            SqlCommand command = new SqlCommand
                ("SELECT * FROM Student;", con);
            await con.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<Students> list_students = new List<Students>();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    Students student = new Students();
                    student.Student_id = reader.GetInt32(0);
                    student.First_name = reader.GetString(1);
                    student.Last_name = reader.GetString(2);
                    student.University_id = reader.GetInt32(3);


                    list_students.Add(student);
                }
                reader.Close();
                con.Close();
                return list_students;
            }
            else
            {
                reader.Close();
                con.Close();
                return null;
            }
        }


        public async Task<Students> GetStudentByIdAsync(int Student_id)
        {
            await con.OpenAsync();
            SqlCommand command = new SqlCommand
                ("SELECT * FROM Student WHERE Student_id = @Student_id;", con);

            SqlParameter id_parameter = new SqlParameter("@Student_id", System.Data.SqlDbType.Int);

            command.Parameters.Add(id_parameter).Value = Student_id;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Students student = new Students();
                while (await reader.ReadAsync())
                {

                    student.Student_id = Student_id;
                    student.First_name = reader.GetString(1);
                    student.Last_name = reader.GetString(2);
                    student.University_id = reader.GetInt32(3);


                }
                con.Close();
                return student;
            }
            else
            {
                con.Close();
                return null;
            }
        }

        public async Task<bool> CreateStudentAsync(Students student)
        {

            Students _student = new Students();
            _student.Student_id = student.Student_id;
            _student.First_name = student.First_name;
            _student.Last_name = student.Last_name;
            _student.University_id = student.University_id;

            SqlCommand command = new SqlCommand("INSERT INTO Student (Student_id, First_name , Last_name , University_id )" +
                                                "VALUES (@Student_id, @First_name, @Last_name, @University_id); ", con);

            SqlCommand command_id = new SqlCommand("SELECT * FROM Student WHERE Student_id =@Student_id ", con);
            command_id.Parameters.Add("Student_id", SqlDbType.Int).Value = _student.Student_id;
            SqlCommand command_check = new SqlCommand("SELECT * FROM Student WHERE University_id = @university_id; ", con);
            command_check.Parameters.Add("@university_id", SqlDbType.Int).Value = _student.University_id;

            await con.OpenAsync();

            SqlDataReader reader_check_unique =await command_id.ExecuteReaderAsync();    

            if (reader_check_unique.HasRows)
            {
                return false;
            }

            reader_check_unique.Close();

            SqlDataReader reader_check =await command_check.ExecuteReaderAsync();    

            if (!reader_check.HasRows)
            {
                return false;
            }

            reader_check.Close();

            command.Parameters.Add("@Student_id", SqlDbType.Int).Value = _student.Student_id;
            command.Parameters.Add("@First_name", SqlDbType.VarChar).Value = _student.First_name;
            command.Parameters.Add("@Last_name", SqlDbType.VarChar).Value = _student.University_id;


            await command.ExecuteNonQueryAsync();
            con.Close();
            return true;

        }


        public async Task<bool> UpdateStudentAsync(int student_id, Students student)
        {
            Students _student = new Students();
            _student.Student_id = student_id;
            _student.First_name = student.First_name;
            _student.Last_name = student.Last_name;
            _student.University_id = student.University_id;

            SqlCommand command_id = new SqlCommand("SELECT * FROM Student WHERE Student_id =@Student_id ", con);
            command_id.Parameters.Add("Student_id", SqlDbType.Int).Value = student_id;

            SqlCommand command_check = new SqlCommand("SELECT * FROM Student WHERE University_id = @university_id; ", con);
            command_check.Parameters.Add("@university_id", SqlDbType.Int).Value = _student.University_id;

            await con.OpenAsync();

            SqlDataReader reader_check =await command_check.ExecuteReaderAsync();        

            if (!reader_check.HasRows)
            {
                return false;
            }

            reader_check.Close();

            SqlDataReader reader = await command_check.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                return false;
            }

            reader.Close();

            SqlCommand command = new SqlCommand("UPDATE Student SET First_name = @First_name, Last_name=@Last_name, " +
                                                 "University_id=@University_id WHERE Student_id=@Student_id", con);

            command.Parameters.Add("First_name", SqlDbType.VarChar).Value = _student.First_name;
            command.Parameters.Add("Last_name", SqlDbType.VarChar).Value = _student.Last_name;
            command.Parameters.Add("University_id", SqlDbType.Int).Value = _student.University_id;
            command.Parameters.Add("Student_id", SqlDbType.Int).Value = student_id;

            await command.ExecuteNonQueryAsync();
            con.Close();
            return true;
        }

        public async Task<bool> DeleteStudentAsync(int student_id)
        {
            SqlCommand commandId = new SqlCommand("SELECT * FROM Student WHERE Student_id=@student_id; ", con);
            SqlCommand command = new SqlCommand();
            await con.OpenAsync();

            commandId.Parameters.Add("@student_id", SqlDbType.Int).Value = student_id;
            SqlDataReader reader = await commandId.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {

                    command = new SqlCommand("DELETE FROM Student WHERE Student_id=@student_id; ", con);
                    command.Parameters.Add("@student_id", SqlDbType.Int).Value = student_id;
                }
            }

            else
            {
                return false;
            }
            reader.Close();
            await command.ExecuteNonQueryAsync();
            con.Close();
            return true;
        }
    }
}
