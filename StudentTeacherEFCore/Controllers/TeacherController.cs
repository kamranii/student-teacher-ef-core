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
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _dB;
        public TeacherController(ApplicationDbContext database)
        {
            _dB = database;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _dB.Teachers.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Teacher teacher)
        {
            await _dB.Teachers.AddAsync(teacher);
            await _dB.SaveChangesAsync();
            return Ok(teacher);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _dB.Teachers.FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null)
                return NotFound("Not such a student");
            _dB.Teachers.Remove(teacher);
            await _dB.SaveChangesAsync();
            return Ok();
        }
    }
}

