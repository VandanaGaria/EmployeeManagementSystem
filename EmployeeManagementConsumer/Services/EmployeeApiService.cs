using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using employeeManagementAPP.Models;


namespace EmployeeManagementMvc.Services
{
    public class EmployeeApiService
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employees");
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/employees", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/employees/{employee.Id}", employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/employees/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
