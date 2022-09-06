using TestBed.Models;
using Bogus;
using System.Dynamic;
using TestBed.Helpers;

namespace TestBed.Repository
{
  internal class EmployeeRepository
  {
    public Employee GetEmployee(int employeeId)
    {
      var employee = new Faker<Employee>()
        .RuleFor(o => o.Id, employeeId)
        .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
        .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
        .RuleFor(u => u.Title, (f, u) => f.Name.JobTitle())
        .RuleFor(u => u.StartDate, (f, u) => f.Date.Past());

      return employee;
    }

    internal object GetGenericEmployee(int employeeId)
    {
      var employeeObject = new { Id = 0, FirstName = "", LastName = "", Title = "", StartDate = DateTime.Now};
      var employeeFaker = Helpers.Faker.FromAnonymousType(employeeObject)
        .RuleFor(o => o.Id, employeeId)
        .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
        .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
        .RuleFor(u => u.Title, (f, u) => f.Name.JobTitle())
        .RuleFor(u => u.StartDate, (f, u) => f.Date.Past());

      var employeeList = employeeFaker.Generate(1);
      return employeeList.First();
    }
  }
}
