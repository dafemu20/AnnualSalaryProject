using BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Test
{
    public class EmployeeTestDataBuilder
    {
        int Id;
        readonly string Name;
        string ContractTypeName;
        readonly int RoleId;
        readonly string RoleName;
        readonly string RoleDescription;
        double HourlySalary;
        double MonthlySalary;

        public EmployeeTestDataBuilder()
        {
            this.Id = 1;
            this.Name = "Daniel";
            this.ContractTypeName = "MonthlySalaryEmployee";
            this.RoleId = 1;
            this.RoleName = "Contractor";
            this.RoleDescription = null;
            this.HourlySalary = 60000;
            this.MonthlySalary = 80000;
        }

        public EmployeeTestDataBuilder WithId(int id)
        {
            this.Id = id;
            return this;
        }

        public EmployeeTestDataBuilder WithContractTypeName(string contractTypeName)
        {
            this.ContractTypeName = contractTypeName;
            return this;
        }

        public EmployeeTestDataBuilder WithHourlySalary(double hourlySalary)
        {
            this.HourlySalary = hourlySalary;
            return this;
        }

        public EmployeeTestDataBuilder WithMonthlySalary(double monthlySalary)
        {
            this.MonthlySalary = monthlySalary;
            return this;
        }

        public Employee Builder()
        {
            return new Employee
            {
                Id = this.Id,
                Name = this.Name,
                ContractTypeName = this.ContractTypeName,
                RoleId = this.RoleId,
                RoleName = this.RoleName,
                RoleDescription = this.RoleDescription,
                HourlySalary = this.HourlySalary,
                MonthlySalary = this.MonthlySalary
            };
        }
    }
}
