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
    public class CompanyJobEducationRepository : BaseDataRepository, IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyJobEducationPoco poco in items)
                {
                    command.CommandText = @"INSERT INTO [dbo].[Company_Job_Educations]
                                            ([Id]
                                            ,[Job]
                                            ,[Major]
                                            ,[Importance])
                                            VALUES(@Id,@Job,@Major,@Importance)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Job", poco.Job);
                    command.Parameters.AddWithValue("@Major", poco.Major);
                    command.Parameters.AddWithValue("@Importance", poco.Importance);

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

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[5000];
            int counter = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Job,Major,Importance,Time_Stamp FROM [dbo].[Company_Job_Educations]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
                    poco.Id = (Guid)reader[0];
                    poco.Job = (Guid)reader[1];
                    poco.Major = (string)reader[2];
                    poco.Importance = (short)reader[3];
                    poco.TimeStamp = (byte[])reader[4];
                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p != null)).ToList();
        }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList(); 
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyJobEducationPoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Company_Job_Educations] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyJobEducationPoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Company_Job_Educations] SET Id =@Id,Job=@Job,
                                        Major=@Major,Importance=@Importance WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Job", poco.Job);
                    command.Parameters.AddWithValue("@Major", poco.Major);
                    command.Parameters.AddWithValue("@Importance", poco.Importance);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
