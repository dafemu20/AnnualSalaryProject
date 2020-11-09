using BusinessLogic.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Ports
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployees();
    }
}
