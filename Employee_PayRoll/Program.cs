namespace Employee_PayRoll
{    class Program
    {
            public static void Main(string[] args)
            {
                Console.WriteLine("Welcome to the Employee Pay Roll Service");
                EmployeeRepo emprepo = new EmployeeRepo();
                emprepo.EstablishConnection();
            }
        }
}
