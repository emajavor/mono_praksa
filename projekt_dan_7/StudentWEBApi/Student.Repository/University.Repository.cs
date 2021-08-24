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

namespace Student.Repository
{
    public class UniversityRepository : IUniversityRepository<University>

    {
        SqlConnection con = new SqlConnection("Data Source=E\\SQLEXPRESS;Initial Catalog=uni_stud;Integrated Security=True");


        public async Task<List<University>> GetUniversitiesAsync()
        {

            SqlCommand command = new SqlCommand
                ("SELECT * FROM University;", con);
            await con.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<University> list_universities = new List<University>();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    University university = new University();
                    university.University_id = reader.GetInt32(0);
                    university.University_name = reader.GetString(1);                 
                    university.City = reader.GetString(2);
                    


                    list_universities.Add(university);
                }
                reader.Close();
                con.Close();
                return list_universities;
            }
            else
            {
                reader.Close();
                con.Close();
                return null;
            }
        }


        public async Task<University> GetUniversityByIdAsync(int university_id)
        {
            await con.OpenAsync();
            SqlCommand command = new SqlCommand
                ("SELECT * FROM University WHERE University_id = @university_id;", con);

            SqlParameter id_parameter = new SqlParameter("@university_id", System.Data.SqlDbType.Int);

            command.Parameters.Add(id_parameter).Value = university_id;

            SqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                University university = new University();
                while (await reader.ReadAsync())
                {
                    university.University_id = university_id;
                    university.University_name = reader.GetString(1);
                    university.City = reader.GetString(2);
                    


                }
                con.Close();
                return university;
            }
            else
            {
                con.Close();
                return null;
            }
        }

        public async Task<bool>CreateUniversityAsync(University university)
        {
            University _university = new University();
            _university.University_id = university.University_id;
            _university.University_name = university.University_name;
            _university.City = university.City;

            SqlCommand command = new SqlCommand("INSERT INTO University (University_id, University_name , City )" +
                                                "VALUES (@University_id, @University_name, @City)", con);

            SqlCommand command_id = new SqlCommand("SELECT * FROM University WHERE University_id =@University_id ", con);
            command_id.Parameters.Add("@University_id", SqlDbType.Int).Value = _university.University_id;
            await con.OpenAsync();

            SqlDataReader reader = await command_id.ExecuteReaderAsync();    

            if (reader.HasRows)
            {
                return false;
            }

            reader.Close();

            command.Parameters.Add("@University_id", SqlDbType.Int).Value = _university.University_id;
            command.Parameters.Add("@University_name", SqlDbType.VarChar).Value = _university.University_name;
            command.Parameters.Add("@City", SqlDbType.VarChar).Value = _university.City;


            await command.ExecuteNonQueryAsync();
            con.Close();

            return true;

        }


        public async Task<bool> UpdateUniversityAsync(int university_id, University university)
        {
            University _university = new University();
            _university.University_id = university_id;
            _university.University_name = university.University_name;
            _university.City = university.City;

            SqlCommand command_id = new SqlCommand("SELECT * FROM University WHERE University_id =@University_id ", con);
            command_id.Parameters.Add("@University_id", SqlDbType.Int).Value = university_id;
            
            await con.OpenAsync();

            SqlDataReader reader =await command_id.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                return false;
            }

            reader.Close();

            SqlCommand command = new SqlCommand("UPDATE University SET University_name = @University_name,  " +
                                                 "City= @City WHERE University_id= @University_id", con);

            command.Parameters.Add("University_name", SqlDbType.VarChar).Value = _university.University_name;
            command.Parameters.Add("City", SqlDbType.VarChar).Value = _university.City;
            command.Parameters.Add("University_id", SqlDbType.Int).Value = university_id;

            await command.ExecuteNonQueryAsync();
            con.Close();
            return true;
        }

        public async Task<bool> DeleteUniversityAsync(int university_id)
        {
            SqlCommand commandId = new SqlCommand("SELECT * FROM University WHERE University_id=@university_id; ", con);
            SqlCommand command_check = new SqlCommand("SELECT * FROM University WHERE University_id = @university_id; ", con);
            SqlCommand command = new SqlCommand();
            
            await con.OpenAsync();


            commandId.Parameters.Add("@university_id", SqlDbType.Int).Value = university_id;
            command_check.Parameters.Add("@university", SqlDbType.Int).Value = university_id;
            SqlDataReader reader_check = command_check.ExecuteReader();

            if (reader_check.HasRows)
            {
                return false;
            }

            reader_check.Close();

            SqlDataReader reader = commandId.ExecuteReader();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    command = new SqlCommand("DELETE FROM University WHERE University_id=@university_id; ", con);
                    command.Parameters.Add("@university_id", SqlDbType.Int).Value = university_id;
                }
            }
            else
            {
                return false;
            }
            reader.Close();
            await command .ExecuteNonQueryAsync();
            con.Close();
            return true;
        }
    }
}
