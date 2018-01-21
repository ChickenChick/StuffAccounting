using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeesBD;Integrated Security=True";
                string sqlExpression = "INSERT INTO Employees (SurName, Name, MiddleName, EmploymentDate, Position, Company)" +
                " VALUES ('Dzerhachova', 'Alesya', 'Aleksandrovna', '09 01 2017', 'Developer', 0)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine("Добавлено объектов: {0}", number);
                }
                Console.Read();
       

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression2 = "SELECT * FROM Employees";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object surname = reader.GetValue(1);
                        object name = reader.GetValue(2);
                        object middlename = reader.GetValue(3);

                        Console.WriteLine("{0} \t{1} \t{2}", id, surname, name,middlename);
                    }
                }

                reader.Close();
            }

            Console.Read();
        }

    }
}
