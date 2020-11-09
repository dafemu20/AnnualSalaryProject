using BusinessLogic.Ports;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Adapters
{
    public class Employee : IEmployee
    {
        private const string URL_EMPLOYEES = "http://masglobaltestapi.azurewebsites.net/api/Employees";
        private readonly IHttpClientFactory _HttpClientFactory;

        public Employee(IHttpClientFactory HttpClientFactory)
        {
            this._HttpClientFactory = HttpClientFactory;
        }

        public async Task<List<BusinessLogic.Dto.Employee>> GetEmployees()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL_EMPLOYEES);
            var client = _HttpClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var employessString = await response.Content.ReadAsStringAsync();
            IEnumerable<BusinessLogic.Dto.Employee> employees = JsonConvert.DeserializeObject<IEnumerable<BusinessLogic.Dto.Employee>>(employessString);
            return employees.ToList();
        }
    }
}
