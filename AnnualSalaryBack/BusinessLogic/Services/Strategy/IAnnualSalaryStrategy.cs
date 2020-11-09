using BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Strategy
{
    public interface IAnnualSalaryStrategy
    {
        Employee GetAnnualSalary(Employee employee);
    }
}
