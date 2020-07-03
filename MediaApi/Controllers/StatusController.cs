using MediaApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaApi.Controllers
{
    public class StatusController : ControllerBase
    {
        ISystemTime Clock;

        public StatusController(ISystemTime clock)
        {
            Clock = clock;
        }

        // GET /status
        [HttpGet("status")]
        public ActionResult<StatusResponse> GetStatus()
        {
            var response = new StatusResponse
            {
                Message = "Everything works. Here in docker land",
                CreatedAt = Clock.GetCurrent()
            };
            return Ok(response); // this will return a 200.
        }

        // GET /sayhi/Matt
        [HttpGet("sayhi/{name}")]
        public IActionResult SayHi(string name)
        {
            return Ok($"Hello, {name}!");
        }

        // GET /blogs/2020/6/15 (I want the blog posts from 6-15-2020
        // [HttpGet("blogs/{year:int}/month:int}/{day:int}")]
        // public IActionResult Blogs(int year, int month, int day) { ... }

        // GET /employees?department=DEV
        [HttpGet("employees")]
        public IActionResult GetEmployees(string department = "All")
        {
            return Ok($"Getting you the employees in department {department}");
        }

        [HttpPost("employees")]
        public IActionResult HireEmployee([FromBody] HiringRequest employeeToHire)
        {
            // Validation, ect. we'll talk about afternoon.
            return Ok($"hiring {employeeToHire.FirstName} as a {employeeToHire.Department}");
        }
    }

    public class StatusResponse
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class HiringRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal StartingSalary { get; set; }
        public string Department { get; set; }
    }
}
