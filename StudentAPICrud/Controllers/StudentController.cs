using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPICrud.Data;
using StudentAPICrud.Repoitory;

namespace StudentAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        /*  private readonly StudentDbContext _studentDbContext;

          public StudentController(StudentDbContext studentDbContext)
          {
              _studentDbContext = studentDbContext;
          }

          [HttpGet]
          [Route("GetStudent")]
          public async Task<IEnumerable<Student>> GetStudents()


          {
              return await _studentDbContext.Student.ToListAsync();
          }

          [HttpPost]
          [Route("AddStudent")]
          public async Task<Student> AddStudent(Student objStudent)
          {
              _studentDbContext.Student.Add(objStudent);
              await _studentDbContext.SaveChangesAsync();
              return objStudent;
          }

          [HttpPatch]
          [Route("UpdateStudent/{id}")]
          public async Task<Student> UpdateStudent(Student objStudent)
          {
              _studentDbContext.Entry(objStudent).State = EntityState.Modified;
              await _studentDbContext.SaveChangesAsync();
              return objStudent;
          }

          [HttpDelete]
          [Route("DeleteStudent/{id}")]
          public bool DeleteStudent(int id)
          {
              bool a = false;
              var student = _studentDbContext.Student.Find(id);
              if (student != null)
              {
                  a = true;
                  _studentDbContext.Entry(student).State = EntityState.Deleted;
                  _studentDbContext.SaveChanges();
              }
              else
              {
                  a = false;
              }
              return a;

          }
  */
        private readonly StudentRepository _studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> StudentList()
        {
            var student = await _studentRepository.GetAllStudent();
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await _studentRepository.SaveStudent(student);
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> uppdateStudent(int id, [FromBody] Student stu)
        {
             await _studentRepository.UpdateSutdent(id,stu);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(id);
            return Ok();

        }

    }
}
