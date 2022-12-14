using GenericAutomapperTests.DTOs;
using GenericAutomapperTests.Services;

namespace GenericAutomapperTests
{
    public class Program
    {
        public static void Main()
        {
            do
            {
                var service = new EmployeeService();

                Console.WriteLine("\nSpecific Object");
                Console.WriteLine(new string('-', 20));
                RunAutoMapperWithSpecificObject(service);

                Console.WriteLine("\nGeneric Object");
                Console.WriteLine(new string('-', 20));
                RunAutoMapperWithGenericObject(service);

                Console.Write("\nRun again(y/n)? ");
            }
            while (Console.ReadKey(false).Key is ConsoleKey.Y);
        }

        private static void RunAutoMapperWithSpecificObject(EmployeeService service)
        {
            var employee = service.GetEmployee(1);
            WriteEmployeeToConsole(employee);
        }

        private static void RunAutoMapperWithGenericObject(EmployeeService service)
        {
            var employee = service.GetGenericEmployee(1);
            WriteEmployeeToConsole(employee);
        }
        private static void WriteEmployeeToConsole(EmployeeDTO employee)
        {
            Console.WriteLine(employee.FirstName + " " +
                              employee.LastName + "\n" +
                              employee.SomeInt + "\n" +
                              employee.StartDate.ToShortDateString());
        }
    }
}