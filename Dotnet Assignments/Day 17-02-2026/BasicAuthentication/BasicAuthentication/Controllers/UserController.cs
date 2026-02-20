using BasicAuthentication.DTO;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDBContext dbcontext;

        public UserController(UserDBContext context)
        {
            dbcontext = context;
        }
        [HttpPost]
        [Route("Register")]

        public IActionResult Register(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ValidUser=dbcontext.Users.FirstOrDefault(u=>u.Email==user.Email);

            if (ValidUser == null)
            {
                var newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password

                };

                dbcontext.Users.Add(newUser);

                dbcontext.SaveChanges();

                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest("User already exists");
            }


        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var ValidUser = dbcontext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if(ValidUser != null)
            {
                return Ok("Login successful");
            }
            else
            {
                return BadRequest("Invalid Email or Password");
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var user = dbcontext.Users.ToList();
            return Ok(user);
        }
    }
}
