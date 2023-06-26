using System;
using System.Diagnostics;
using ApiExample.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        MemoryDbContext db;

        public StudentController(MemoryDbContext context)
        {
            db = context;
        }



        [HttpGet("getstudent")]
        public async Task<IActionResult> Get()
        {

           var res =  db.Students.ToList();
            return Ok(res);
        }

        [HttpGet("getteacher")]
        public async Task<IActionResult> GetTeach()
        {

            var res = db.Teachers.ToList();
            return Ok(res);
        }

        [HttpPost(Name = "addstudent")]
        public async Task<IActionResult> Add([FromBody] RequestEx req)
        {

            var trans = await db.Database.BeginTransactionAsync();
            try
            {
                await db.Students.AddAsync(req.St);
                await db.SaveChangesAsync();

                await db.Teachers.AddAsync(req.Th);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
            

            var res = db.Students.ToList();
            return Ok(res);
        }

        [HttpGet("AsaveChanges")]
        public async Task<IActionResult> aSaveChanges()
        {

            var res = await db.SaveChangesAsync();
            return Ok(res);
        }
    }
    public class RequestEx
    {

        public Student St { get; set; }
        public Teacher Th { get; set; }

    }

}