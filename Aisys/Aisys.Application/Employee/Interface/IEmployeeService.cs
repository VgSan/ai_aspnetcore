using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aisys.Application
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetEmployees();
        Task CreateEmployee(EmployeeInput input);
        Task UpdateEmployee(EmployeeDto input);
        Task DeleteEmployee(int EmployeeId);
    }
}
