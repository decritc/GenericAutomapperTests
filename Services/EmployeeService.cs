using AutoMapper;
using GenericAutomapperTests.DTOs;
using GenericAutomapperTests.Helpers;
using GenericAutomapperTests.Models;
using GenericAutomapperTests.Repository;

namespace GenericAutomapperTests.Services
{
    internal class EmployeeService
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        private readonly Mapper _mapper;

        public EmployeeService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            _mapper = new Mapper(config);
        }
        public EmployeeDTO GetEmployee(int employeeId)
        {
            var emp = employeeRepository.GetEmployee(employeeId);
            return _mapper.Map<EmployeeDTO>(emp);
        }

        public EmployeeDTO GetGenericEmployee(int employeeId)
        {
            var obj = employeeRepository.GetGenericEmployee(employeeId).ToDictionary();
            return _mapper.Map<EmployeeDTO>(obj);
        }
    }
}
