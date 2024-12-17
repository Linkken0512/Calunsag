using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class StudentInfo
    {

        public string StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DeptName { get; set; }
    }
}