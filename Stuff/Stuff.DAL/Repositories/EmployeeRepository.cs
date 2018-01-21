using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stuff.DAL.Models;
using System.Data.SqlClient;

namespace Stuff.DAL.Repositories
{
    public class EmployeeRepository:IDisposable
    {
        public Employee Change(int id)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";

            string sqlExpression = string.Format("SELECT * FROM Employees WHERE Id ={0}",id);
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
                    employee.AmploymentDate = (string)reader.GetValue(4);
                    employee.Position = (string)reader.GetValue(5);
                    employee.Company = (int)reader.GetValue(6);
                }
                return employee;
            }
        }
        public void Delete(int id)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            string sqlExpression = string.Format( "DELETE  FROM Employees WHERE Id = {0}",id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }
            public void Update(Employee employee)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            string sqlExpression = String.Format("INSERT INTO Employees (SurName, Name, MiddleName, EmploymentDate, Position, Company)" +
            "VALUES ('{0}','{1}','{2}','{3}','{4}',{5})",employee.SurName, employee.Name, employee.MiddleName, employee.AmploymentDate, employee.Position, employee.Company);

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
                string sqlExpression = "SELECT * FROM Employees";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                    int i = 0;
                    List<Employee> ListData = new List<Employee>();
                while (reader.Read())
                {                                   // построчно считываем данные
                    ListData.Add(new Employee());
                    ListData[i].Id = (int)reader.GetValue(0);
                    ListData[i].SurName = (string)reader.GetValue(1);
                    ListData[i].Name = (string)reader.GetValue(2);
                    ListData[i].MiddleName = (string)reader.GetValue(3);
                    ListData[i].AmploymentDate = (string)reader.GetValue(4);
                    ListData[i].Position = (string)reader.GetValue(5);
                    ListData[i].Company = (int)reader.GetValue(6);
                    i++;
                }
                    return ListData;
                }
               
            }

        public void Dispose()
        { 
        }
    }
    }