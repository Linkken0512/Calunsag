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
        public void EditStudent(Student updatedStudent)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Code == updatedStudent.Code);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Course = updatedStudent.Course;
            }
            else
            {
                throw new ArgumentException("Student not found", nameof(updatedStudent));
            }
        }
    }
}
