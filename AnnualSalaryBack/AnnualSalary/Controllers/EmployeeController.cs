using BusinessLogic.Dto;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnualSalary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService EmployeeService)
        {
            this._EmployeeService = EmployeeService;
        }

        [HttpGet("GetEmployees")]
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _EmployeeService.GetAllEmployeesAsync().ConfigureAwait(false);
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _EmployeeService.GetEmployeeByIdAsync(id).ConfigureAwait(false);
        }
    }
}
