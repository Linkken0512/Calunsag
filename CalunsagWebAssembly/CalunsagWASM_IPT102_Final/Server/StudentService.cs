using CalunsagWASM_IPT102_Final.Shared;

namespace CalunsagWASM_IPT102_Final.Server
{
    public class StudentService
    {
        private List<Student> _students;
        public StudentService()
        {
            _students = new List<Student>();
        }
        public List<Student> GetStudent()
        {
            return _students;
        }
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
        public void DeleteStudent(string code)
        {
            _students.RemoveAll(x => x.Code == code);
        }
    }
}
