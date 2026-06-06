using Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        public StudentService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7134/")
            };
        }
        public async Task<List<Student>> GetAsync()
        {
            var response = await _httpClient.GetAsync("api/students");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Student>>(json);
            }

            return new List<Student>();
        }

    }
}
