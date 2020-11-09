using BusinessLogic.Dto;
using BusinessLogic.Exceptions;
using BusinessLogic.Ports;
using BusinessLogic.Services.Strategy;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private const string EMPLOYEE_EMPTY = "Employee empty";
        private readonly ILogger _Logger;
        private readonly IEmployee _Employee;
        private readonly Context _Context;

        public EmployeeService(ILogger Logger, IEmployee Employee)
        {
            this._Logger = Logger;
            this._Employee = Employee;
            this._Context = new Context();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            Employee employeeWithAnnualSalary;
            try
            {
                List<Employee> employees = await _Employee.GetEmployees().ConfigureAwait(false);
                Employee employee = GetEmployee(Id, employees);
                ValidateInformationEmployee(employee);
                employeeWithAnnualSalary = _Context.Execute(employee);
            }
            catch (EmployeeEmptyException)
            {
                throw;
            }
            catch (Exception exception)
            {
                _Logger.Error(exception, exception.Message);
                throw new EmployeeException(exception.Message, exception);
            }
            return employeeWithAnnualSalary;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            List<Employee> employees;
            try
            {
                employees = await _Employee.GetEmployees().ConfigureAwait(false);
                employees.ForEach(employee => _Context.Execute(employee));
            }
            catch (Exception exception)
            {
                _Logger.Error(exception, exception.Message);
                throw new EmployeeException(exception.Message, exception);
            }
            return employees;
        }

        private Employee GetEmployee(int Id, List<Employee> employees)
        {
            return employees.FirstOrDefault(employee => employee.Id == Id);
        }

        private void ValidateInformationEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new EmployeeEmptyException(EMPLOYEE_EMPTY);
            }
        }
    }
}
