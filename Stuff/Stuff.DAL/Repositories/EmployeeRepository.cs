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
        public void Update(Employee employee)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
            string sqlExpression = String.Format("INSERT INTO Employees (Id, SurName, Name, MiddleName, EmploymentDate, Position, Company)" +
            " VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}')", employee.Id, employee.Name, employee.MiddleName, employee.AmploymentDate, employee.Position, employee.Company);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                SqlCommand command = new SqlCommand(sqlExpression, connection);
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