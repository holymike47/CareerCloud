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
    public class CompanyJobRepository : BaseDataRepository, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyJobPoco poco in items)
                {
                    command.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
                                        ([Id]
                                        ,[Company]
                                        ,[Profile_Created]
                                        ,[Is_Inactive]
                                        ,[Is_Company_Hidden])
                                        VALUES(@Id,@Company,@Profile_Created,@Is_Inactive,@Is_Company_Hidden)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Company", poco.Company);
                    command.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
                    command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    command.Parameters.AddWithValue("@Is_Company_Hidden", poco.IsCompanyHidden);

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

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            CompanyJobPoco[] pocos = new CompanyJobPoco[5000];
            int counter = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Company,Profile_Created,Is_Inactive,Is_Company_Hidden,Time_Stamp 
                              FROM [dbo].[Company_Jobs]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobPoco poco = new CompanyJobPoco();
                    poco.Id = (Guid)reader[0];
                    poco.Company = (Guid)reader[1];
                    poco.ProfileCreated = (DateTime)reader[2];
                    poco.IsInactive = (bool)reader[3];
                    poco.IsCompanyHidden = (bool)reader[4];
                    poco.TimeStamp = (byte[])reader[5];
                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p != null)).ToList();
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyJobPoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Company_Jobs] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyJobPoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Company_Jobs] SET Id=@Id,Company=@Company,
                                           Profile_Created=@Profile_Created,Is_Inactive=@Is_Inactive,
                                            Is_Company_Hidden=@Is_Company_Hidden WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Company", poco.Company);
                    command.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
                    command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    command.Parameters.AddWithValue("@Is_Company_Hidden", poco.IsCompanyHidden);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
