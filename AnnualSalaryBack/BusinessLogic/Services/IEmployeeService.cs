using BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(int Id);

        Task<List<Employee>> GetAllEmployeesAsync();
    }
}
