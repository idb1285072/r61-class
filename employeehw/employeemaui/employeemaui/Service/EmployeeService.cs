using employeemaui.Models;
using employeemaui.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace employeemaui.Service
{
    public class EmployeeService
    {

        private const string BASE_URL = "https://localhost:7022/api/Employees/";
        private HttpClient _http;
        protected HttpClient HttpClientInstance => _http ??= new HttpClient();


        public EmployeeService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var url = BASE_URL + "Getemployees";
            //var data = await _http.GetFromJsonAsync<List<Employee>>(url);
            //return data ?? new List<Employee>();
            var data= await HttpClientInstance.GetFromJsonAsync<List<Employee>>(url);
            return data;
        }

        public async Task<EmployeeVM> GetEmployeeByIdAsync(int id)
        {
            var url = $"{BASE_URL}{id}";
            return await _http.GetFromJsonAsync<EmployeeVM>(url);
        }

        public async Task<HttpResponseMessage> CreateEmployeeAsync(EmployeeVM employee, IBrowserFile pictureFile = null)
        {
            var formData = CreateFormData(employee, pictureFile);
            return await _http.PostAsync(BASE_URL, formData);
        }

        public async Task<HttpResponseMessage> UpdateEmployeeAsync(EmployeeVM employee, IBrowserFile pictureFile = null)
        {
            var formData = CreateFormData(employee, pictureFile);
            return await _http.PutAsync(BASE_URL, formData);
        }

        public async Task<HttpResponseMessage> DeleteEmployeeAsync(int id)
        {
            var url = $"{BASE_URL}{id}";
            return await _http.DeleteAsync(url);
        }

        private MultipartFormDataContent CreateFormData(EmployeeVM employee, IBrowserFile pictureFile)
        {
            var formData = new MultipartFormDataContent();

            var employeeJson = JsonSerializer.Serialize(employee);
            var jsonContent = new StringContent(employeeJson, Encoding.UTF8, "application/json");
            formData.Add(jsonContent, "EmployeeInfo");

            if (pictureFile != null)
            {
                var fileStream = pictureFile.OpenReadStream(maxAllowedSize: 1024 * 1024 * 15); // 15MB max
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(pictureFile.ContentType);
                formData.Add(fileContent, "PictureFile", pictureFile.Name);
            }

            return formData;
        }
    }
}
