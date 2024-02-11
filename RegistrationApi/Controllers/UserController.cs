using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RegistrationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _config;
        public readonly UserContext _context;

        public UserController(IConfiguration config, UserContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("CreateUser")]
        public IActionResult CrateUser(User user)
        {
            user.MemberSince = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Success");
        }
    }
}
