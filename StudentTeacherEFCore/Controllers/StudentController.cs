using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTeacherEFCore.Data;
using StudentTeacherEFCore.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentTeacherEFCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dB;

        public StudentController(ApplicationDbContext database)
        {
            _dB = database;
        }
        // GET: api/values
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            return await _dB.Students.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            await _dB.Students.AddAsync(student);
            await _dB.SaveChangesAsync();
            return Ok(student);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _dB.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
                return NotFound("Not such a student");
            _dB.Students.Remove(student);
            await _dB.SaveChangesAsync();
            return Ok();
        }
    }
}

