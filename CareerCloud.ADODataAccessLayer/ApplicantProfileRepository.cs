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
    public class ApplicantProfileRepository : BaseDataRepository, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (ApplicantProfilePoco poco in items)
                {
                    command.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles](Id,Login,Current_Salary,
                                            Current_Rate,Currency,Country_Code,State_Province_Code,
                                        Street_Address,City_Town,Zip_Postal_Code)VALUES(@Id,@Login,@Current_Salary,
                                            @Current_Rate,@Currency,@Country_Code,@State_Province_Code,
                                        @Street_Address,@City_Town,@Zip_Postal_Code)";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.Login);
                    command.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    command.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                    command.Parameters.AddWithValue("@Currency", poco.Currency);
                    command.Parameters.AddWithValue("@Country_Code", poco.Country);
                    command.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    command.Parameters.AddWithValue("@Street_Address", poco.Street);
                    command.Parameters.AddWithValue("@City_Town", poco.City);
                    command.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);
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

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];
            int counter = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Login,Current_Salary,
                              Current_Rate,Currency,Country_Code,State_Province_Code,
                              Street_Address,City_Town,Zip_Postal_Code,Time_Stamp FROM [dbo].[Applicant_Profiles]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantProfilePoco poco = new ApplicantProfilePoco();
                    poco.Id = (Guid)reader[0];
                    poco.Login = (Guid)reader[1];
                    if (!reader.IsDBNull(2))
                        poco.CurrentSalary = (decimal)reader[2];
                    else
                        poco.CurrentSalary = null;
                    if (!reader.IsDBNull(3))
                        poco.CurrentRate = (decimal)reader[3];
                    else
                        poco.CurrentRate = null;
                    if (!reader.IsDBNull(4))
                        poco.Currency = (string)reader[4];
                    else
                        poco.Currency = null;
                    if (!reader.IsDBNull(5))
                        poco.Country = (string)reader[5];
                    else
                        poco.Country = null;
                    if (!reader.IsDBNull(6))
                        poco.Province = (string)reader[6];
                    else
                        poco.Province = null;
                    if (!reader.IsDBNull(7))
                        poco.Street = (string)reader[7];
                    else
                        poco.Street = null;
                    if (!reader.IsDBNull(8))
                        poco.City = (string)reader[8];
                    else
                        poco.City = null;
                    if (!reader.IsDBNull(9))
                        poco.PostalCode = (string)reader[9];
                    else
                        poco.PostalCode = null;
                    poco.TimeStamp = (byte[])reader[10];
                    pocos[counter] = poco;
                    counter++;
                }
            }
            return (pocos.Where(p => p != null)).ToList();
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (ApplicantProfilePoco poco in items)
                {
                    command.CommandText = @"DELETE FROM [dbo].[Applicant_Profiles] WHERE Id =@Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                foreach (ApplicantProfilePoco poco in items)
                {
                    command.CommandText = @"UPDATE [dbo].[Applicant_Profiles] SET Id =@Id,
                    Login=@Login,Current_Salary=@Current_Salary,Current_Rate=@Current_Rate,
                    Currency=@Currency,Country_Code=@Country_Code,State_Province_Code=@State_Province_Code,
                    Street_Address=@Street_Address,City_Town=@City_Town,Zip_Postal_Code=@Zip_Postal_Code 
                    WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", poco.Id);
                    command.Parameters.AddWithValue("@Login", poco.Login);
                    command.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    command.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                    command.Parameters.AddWithValue("@Currency", poco.Currency);
                    command.Parameters.AddWithValue("@Country_Code", poco.Country);
                    command.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    command.Parameters.AddWithValue("@Street_Address", poco.Street);
                    command.Parameters.AddWithValue("@City_Town", poco.City);
                    command.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }
    }
}
