
using EmployeesDomain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace InterfaceEmployees
{

    public class Employees : IEmployees
    {
        string connectionString = "";

        public Employees()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        }

        public async Task<List<EmployeeModel>> getEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<EmployeeModel> employeeList = new List<EmployeeModel>();

                SqlCommand cmd = new SqlCommand("sigrha.dbo.getEmployees", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.IdEmployees = (int)dr["IdEmployees"];
                        employee.Name = dr["Name"].ToString();
                        employee.LastName = dr["LastName"].ToString();
                        employeeList.Add(employee);
                    }
                    return employeeList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        Task<List<EmployeeModel>> IEmployees.getEmployees()
        {
            throw new NotImplementedException();
        }
    }
}