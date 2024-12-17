using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "admin")]
    public class DepartmentModel : PageModel
    {
        private readonly string _connectionString;

        public List<Department> Departments { get; set; } = new List<Department>();
        public List<ApplicationUser> Users { get; set; } = new
List<ApplicationUser>();
        public string DepartmentDeanId { get; set; }

        [BindProperty]
        public string DeptName { get; set; }
        [BindProperty]
        public string DeptDescription { get; set; }
        [BindProperty]
        public string DepartmentDean { get; set; }
        [BindProperty]
        public int DepartmentID { get; set; }

        public DepartmentModel(IConfiguration configuration)
        {
            _connectionString =
configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("Connection string 'DefaultConnection' not found."); 
        }

        public async Task OnGetAsync()
        {
            await LoadDepartmentsAsync();
            await LoadUsersAsync();
        }

        private async Task LoadDepartmentsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = @"SELECT  
                            department.DepartmentID,  
                            department.DeptName,  
                            department.DeptDescription,  
                            AspNetUsers.FirstName,  
                            AspNetUsers.LastName, 
                            department.DepartmentDean 
                        FROM  
                            department 
                        LEFT JOIN  
                            AspNetUsers ON department.DepartmentDean = 
AspNetUsers.Id";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            Departments.Clear();
            while (await reader.ReadAsync())
            {
                Departments.Add(new Department
                {
                    DepartmentID = reader.GetInt32(0),
                    DeptName = reader.GetString(1),
                    DeptDescription = reader.GetString(2),
                    DeanFirstName = reader.IsDBNull(3) ? "Null" :
reader.GetString(3),
                    DeanLastName = reader.IsDBNull(4) ? "Null" :
reader.GetString(4),
                    DepartmentDean = reader.IsDBNull(5) ? null : reader.GetString(5)
                });
            }
        }

        private async Task LoadUsersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var query = "SELECT Id, FirstName, LastName FROM AspNetUsers";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            Users.Clear();
            while (await reader.ReadAsync())
            {
                Users.Add(new ApplicationUser
                {
                    Id = reader.GetString(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2)
                });
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (DepartmentID == 0)
            {
                await AddDepartmentAsync();
            }
            else
            {
                await EditDepartmentAsync();
            }

            return RedirectToPage();
        }

        private async Task AddDepartmentAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = @"INSERT INTO department (DeptName, DeptDescription, 
DepartmentDean) 
                          VALUES (@DeptName, @DeptDescription, @DepartmentDean)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DeptName", DeptName);
            command.Parameters.AddWithValue("@DeptDescription", DeptDescription);
            command.Parameters.AddWithValue("@DepartmentDean", DepartmentDean);
            await command.ExecuteNonQueryAsync();
        }

        private async Task EditDepartmentAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = @"UPDATE department 
                          SET DeptName = @DeptName, DeptDescription = 
@DeptDescription, DepartmentDean = @DepartmentDean 
                          WHERE DepartmentID = @DepartmentID";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DeptName", DeptName);
            command.Parameters.AddWithValue("@DeptDescription", DeptDescription);
            command.Parameters.AddWithValue("@DepartmentDean", DepartmentDean);
            command.Parameters.AddWithValue("@DepartmentID", DepartmentID);

            await command.ExecuteNonQueryAsync();
        }
    }
}