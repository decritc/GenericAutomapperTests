using GenericAutomapperTests.Models;
using Bogus;

namespace GenericAutomapperTests.Repository
{
    internal class EmployeeRepository
    {
        private readonly Random _random = new Random();
        private const int _MaxYearsToGoBack = 10;

        public Employee GetEmployee(int employeeId)
        {
            var employee = new Faker<Employee>()
                .RuleFor(o => o.Id, employeeId)
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(u => u.Title, (f, u) => f.Name.JobTitle())
                .RuleFor(u => u.StartDate, (f, u) => f.Date.Past(_random.Next(_MaxYearsToGoBack)));

            return employee;
        }

        internal object GetGenericEmployee(int employeeId)
        {
            var employeeObject = new { Id = 0, FirstName = "", LastName = "", Title = "", StartDate = DateTime.Now };
            var employeeFaker = Helpers.Faker.FromAnonymousType(employeeObject)
              .RuleFor(o => o.Id, employeeId)
              .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
              .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
              .RuleFor(u => u.Title, (f, u) => f.Name.JobTitle())
              .RuleFor(u => u.StartDate, (f, u) => f.Date.Past(_random.Next(_MaxYearsToGoBack)));

            var employeeList = employeeFaker.Generate(1);
            return employeeList.First();
        }
    }
}
