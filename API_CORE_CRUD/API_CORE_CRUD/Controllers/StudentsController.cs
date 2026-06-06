using API_CORE_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CORE_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext db;

        public StudentsController(StudentDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var data = await db.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var data = await db.Students.FindAsync(id);
            if(data == null) return NotFound();
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await db.Students.AddAsync(std);
            await db.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id) return BadRequest();
            db.Entry(std).State = EntityState.Modified;
            await db.SaveChangesAsync();    
            return Ok(std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await db.Students.FindAsync(id);
            if (std == null) return NotFound();
            db.Students.Remove(std);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
