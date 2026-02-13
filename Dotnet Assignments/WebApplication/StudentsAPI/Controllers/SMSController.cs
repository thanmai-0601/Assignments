using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Models;

namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            //In-memory data store (static List)
            new Student{ Id=101,Name="Thanmai",Marks=99.5m},
            new Student{ Id=102,Name="Pranay",Marks=95}
        };

        //GET: api/SMS
        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(students); //200
        }

        //GETById: api/SMS/{id}
        [HttpGet("{id}")]
        public IActionResult GetStudentsById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound("Student with this Id is not found");  //404
            }

            return Ok(student); //200
        }

        //POST: api/SMS
        [HttpPost]
        public IActionResult Post(Student student)
        {
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);

            return CreatedAtAction(nameof(GetStudentsById), new { id = student.Id }, student);
        }

        //PUT: api/SMS/{id}
        [HttpPut("{id}")]

        public IActionResult Update(int id, Student UpdateStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound("Student with this Id is not found");  //404

            }
            student.Name = UpdateStudent.Name;
            student.Marks = UpdateStudent.Marks;

            return NoContent(); //204

        }

        //DELETE: api/SMS/{id}
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var student=students.FirstOrDefault(s => s.Id == id);
            if(student == null)
            {
                return NotFound("Student with this Id is not found"); //404
            }

            students.Remove(student);
            return NoContent();  //204
        }
    }
}
