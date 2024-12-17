using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class StudentModel : PageModel
    {
        private readonly string _connectionString;

        public StudentModel(IConfiguration configuration)
        {
            _connectionString =
configuration.GetConnectionString("DefaultConnection");
        }

        public List<StudentInfo> Students { get; set; } = new List<StudentInfo>();
        public List<Department> Departments { get; set; } = new List<Department>();

        public async Task OnGetAsync()
        {
            await LoadStudentsAsync();
            await LoadDepartmentsAsync();
        }

        public async Task<IActionResult> OnPostAsync(string StudentID, string
LastName, string FirstName, int DepartmentID)
        {

            if (string.IsNullOrEmpty(StudentID) || string.IsNullOrEmpty(LastName) ||
string.IsNullOrEmpty(FirstName) || DepartmentID <= 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid input.");
                await LoadStudentsAsync();
                await LoadDepartmentsAsync();
                return Page();
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @" 
                    UPDATE Student 
                    SET  
                        LastName = @LastName, 
                        FirstName = @FirstName, 
                        DepartmentID = @DepartmentID 
                    WHERE StudentID = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", StudentID);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                    await command.ExecuteNonQueryAsync();
                }
            }

            return RedirectToPage();
        }

        private async Task LoadStudentsAsync()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            bool isAdmin = User.FindFirst(ClaimTypes.Role)?.Value == "admin";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query;

                if (isAdmin)
                {
                    query = @" 
                        SELECT  
                            Student.StudentID,  
                            Student.LastName,  
                            Student.FirstName,  
                            Department.DeptName 
                        FROM  
                            Student 
                        LEFT JOIN  
                            Department ON Student.DepartmentID = 
Department.DepartmentID 
                        Order By 
                            Student.LastName";
                }
                else
                {
                    query = @" 
                        SELECT  
                            Student.StudentID,  
                            Student.LastName,  
                            Student.FirstName,  
                            Department.DeptName 
                        FROM  
                            Student 
                        LEFT JOIN  
                            Department ON Student.DepartmentID = 
Department.DepartmentID 
                        LEFT JOIN  
                            AspNetUsers ON Department.DepartmentDean = 
AspNetUsers.Id 
                        WHERE  
                            AspNetUsers.Id = @UserId 
                        Order By 
                            Student.LastName";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!isAdmin && !string.IsNullOrEmpty(userId))
                    {
                        command.Parameters.Add(new SqlParameter("@UserId", userId));
                    }

                    using (SqlDataReader reader = await
command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Students.Add(new StudentInfo
                            {
                                StudentID = reader["StudentID"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                DeptName = reader["DeptName"].ToString()
                            });
                        }
                    }
                }
            }
        }

        private async Task LoadDepartmentsAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT DepartmentID, DeptName FROM Department";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await
command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Departments.Add(new Department
                            {
                                DepartmentID = (int)reader["DepartmentID"],
                                DeptName = reader["DeptName"].ToString()
                            });
                        }
                    }
                }
            }
        }
    }
}