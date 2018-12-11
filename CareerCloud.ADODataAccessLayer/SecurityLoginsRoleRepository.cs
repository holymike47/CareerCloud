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
    public class SecurityLoginsRoleRepository : BaseDataRepository, IDataRepository<SecurityLoginsRolePoco>
    {
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (SecurityLoginsRolePoco poco in items)
                {
                    command.CommandText = @"INSERT INTO [dbo].[Security_Logins_Roles]
                                            ([Id]
                                            ,[Login]
                                            ,[Role])
                                            VALUES(@Id,@Login,@Role)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.Login);
                    command.Parameters.AddWithValue("@Role", poco.Role);

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

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[10000];
            int counter = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Login,Role,Time_Stamp FROM [dbo].[Security_Logins_Roles]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco();
                    poco.Id = (Guid)reader[0];
                    poco.Login = (Guid)reader[1];
                    poco.Role = (Guid)reader[2];
                    poco.TimeStamp = (byte[])reader[3];
                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p != null)).ToList();
        }

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (SecurityLoginsRolePoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Security_Logins_Roles] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (SecurityLoginsRolePoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Security_Logins_Roles] SET Id=@Id,Login=@Login,
                                            Role=@Role WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
