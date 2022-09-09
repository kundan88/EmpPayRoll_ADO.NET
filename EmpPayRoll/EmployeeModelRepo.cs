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
        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            SqlCommand command = new SqlCommand("spViewEmployeeData", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader row = command.ExecuteReader();


            EmployeeModel model = new EmployeeModel();

            while (row.Read())
            {

                model.EmployeeId = row.GetInt32(0);
                model.EmployeeName = row.GetString(1);
                model.PhoneNumber = row.GetString(2);
                model.Address = row.GetString(3);
                model.Department = row.GetString(4);
                model.Gender = row.GetString(5);
                model.BasicPay = row.GetInt32(6);
                model.Deductions = row.GetInt32(7);
                model.TaxablePay = row.GetInt32(8);
                model.Tax = row.GetInt32(9);
                model.NetPay = row.GetInt32(10);
                model.StartDate = row.GetDateTime(11);
                model.City = row.GetString(12);
                model.Country = row.GetString(13);

                employees.Add(model);
                Console.WriteLine(model.EmployeeId + " " + model.EmployeeName + " " + model.PhoneNumber + " " + model.Address + " " + model.Department + " " + model.StartDate + " " + model.Address + " " + model.Gender + " " + model.BasicPay + " " + model.Deductions + " " + model.TaxablePay + " " + model.Tax + " " + model.NetPay + " " + model.StartDate + " " + model.City + " " + model.Country);

            }

            connection.Close();
            return employees;
        }
        public bool UpdateEmp(EmployeeModel obj)
        {

            SqlCommand com = new SqlCommand("SPUpdateEmpDetails", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeName", obj.EmployeeName);
            com.Parameters.AddWithValue("@BasicPay", obj.BasicPay);

            connection.Open();
            int i = com.ExecuteNonQuery();
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
        public bool DeleteEmployee(int EmployeeId)
        {

            SqlCommand com = new SqlCommand("spDeleteData", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", EmployeeId);

            connection.Open();
            int i = com.ExecuteNonQuery();
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

    }
}
