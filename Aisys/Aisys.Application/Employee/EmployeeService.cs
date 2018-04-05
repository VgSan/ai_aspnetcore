using AutoMapper;
using Aisys.Application;
using Aisys.Core;
using Aisys.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aisys.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        IGenericRepository<Employee> _employeeRepository;
        IGenericRepository<User> _userRepository;

        public EmployeeService(IMapper mapper,
            IGenericRepository<Employee> employeeRepository,
            IGenericRepository<User> userRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public async Task CreateEmployee(EmployeeInput input)
        {
            Employee result = _mapper.Map<Employee>(input);

            // Create User for nem employee: default password : "1234"
            await _userRepository.Create(new User() { Email = result.Email, Password = "1234" });
            await _employeeRepository.Create(result);
        }

        public async Task DeleteEmployee(int EmployeeId)
        {
            await _employeeRepository.Delete(EmployeeId);
        }

        public List<EmployeeDto> GetEmployees()
        {
            List<Employee> listOfExperince = _employeeRepository.GetAll().ToList();
            var result = _mapper.Map<List<EmployeeDto>>(listOfExperince);

            return result;
        }

        public async Task UpdateEmployee(EmployeeDto input)
        {
            Employee result = _mapper.Map<Employee>(input);
            result.ModifiedDate = DateTime.Now;

            await _employeeRepository.Update(input.Id, result);
        }
    }
}