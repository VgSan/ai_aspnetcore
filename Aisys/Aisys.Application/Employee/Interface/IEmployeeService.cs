using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aisys.Application
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployee(int id);
        List<EmployeeDto> GetEmployees();
        Task CreateEmployee(EmployeeInput input);
        Task UpdateEmployee(EmployeeDto input);
        Task DeleteEmployee(List<int> ids);
    }
}
