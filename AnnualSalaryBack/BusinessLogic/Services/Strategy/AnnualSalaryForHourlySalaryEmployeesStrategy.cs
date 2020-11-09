using BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Strategy
{
    public class AnnualSalaryForHourlySalaryEmployeesStrategy : IAnnualSalaryStrategy
    {
        public Employee GetAnnualSalary(Employee employee)
        {
            employee.AnnualSalary = 120 * employee.HourlySalary * 12;
            return employee;
        }
    }
}
