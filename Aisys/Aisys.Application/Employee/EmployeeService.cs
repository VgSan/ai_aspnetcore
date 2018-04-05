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

        public async Task DeleteEmployee(List<int> ids)
        {
            foreach (int id in ids)
            {
                Employee emp = _employeeRepository.GetById(id);
                if (emp != null)
                {
                    //emp.IsActive = false;
                    //await _employeeRepository.Update(emp.Id, emp);
                    await _employeeRepository.Delete(id);
                }
            }
        }

        public EmployeeDto GetEmployee(int id)
        {
            Employee employee = _employeeRepository.GetAll()
                .Where(e => e.Id == id && e.IsActive == true).FirstOrDefault();
            var result = _mapper.Map<EmployeeDto>(employee);

            return result;
        }

        public List<EmployeeDto> GetEmployees()
        {
            List<Employee> listOfExperince = _employeeRepository.GetAll()
                .Where(e => e.IsActive == true).ToList();
            var result = _mapper.Map<List<EmployeeDto>>(listOfExperince);

            return result;
        }

        public async Task UpdateEmployee(EmployeeDto input)
        {
            Employee result = _mapper.Map<Employee>(input);
            Employee exsEmp = _employeeRepository.GetById(input.Id);

            result.ModifiedDate = DateTime.Now;

            await _employeeRepository.Update(input.Id, result);

            User user = _userRepository.GetAll().Where(u => u.Email == exsEmp.Email).FirstOrDefault();
            if(user != null)
            {
                user.Email = result.Email;
                await _userRepository.Update(user.Id, user);
            } else
            {
                await _userRepository.Create(new User() { Email = result.Email, Password = "1234" });
            }
        }
    }
}