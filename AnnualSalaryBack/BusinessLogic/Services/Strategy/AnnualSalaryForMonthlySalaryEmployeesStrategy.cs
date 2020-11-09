using BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Strategy
{
    public class AnnualSalaryForMonthlySalaryEmployeesStrategy : IAnnualSalaryStrategy
    {
        public Employee GetAnnualSalary(Employee employee)
        {
            employee.AnnualSalary = employee.MonthlySalary * 12;
            return employee;
        }
    }
}
