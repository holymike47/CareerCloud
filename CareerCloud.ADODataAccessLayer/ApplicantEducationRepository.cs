using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : BaseDataRepository, IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;        
                foreach (ApplicantEducationPoco poco in items)
                {
                    command.CommandText = @"INSERT INTO [dbo].[Applicant_Educations](Id,Applicant,Major,Certificate_Diploma,
                             Start_Date,Completion_Date,Completion_Percent)VALUES(@Id,@Applicant,@Major,
                             @Certificate_Diploma,@Start_Date,@Completion_Date,@Completion_Percent)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    command.Parameters.AddWithValue("@Major", poco.Major);
                    command.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    command.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    command.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    command.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];
            int counter = 0;
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Applicant,Major,Certificate_Diploma,Start_Date,Completion_Date,
                               Completion_Percent,Time_Stamp FROM [dbo].[Applicant_Educations]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();
                    poco.Id = (Guid)reader[0];
                    poco.Applicant = (Guid)reader[1];
                    poco.Major = (string)reader[2];
                    poco.CertificateDiploma = (string)reader[3];
                    if (!reader.IsDBNull(4))
                        poco.StartDate = (DateTime)reader[4];
                    else
                        poco.StartDate = null;
                    if (!reader.IsDBNull(5))
                        poco.CompletionDate = (DateTime)reader[5];
                    else
                        poco.CompletionDate = null;
                    if (!reader.IsDBNull(6))
                        poco.CompletionPercent = (byte?)reader[6];
                    else
                        poco.CompletionPercent = null;
                    poco.TimeStamp = (byte[])reader[7];
                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p!=null)).ToList();
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();

        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }
            
      

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            { 
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (ApplicantEducationPoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Applicant_Educations] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (ApplicantEducationPoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Applicant_Educations] SET Id =@Id,Applicant=@Applicant,Major=@Major,
                             Certificate_Diploma=@Certificate_Diploma,Start_Date=@Start_Date,Completion_Date
                             =@Completion_Date,Completion_Percent=@Completion_Percent WHERE Id = @Id";   
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    command.Parameters.AddWithValue("@Major", poco.Major);
                    command.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    command.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    command.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    command.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
