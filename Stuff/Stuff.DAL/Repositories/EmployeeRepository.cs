using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stuff.DAL.Models;
using System.Data.SqlClient;
using System.Data;

namespace Stuff.DAL.Repositories
{
    public class EmployeeRepository : IDisposable
    {
        public Employee Change(int id)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";

            string sqlExpression = string.Format("SELECT * FROM Employees WHERE Id ={0}", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                Employee employee = new Employee();
                while (reader.Read())
                {
                    employee.Id = (int)reader.GetValue(0);
                    employee.SurName = (string)reader.GetValue(1);
                    employee.Name = (string)reader.GetValue(2);
                    employee.MiddleName = (string)reader.GetValue(3);
                    employee.AmploymentDate = ((DateTime)reader.GetValue(4)).ToShortDateString();
                    employee.Position = (string)reader.GetValue(5);
                    employee.CompanyId = (int)reader.GetValue(6);
                }
                return employee;
            }
        }
        public void Delete(int id)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            string sqlExpression = string.Format("DELETE  FROM Employees WHERE Id = {0}", id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }
        public int TransactId()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";

            string sqlExpression = "SELECT IDENT_CURRENT('Employees')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = Int32.Parse(reader.GetValue(0).ToString());
                }
                return ++count;
            }
        }


        public void Update(Employee employee)
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            string sqlExpression = String.Format("INSERT INTO Employees (SurName, Name, MiddleName, AploymentDate, Position, CompanyId)" +
            "VALUES ('{0}','{1}','{2}','{3}','{4}',{5})", employee.SurName, employee.Name, employee.MiddleName, employee.AmploymentDate, employee.Position, employee.CompanyId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand(sqlExpression, connection);

                int i = command1.ExecuteNonQuery();

            }
        }

        public List<Employee> Read()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT Employees.Id, Employees.Name ,Employees.SurName, Employees.MiddleName," +
                                       "Employees.AploymentDate, Employees.Position, Employees.CompanyId,"+
                                       "Companies.Name FROM Employees,Companies WHERE Companies.Id = Employees.CompanyId";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                int i = 0;
                List<Employee> ListEmployees = new List<Employee>();

                while (reader.Read())
                {
                    ListEmployees.Add(new Employee());
                    ListEmployees[i].Id = reader.GetInt32(0);
                    ListEmployees[i].SurName = reader.GetString(1);
                    ListEmployees[i].Name = reader.GetString(2);
                    ListEmployees[i].MiddleName = reader.GetString(3);
                    ListEmployees[i].AmploymentDate = ((DateTime)reader.GetValue(4)).ToShortDateString();
                    ListEmployees[i].Position = reader.GetString(5);
                    ListEmployees[i].CompanyId = reader.GetInt32(6);
                    ListEmployees[i].CompanyName = reader.GetString(7);
                    i++;
                }
                return ListEmployees;
            }
        }
        public void Dispose()
        {
        }
    }
}
    
               
            
