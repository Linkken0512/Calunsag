using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CalunsagWebAssemblyIPT102CRUD.Models;

namespace CalunsagWebAssemblyIPT102CRUD.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddStudentAsync(Student student)
        {
            // Assuming you have an API endpoint to add a student
            await _httpClient.PostAsJsonAsync("api/students", student);
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Student>>("api/students");
            }
            catch (HttpRequestException ex)
            {
                // Handle the exception (e.g., log it, return an empty list, etc.)
                Console.WriteLine($"Error fetching students: {ex.Message}");
                return new List<Student>(); // Return an empty list or handle the error as needed
            }
        }

        // Implement other CRUD methods (Update, Delete) similarly
    }
}
