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
    public class ApplicantResumeRepository : BaseDataRepository, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (ApplicantResumePoco poco in items)
                {
                    command.CommandText = @"INSERT INTO [dbo].[Applicant_Resumes](Id,Applicant,Resume,
                    Last_Updated)VALUES(@Id,@Applicant,@Resume,@Last_Updated)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    command.Parameters.AddWithValue("@Resume", poco.Resume);
                    command.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);

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

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[1000];
            int counter = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Applicant,Resume,
                                Last_Updated FROM [dbo].[Applicant_Resumes]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantResumePoco poco = new ApplicantResumePoco();
                    poco.Id = (Guid)reader[0];
                    poco.Applicant = (Guid)reader[1];
                    poco.Resume = (string)reader[2];
                    if (!reader.IsDBNull(3))
                        poco.LastUpdated = (DateTime?)reader[3];
                    else
                        poco.LastUpdated = null;

                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p != null)).ToList();
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (ApplicantResumePoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Applicant_Resumes] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (ApplicantResumePoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Applicant_Resumes] SET Id=@Id,Applicant=@Applicant,
                    Resume=@Resume,Last_Updated=@Last_Updated WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    command.Parameters.AddWithValue("@Resume", poco.Resume);
                    command.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
