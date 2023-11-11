using BlazorFormsValidation.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlazorFormsValidation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly List<string> userNameList = new();

        public StudentController()
        {
            userNameList.Add("ankit");
            userNameList.Add("vaibhav");
            userNameList.Add("priya");
        }

        [HttpPost]
        public IActionResult Post(StudentRegistration registrationData)
        {
            if (userNameList.Contains(registrationData.Username.ToLower()))
            {
                ModelState.AddModelError(nameof(registrationData.Username), "This User Name is not available.");
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(ModelState);
            }
        }
    }
}
