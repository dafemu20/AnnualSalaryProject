using BusinessLogic.Dto;
using BusinessLogic.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Strategy
{
    public class Context
    {
        public Employee Execute(Employee employee)
        {
            IAnnualSalaryStrategy strategy = GetStrategy(employee);
            return strategy.GetAnnualSalary(employee);
        }

        private IAnnualSalaryStrategy GetStrategy(Employee employee)
        {
            IAnnualSalaryStrategy strategy;
            if (employee.ContractTypeName.Equals(EContractTypeName.HourlySalaryEmployee.GetStringValue()))
            {
                strategy = new AnnualSalaryForHourlySalaryEmployeesStrategy();
            }
            else
            {
                strategy = new AnnualSalaryForMonthlySalaryEmployeesStrategy();
            }
            return strategy;
        }
    }
}
