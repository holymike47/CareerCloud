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
    public class CompanyProfileRepository : BaseDataRepository, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyProfilePoco poco in items)
                {
                    command.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
                                            ([Id]
                                            ,[Registration_Date]
                                            ,[Company_Website]
                                            ,[Contact_Phone]
                                            ,[Contact_Name]
                                            ,[Company_Logo])
                   VALUES(@Id,@Registration_Date,@Company_Website,@Contact_Phone,@Contact_Name,@Company_Logo)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    command.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    command.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    command.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    command.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);

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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[1000];
            int counter = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Registration_Date,Company_Website,Contact_Phone,Contact_Name,
                              Company_Logo,Time_Stamp FROM [dbo].[Company_Profiles]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CompanyProfilePoco poco = new CompanyProfilePoco();
                    poco.Id = (Guid)reader[0];
                    poco.RegistrationDate = (DateTime)reader[1];
                    if (!reader.IsDBNull(2))
                        poco.CompanyWebsite = (string)reader[2];
                    else
                        poco.CompanyWebsite = null;
                    poco.ContactPhone = (string)reader[3];
                    if (!reader.IsDBNull(4))
                        poco.ContactName = (string)reader[4];
                    else
                        poco.ContactName = null;
                    if (!reader.IsDBNull(5))
                        poco.CompanyLogo = (byte[])reader[5];
                    else
                        poco.CompanyLogo = null;
                    if (!reader.IsDBNull(6))
                        poco.TimeStamp = (byte[])reader[6];
                    else
                        poco.TimeStamp = null;
                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p != null)).ToList();
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyProfilePoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Company_Profiles] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (CompanyProfilePoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Company_Profiles] SET Id=@Id,
                                           Registration_Date=@Registration_Date,Company_Website=@Company_Website,
                                            Contact_Phone=@Contact_Phone,Contact_Name=@Contact_Name,
                                            Company_Logo=@Company_Logo WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    command.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    command.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    command.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    command.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
