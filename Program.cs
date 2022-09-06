using TestBed.DTOs;
using TestBed.Services;

namespace TestBed
{
  public class Program
  {
    public static void Main()
    {
      var service = new EmployeeService();

      Console.WriteLine("Specific Object");
      Console.WriteLine(new string('-', 20));
      RunAutoMapperWithSpecificObject(service);
      
      Console.WriteLine("\nGeneric Object");
      Console.WriteLine(new string('-', 20));
      RunAutoMapperWithGenericObject(service);
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