using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source = LENOVO - PC\HUMBERBRIDGING; Initial Catalog = JOB_PORTAL_DB;Integrated Security = True; ");

            using (connection)
            {

            connection.Open();

                string query = "select * from Applicant_Educations";

                SqlCommand cmd = new SqlCommand(query, connection);

                ApplicantEducation[] applicantEducations = new ApplicantEducation[1000];
                int index = 0;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantEducation edu = new ApplicantEducation();
                    edu.Id = (Guid)reader[0];  //[0]=["Id"]
                    edu.Applicant = (Guid)reader["Applicant"];
                    edu.Major = (string)reader["Major"];
                    edu.Start_Date = (DateTime)reader["Start_Date"];

                    applicantEducations[index] = edu;
                    index++;
                }
            }
        }
                 class ApplicantEducation
        { 
            public Guid Id;
            public Guid Applicant;
            public string Major;
            public DateTime Start_Date;
                                 

                }
            }
    }

