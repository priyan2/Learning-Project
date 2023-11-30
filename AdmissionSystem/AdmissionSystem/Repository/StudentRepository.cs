using AdmissionSystem.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AdmissionSystem.Repository
{
    public class StudentRepository
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["projectConnectionString"].ToString();

        //Get registered student details
        public List<Registrationstudent> GetAllStudents()
        {
            try
            {
                List<Registrationstudent> studentslist = new List<Registrationstudent>();
                SqlConnection connection = new SqlConnection(connectionstring);
                SqlCommand command = new SqlCommand("sp_GetStudentDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtstudents = new DataTable();
                connection.Open();
                adapter.Fill(dtstudents);

                foreach (DataRow dr in dtstudents.Rows)
                {
                    studentslist.Add(new Registrationstudent
                    {
                        FirstName = (dr["FirstName"]).ToString(),
                        LastName = (dr["LastName"]).ToString(),
                        Gender = (dr["Gender"]).ToString(),
                        DataOfBirth = (dr["DateOfBirth"]).ToString(),
                        EmailId = (dr["EmailId"]).ToString(),
                        State = (dr["State"]).ToString(),
                        City = dr["City"].ToString(),
                        Username = (dr["Username"]).ToString(),
                        Password = (dr["Password"]).ToString(),
                        Phonenumber = (dr["Phonenumber"]).ToString()
                    });
                }
                return studentslist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //adds student registration into StudentSignup table
        public bool AddStudent(Registrationstudent registrationstudent)
        {
            try
            {
                int id = 0;
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_AddRegistrationStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FirstName", registrationstudent.FirstName);
                        command.Parameters.AddWithValue("@LastName", registrationstudent.LastName);
                        command.Parameters.AddWithValue("@Gender", registrationstudent.Gender);
                        command.Parameters.AddWithValue("@DataOfBirth", registrationstudent.DataOfBirth);
                        command.Parameters.AddWithValue("@EmailId", registrationstudent.EmailId);
                        command.Parameters.AddWithValue("@State", registrationstudent.State);
                        command.Parameters.AddWithValue("@City", registrationstudent.City);
                        command.Parameters.AddWithValue("@Username", registrationstudent.Username);
                        command.Parameters.AddWithValue("@Password", registrationstudent.Password);
                        command.Parameters.AddWithValue("Phonenumber", registrationstudent.Phonenumber);
                        id = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                if (id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Adds Student Enquiry on contact us page into table
        public bool StudentEnquiryDetails(StudentEnquiry studentEnquiry)
        {
            try
            {
                int id = 0;
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("sp_InsertStudentEnquiry", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", studentEnquiry.Firstname);
                        command.Parameters.AddWithValue("@LastName", studentEnquiry.Lastname);
                        command.Parameters.AddWithValue("@EmailId", studentEnquiry.Email);
                        command.Parameters.AddWithValue("@Message", studentEnquiry.Message);
                        command.Parameters.AddWithValue("@Phonenumber", studentEnquiry.Phonenumber);
                        connection.Open();
                        id = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                if (id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> GetState()
        {
            try
            {
                List<string> state = new List<string>();
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand command = new SqlCommand("sp_GetState", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string stateName = reader["StateName"].ToString();
                    state.Add(stateName);

                }
                reader.Close();
                connection.Close();
                return state;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> GetCity(string state)
        {
            try
            {
                List<string> city = new List<string>();
                SqlConnection connection = new SqlConnection(connectionstring);

                SqlCommand command = new SqlCommand("sp_GetCitiesByState", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StateName", state);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string cityName = reader["CityName"].ToString();
                    city.Add(cityName);
                }
                reader.Close();

                connection.Close();

                return city;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void StudentProfileAdd(Registrationstudent registrationstudent)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("sp_InsertStudentProfileDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", registrationstudent.Id);
                        command.Parameters.AddWithValue("@Hscmarks", registrationstudent.HSCMarks);
                        command.Parameters.AddWithValue("@Sslcmarks", registrationstudent.SSLCMarks);
                        command.Parameters.AddWithValue("@Subjectmark1", registrationstudent.Subject1Marks);
                        command.Parameters.AddWithValue("@Subjectmark2", registrationstudent.Subject2Marks);
                        command.Parameters.AddWithValue("@Subjectmark3", registrationstudent.Subject3Marks);
                        command.Parameters.AddWithValue("@Image", registrationstudent.Image);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void StudentDetails(Registrationstudent registrationstudent)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetAllDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@username", registrationstudent.Username);
                        command.Parameters.AddWithValue("@Hscmarks", registrationstudent.HSCMarks);
                        command.Parameters.AddWithValue("@Sslcmarks", registrationstudent.SSLCMarks);
                        command.Parameters.AddWithValue("@Subjectmark1", registrationstudent.Subject1Marks);
                        command.Parameters.AddWithValue("@Subjectmark2", registrationstudent.Subject2Marks);
                        command.Parameters.AddWithValue("@Subjectmark3", registrationstudent.Subject3Marks);
                        command.Parameters.AddWithValue("@Hscgroup", registrationstudent.HSCGroup);
                        command.Parameters.AddWithValue("@Image", registrationstudent.Image);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Registrationstudent> GetAllDetails(int id)
        {
            try
            {
                List<Registrationstudent> studentslist = new List<Registrationstudent>();
                SqlConnection connection = new SqlConnection(connectionstring);
                SqlCommand command = new SqlCommand("sp_GetStudentDetails", connection);
                //command.Parameters.AddWithValue("@Id", registrationstudent.Id);
                command.Parameters.AddWithValue("@Id",id );
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtstudents = new DataTable();
                connection.Open();
                adapter.Fill(dtstudents);
                foreach (DataRow dr in dtstudents.Rows)
                {
                    studentslist.Add(new Registrationstudent
                    {
                        Id = (int)dr["ID"], 
                        FirstName = (dr["FirstName"]).ToString(),
                        LastName = (dr["LastName"]).ToString(),
                        Gender = (dr["Gender"]).ToString(),
                        DataOfBirth = (dr["DateOfBirth"]).ToString(),
                        EmailId = (dr["EmailId"]).ToString(),
                        State = (dr["State"]).ToString(),
                        City = dr["City"].ToString(),
                        Username = (dr["Username"]).ToString(),
                        Password = (dr["Password"]).ToString(),
                        Phonenumber = (dr["Phonenumber"]).ToString(),
                        SSLCMarks = Convert.ToInt32(dr["Sslcmarks"]), 
                        HSCMarks = Convert.ToInt32(dr["Hscmarks"]),
                        Subject1Marks = Convert.ToInt32(dr["Subject1mark"]),
                        Subject2Marks = Convert.ToInt32(dr["Subject2mark"]),
                        Subject3Marks = Convert.ToInt32(dr["Subject3mark"]),
                        Image = dr["Image"] != DBNull.Value ? (byte[])dr["Image"] : null,
                    });
                }
                return studentslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public void ApplyCourse(Registrationstudent registrationstudent, Courses courses)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", registrationstudent.Username);
                        cmd.Parameters.AddWithValue("@CourseName", courses.CourseName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/

        public List<Registrationstudent> ApplyCourse(Registrationstudent registrationstudent,Courses courses, string CourseName)
        {
            try
            {
                List<Registrationstudent> studentslist = new List<Registrationstudent>();
                SqlConnection connection = new SqlConnection(connectionstring);
                SqlCommand command = new SqlCommand("", connection);
                //command.Parameters.AddWithValue("@Id", registrationstudent.Id);
                command.Parameters.AddWithValue("@CourseName", CourseName);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtstudents = new DataTable();
                connection.Open();
                adapter.Fill(dtstudents);

                foreach (DataRow dr in dtstudents.Rows)
                {
                    studentslist.Add(new Registrationstudent
                    {
                        
                        FirstName = (dr["FirstName"]).ToString(),
                        LastName = (dr["LastName"]).ToString(),
                        Gender = (dr["Gender"]).ToString(),
                        DataOfBirth = (dr["DateOfBirth"]).ToString(),
                        EmailId = (dr["EmailId"]).ToString(),
                        State = (dr["State"]).ToString(),
                        City = dr["City"].ToString(),
                        
                        Password = (dr["Password"]).ToString(),
                        Phonenumber = (dr["Phonenumber"]).ToString(),
                        SSLCMarks = Convert.ToInt32(dr["Sslcmarks"]),
                        HSCMarks = Convert.ToInt32(dr["Hscmarks"]),
                        Subject1Marks = Convert.ToInt32(dr["Subject1mark"]),
                        Subject2Marks = Convert.ToInt32(dr["Subject2mark"]),
                        Subject3Marks = Convert.ToInt32(dr["Subject3mark"]),
                        Image = dr["Image"] != DBNull.Value ? (byte[])dr["Image"] : null,

                    });
                }
                return studentslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}