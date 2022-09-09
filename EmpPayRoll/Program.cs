namespace EmpPayRoll
{
    class Program
    {
        public static void Main(string[] args)
        {
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = "Kundan";
            model.PhoneNumber = "7410741141";
            model.Address = "Mumbai";
            model.Department = "IT";
            model.Gender = "M";
            model.BasicPay = 182;
            model.Deductions = 500;
            model.TaxablePay = 150;
            model.Tax = 1200;
            model.NetPay = 160;
            model.StartDate = DateTime.Now;
            model.City = "Colaba";
            model.Country = "India";


           // repo.AddEmployee(model);
            repo.GetAllEmployees();
        }
    }
}

