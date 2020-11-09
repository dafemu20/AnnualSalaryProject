using BusinessLogic.Dto;
using BusinessLogic.Exceptions;
using BusinessLogic.Ports;
using BusinessLogic.Services;
using BusinessLogic.Services.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinesLogic.Test
{
    [TestClass]
    public class EmployeeServiceTest
    {

        private ILogger _Logger;
        private IEmployee _Employee;
        private EmployeeService _EmployeeService;

        [TestInitialize]
        public void Initialize()
        {
            _Logger = Substitute.For<ILogger>();
            _Employee = Substitute.For<IEmployee>();  
            _EmployeeService = new EmployeeService(_Logger, _Employee);
        }

        [TestMethod]
        public async Task GetEmployeeByIdAnnualSalaryContractHourly()
        {
            Employee employeeOne = new EmployeeTestDataBuilder().WithId(1).WithContractTypeName("HourlySalaryEmployee").Builder();
            Employee employeeTwo = new EmployeeTestDataBuilder().WithId(2).WithContractTypeName("MonthlySalaryEmployee").Builder();
            _Employee.GetEmployees().Returns(new List<Employee> { employeeOne, employeeTwo});

            Employee employee = await _EmployeeService.GetEmployeeByIdAsync(1).ConfigureAwait(false);

            Assert.AreEqual(86400000, employee.AnnualSalary);
        }

        [TestMethod]
        public async Task GetEmployeeByIdAnnualSalaryContractMonthly()
        {
            Employee employeeOne = new EmployeeTestDataBuilder().WithId(1).WithContractTypeName("HourlySalaryEmployee").Builder();
            Employee employeeTwo = new EmployeeTestDataBuilder().WithId(2).WithContractTypeName("MonthlySalaryEmployee").Builder();
            _Employee.GetEmployees().Returns(new List<Employee> { employeeOne, employeeTwo });

            Employee employee = await _EmployeeService.GetEmployeeByIdAsync(2).ConfigureAwait(false);

            Assert.AreEqual(960000, employee.AnnualSalary);
        }

        [TestMethod]
        [ExpectedException(typeof(EmployeeEmptyException))]
        public async Task GetEmployeeByIdEmptyInformation()
        {
            Employee employeeOne = new EmployeeTestDataBuilder().WithId(1).WithContractTypeName("HourlySalaryEmployee").Builder();
            Employee employeeTwo = new EmployeeTestDataBuilder().WithId(2).WithContractTypeName("MonthlySalaryEmployee").Builder();
            _Employee.GetEmployees().Returns(new List<Employee> { employeeOne, employeeTwo });

            await _EmployeeService.GetEmployeeByIdAsync(3).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task GetAnnualSalaryAllEmployees()
        {
            Employee employeeOne = new EmployeeTestDataBuilder().WithId(1).WithContractTypeName("HourlySalaryEmployee").Builder();
            Employee employeeTwo = new EmployeeTestDataBuilder().WithId(2).WithContractTypeName("MonthlySalaryEmployee").Builder();
            _Employee.GetEmployees().Returns(new List<Employee> { employeeOne, employeeTwo });

            List<Employee> employees = await _EmployeeService.GetAllEmployeesAsync().ConfigureAwait(false);

            Assert.AreEqual(86400000, employees[0].AnnualSalary);
            Assert.AreEqual(960000, employees[1].AnnualSalary);
        }
    }
}
