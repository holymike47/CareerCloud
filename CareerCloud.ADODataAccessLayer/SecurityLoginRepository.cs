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
    public class SecurityLoginRepository : BaseDataRepository, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (SecurityLoginPoco poco in items)
                {
                    command.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                                            ([Id]
                                            ,[Login]
                                            ,[Password]
                                            ,[Created_Date]
                                            ,[Password_Update_Date]
                                            ,[Agreement_Accepted_Date]
                                            ,[Is_Locked]
                                            ,[Is_Inactive]
                                            ,[Email_Address]
                                            ,[Phone_Number]
                                            ,[Full_Name]
                                            ,[Force_Change_Password]
                                            ,[Prefferred_Language])
                                        VALUES(@Id,@Login,@Password,@Created_Date,@Password_Update_Date,
                                        @Agreement_Accepted_Date,@Is_Locked,@Is_Inactive,@Email_Address,
                                        @Phone_Number,@Full_Name,@Force_Change_Password,@Prefferred_Language)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.Login);
                    command.Parameters.AddWithValue("@Password", poco.Password);
                    command.Parameters.AddWithValue("@Created_Date", poco.Created);
                    command.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    command.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    command.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    command.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    command.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    command.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    command.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    command.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);

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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SecurityLoginPoco[] pocos = new SecurityLoginPoco[10000];
            int counter = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Login,Password,Created_Date,Password_Update_Date,Agreement_Accepted_Date,
                            Is_Locked,Is_Inactive,Email_Address,Phone_Number,Full_Name,Force_Change_Password,
                            Prefferred_Language,Time_Stamp FROM [dbo].[Security_Logins]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();
                    poco.Id = (Guid)reader[0];
                    poco.Login = (string)reader[1];
                    poco.Password = (string)reader[2];
                    poco.Created = (DateTime)reader[3];
                    if (!reader.IsDBNull(4))
                        poco.PasswordUpdate = (DateTime?)reader[4];
                    else
                        poco.PasswordUpdate = null;
                    if (!reader.IsDBNull(5))
                        poco.AgreementAccepted = (DateTime?)reader[5];
                    else
                        poco.AgreementAccepted = null;
                    poco.IsLocked = (bool)reader[6];
                    poco.IsInactive = (bool)reader[7];
                    poco.EmailAddress = (string)reader[8];
                    if (!reader.IsDBNull(9))
                        poco.PhoneNumber = (string)reader[9];
                    else
                        poco.PhoneNumber = null;
                    if (!reader.IsDBNull(10))
                        poco.FullName = (string)reader[10];
                    else
                        poco.FullName = null;
                    poco.ForceChangePassword = (bool)reader[11];
                    if (!reader.IsDBNull(12))
                        poco.PrefferredLanguage = (string)reader[12];
                    else
                        poco.PrefferredLanguage = null;
                    poco.TimeStamp = (byte[])reader[13];
                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p != null)).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (SecurityLoginPoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Security_Logins] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (SecurityLoginPoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Security_Logins] SET Id=@Id,Login=@Login,Password=@Password,
                                          Created_Date=@Created_Date,Password_Update_Date=@Password_Update_Date,
                                         Agreement_Accepted_Date=@Agreement_Accepted_Date,
                                        Is_Locked=@Is_Locked,Is_Inactive=@Is_Inactive,Email_Address=@Email_Address,
                                        Phone_Number=@Phone_Number,Full_Name=@Full_Name,
                                        Force_Change_Password=@Force_Change_Password,
                                        Prefferred_Language=@Prefferred_Language WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.Login);
                    command.Parameters.AddWithValue("@Password", poco.Password);
                    command.Parameters.AddWithValue("@Created_Date", poco.Created);
                    command.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    command.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    command.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    command.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    command.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    command.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    command.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    command.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
