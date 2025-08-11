using Microsoft.EntityFrameworkCore;
using StudentAPICrud.Data;

namespace StudentAPICrud.Repoitory
{
    public class StudentRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public async Task<List<Student>> GetAllStudent()
        {
            return await _studentDbContext.Student.ToListAsync(); 
        }
        public async Task SaveStudent(Student student)
        {
            await _studentDbContext.AddAsync(student);
            await _studentDbContext.SaveChangesAsync();
        }
        public async Task UpdateSutdent(int id, Student student)
        {
            var stu = await _studentDbContext.Student.FindAsync(id);
            if(stu == null)
            {
                throw new Exception("Student Not Found");
            }
            stu.stname = student.stname;
            stu.course = student.course;
            stu.Email = student.Email;
            stu.Age = student.Age;
            await _studentDbContext.SaveChangesAsync();
        }
        public async Task DeleteStudent(int id)
        {
            var student = await _studentDbContext.Student.FindAsync(id);
            if(student == null)
            {
                throw new Exception("Student Not Found");
            }
            _studentDbContext.Student.Remove(student);
            await _studentDbContext.SaveChangesAsync();
        }

    }
}
