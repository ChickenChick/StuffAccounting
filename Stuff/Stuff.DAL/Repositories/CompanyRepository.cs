using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Stuff.DAL.Models;
namespace Stuff.DAL.Repositories
{
    public class CompanyRepository:IDisposable
    {
        public void Dispose()
        {
        }

        public Company Change(int id)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";

            string sqlExpression = string.Format("SELECT * FROM Companies WHERE Id ={0}", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                Company company = new Company();
                while (reader.Read())
                {
                    company.Id = (int)reader.GetValue(0);
                    company.Name = (string)reader.GetValue(1);
                    company.Size = (int)reader.GetValue(2);
                    company.Form = (string)reader.GetValue(3);
                }
                return company;
            }
        }

        public void Delete(int id)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            string sqlExpression = string.Format("DELETE  FROM Companies WHERE Id = {0}", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        public void Update(Company company)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            string sqlExpression = String.Format("INSERT INTO Companies (Name, Size, Form)" +
            "VALUES ('{0}',{1},'{2}')", company.Name, company.Size, company.Form);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                int i = command1.ExecuteNonQuery();
            }
        }

        public List<Company> Read()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT * FROM Companies";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                int i = 0;
                List<Company> ListData = new List<Company>();
                while (reader.Read())
                {                                   // построчно считываем данные
                    ListData.Add(new Company());
                    ListData[i].Id = (int)reader.GetValue(0);
                    ListData[i].Name = (string)reader.GetValue(1);
                    ListData[i].Size = (int)reader.GetValue(2);
                    ListData[i].Form = (string)reader.GetValue(3);
                    i++;
                }
                return ListData;
            }
        }
    }
}