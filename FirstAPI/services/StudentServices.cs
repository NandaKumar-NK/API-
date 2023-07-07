using FirstAPI.Models;
using FirstAPI.Services.StudentService;
using Microsoft.EntityFrameworkCore;
using WebAPIwithEFCodeFirst.Data;

namespace FirstAPI.Services.StudentService
{
    public class StudentService : IStudentService
    {
        public StudentDataContext _studentDataContext;
        public StudentService(StudentDataContext studentDataContext)
        {
            _studentDataContext = studentDataContext;
        }

        public async Task<List<Student>> GetAllStudentDetails()
        {
            var students = await _studentDataContext.Students.ToListAsync();
            return students;
        }

        public async Task<Student?> GetAllStudentDetailById(int id)
        {
            //var srudent = studentsList.Find(s=>s.StudID==id)
            var student = await _studentDataContext.Students.FindAsync(id);

            if (student is null)
            {
                return null;
            }
            return student;
        }

        public List<Student> AddStudentDetail(Student stud)
        {
            studentsList.Add(stud);
            return studentsList;
        }

        public List<Student>? UpdateStudentDetailById(int id, Student stud)
        {
            var student = studentsList.Find(s => s.StudID == id);
            if (student is null)
            {
                return null;
            }
            student.StudName = stud.StudName;
            student.City = stud.City;
            student.Pin = stud.Pin;

            return studentsList;
        }

        public List<Student>? DeleteStudentDetailById(int id)
        {
            var student = studentsList.Find(s => s.StudID == id);
            if (student is null)
            {
                return null;
            }
            studentsList.Remove(student);
            return studentsList;
        }
    }
}