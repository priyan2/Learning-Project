using AdmissionSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AdmissionSystem.Repository
{
    public class AdminRepository
    {

        string connectionstring = ConfigurationManager.ConnectionStrings["projectConnectionString"].ToString();

        /// <summary>
        /// Adds courses in the admin page
        /// </summary>
        /// <param name="course"></param>
        public void AddCourse(Courses course)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            using (SqlCommand cmd = new SqlCommand("sp_InsertCourse", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@SeatsAvailable", course.SeatsAvailable);
                cmd.Parameters.AddWithValue("@CourseDescription", course.CourseDescription);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

        /// <summary>
        /// update the added courses
        /// </summary>
        /// <param name="course"></param>
        public void UpdateCourse(Courses course)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            using (SqlCommand cmd = new SqlCommand("sp_UpdateCourse", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@SeatsAvailable", course.SeatsAvailable);
                cmd.Parameters.AddWithValue("@CourseDescription", course.CourseDescription);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// deletes the courses 
        /// </summary>
        /// <param name="courseId"></param>
        public void DeleteCourse(int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("sp_DeleteCourse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// List all the added courses
        /// </summary>
        /// <returns></returns>
        public List<Courses> GetCourses()
        {
            try
            {
                List<Courses> courses = new List<Courses>();

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GetCourses", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Courses course = new Courses
                                {
                                    CourseId = (int)reader["CourseId"],
                                    CourseName = reader["CourseName"].ToString(),
                                    SeatsAvailable = (int)reader["SeatsAvailable"],
                                    CourseDescription = reader["CourseDescription"].ToString()
                                };
                                courses.Add(course);
                            }
                        }
                    }
                }
                return courses;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// gets the course by course id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<Courses> GetCourseById(int courseId)
        {
            try
            {
                List<Courses> coursesList = new List<Courses>();

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetCourseById";
                    cmd.Parameters.AddWithValue("@CourseId", courseId);
                    SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                    DataTable dtProducts = new DataTable();

                    connection.Open();
                    sqlDA.Fill(dtProducts);
                    connection.Close();
                    foreach (DataRow dr in dtProducts.Rows)
                    {
                        coursesList.Add(new Courses
                        {
                            CourseId = Convert.ToInt32(dr["CourseId"]),
                            CourseName = dr["CourseName"].ToString(),
                            SeatsAvailable = Convert.ToInt32(dr["SeatsAvailable"]),
                            CourseDescription = dr["CourseDescription"].ToString()
                        });
                    }
                    return coursesList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// adds admins 
        /// </summary>
        /// <param name="registrationstudent"></param>
        /// <returns></returns>
        public bool AddAdmin(Registrationstudent registrationstudent)
        {
            try
            {
                int id = 0;

                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_AdminAddRegistration", connection))
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

        /// <summary>
        /// lists of admins
        /// </summary>
        /// <returns>returns all the admins</returns>
        public List<Registrationstudent> GetAllAdmins()
        {
            try
            {
                List<Registrationstudent> adminlist = new List<Registrationstudent>();
                SqlConnection connection = new SqlConnection(connectionstring);
                SqlCommand command = new SqlCommand("sp_GetAdminDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtstudents = new DataTable();
                connection.Open();
                adapter.Fill(dtstudents);

                foreach (DataRow dr in dtstudents.Rows)
                {
                    adminlist.Add(new Registrationstudent
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
                return adminlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns all the details posted in the contact us page</returns>
        public List<StudentEnquiry> StudentEnquiryList()
        {
            try
            {
                List<StudentEnquiry> studentsEnquiryList = new List<StudentEnquiry>();
                SqlConnection connection = new SqlConnection(connectionstring);
                SqlCommand command = new SqlCommand("sp_GetStudentEnquiry", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtstudents = new DataTable();
                connection.Open();
                adapter.Fill(dtstudents);

                foreach (DataRow dr in dtstudents.Rows)
                {
                    studentsEnquiryList.Add(new StudentEnquiry
                    {
                        Firstname = (dr["Firstname"]).ToString(),
                        Lastname = (dr["Lastname"]).ToString(),
                        Email = (dr["Emailid"]).ToString(),
                        Phonenumber = Convert.ToInt64(dr["Phonenumber"]),
                        Message = (dr["Message"]).ToString()
                    });
                }
                return studentsEnquiryList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}