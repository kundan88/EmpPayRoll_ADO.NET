using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPayRoll
{
    public class EmployeeRepo
    {
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLOCALDB;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);

        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                SqlCommand command = new SqlCommand("SpAddNewEmployeeDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@Department", model.Department);
                command.Parameters.AddWithValue("@Gender", model.Gender);
                command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                command.Parameters.AddWithValue("@Deductions", model.Deductions);
                command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                command.Parameters.AddWithValue("@Tax", model.Tax);
                command.Parameters.AddWithValue("@NetPay", model.NetPay);
                command.Parameters.AddWithValue("@StartDate", model.StartDate);
                command.Parameters.AddWithValue("@City", model.City);
                command.Parameters.AddWithValue("@Country", model.Country);
                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
