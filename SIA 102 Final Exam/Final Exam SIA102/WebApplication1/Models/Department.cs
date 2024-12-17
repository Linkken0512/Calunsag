using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{

    public class Department
    {
        public int DepartmentID { get; set; }

        public string DeptName { get; set; } = "";

        public string DeptDescription { get; set; } = "";

        public string? DeanFirstName { get; set; }

        public string? DeanLastName { get; set; }

        public string? DepartmentDean { get; set; }
    }
}