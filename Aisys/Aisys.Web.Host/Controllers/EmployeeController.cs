using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aisys.Application;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace Aisys.Web.Host.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        IEmployeeService _employeeService;

        public EmployeeController(IMapper mapper,
            IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployee")]
        public EmployeeDto GetEmployee(int id)
        {
            EmployeeDto employee = _employeeService.GetEmployee(id);
            return employee;
        }

        [HttpGet("GetEmployees")]
        public List<EmployeeDto> GetEmployees()
        {
            List<EmployeeDto> employeeList = _employeeService.GetEmployees();
            return employeeList;
        }

        [HttpPost("CreateEmployee")]
        public async Task CreateEmployee([FromBody] EmployeeInput input)
        {
            await _employeeService.CreateEmployee(input);
        }

        [HttpPut("UpdateEmployee")]
        public async Task UpdateEmployee([FromBody] EmployeeDto input)
        {
            await _employeeService.UpdateEmployee(input);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task DeleteEmployee(string ids)
        {
            List<int> idsArr = ids.Split(',').Select(int.Parse).ToList();
            await _employeeService.DeleteEmployee(idsArr);
        }
    }
}