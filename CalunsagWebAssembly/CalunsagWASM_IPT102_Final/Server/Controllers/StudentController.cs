using CalunsagWASM_IPT102_Final.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalunsagWASM_IPT102_Final.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetStudent")]
        public ActionResult<List<Student>> GetStudent()
        {
            return _studentService.GetStudent();
        }

        [HttpPost]
        [Route("AddStudent")]
        public ActionResult AddStudent([FromBody] Student student)
        {
            _studentService.AddStudent(student);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        public ActionResult DeleteStudent([FromQuery] string code)
        {
            _studentService.DeleteStudent(code);
            return Ok();
        }
        [HttpPut]
        [Route("EditStudent")]
        public ActionResult EditStudent([FromBody] Student student)
        {
            _studentService.EditStudent(student);
            return Ok();
        }
    }
}
