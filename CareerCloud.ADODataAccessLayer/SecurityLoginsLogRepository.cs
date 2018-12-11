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
    public class SecurityLoginsLogRepository : BaseDataRepository, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    foreach (SecurityLoginsLogPoco poco in items)
                    {
                        command.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
                                            ([Id]
                                            ,[Login]
                                            ,[Source_IP]
                                            ,[Logon_Date]
                                            ,[Is_Succesful])
                            VALUES(@Id,@Login,@Source_IP,@Logon_Date,@Is_Succesful)";
                        command.Parameters.AddWithValue("@Id", poco.Id);
                        command.Parameters.AddWithValue("@Login", poco.Login);
                        command.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                        command.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                        command.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);

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

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[10000];
            int counter = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Login,Source_IP,Logon_Date,Is_Succesful 
                               FROM [dbo].[Security_Logins_Log]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
                    poco.Id = (Guid)reader[0];
                    poco.Login = (Guid)reader[1];
                    poco.SourceIP = (string)reader[2];
                    poco.LogonDate = (DateTime)reader[3];
                    poco.IsSuccesful = (bool)reader[4];
                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p != null)).ToList();
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Security_Logins_Log] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Security_Logins_Log] SET Id=@Id, Login=@Login,
                                        Source_IP=@Source_IP,Logon_Date=@Logon_Date,Is_Succesful=@Is_Succesful 
                                        WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.Login);
                    command.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                    command.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                    command.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
