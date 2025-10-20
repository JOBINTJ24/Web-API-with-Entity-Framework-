using CRUD_CORE__WEB_API.Models;
using CRUD_CORE__WEB_API.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CRUD_CORE__WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContest UserContest;
        public UsersController (UserContest UserContest)
        {
            this.UserContest = UserContest;
        }


        [HttpGet]
        [Route("Getusers")]
        public List<User> GetUsers()
        {
            return UserContest.Users.ToList();
        }
        [HttpGet]
        [Authorize]
        [Route("GetusersById")]
        public User GetUsersId(int id)
        {
            return UserContest.Users.Where(x=>x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("Adduser")]
       // [Authorize]
        public IActionResult Adduser([FromBody] User user)
        {
            string response =string.Empty;
            UserContest.Users.Add(user);
            UserContest.SaveChanges();
            return Ok(new { message = "User added" });
        }

        [HttpDelete]
        [Route("Deleters")]
        [Authorize]
        public string Deleteuser(int id)
        {
            User user = UserContest.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null) 
            {
                string response = string.Empty;
                UserContest.Users.Remove(user);
                UserContest.SaveChanges();
                return "Deleted";
            }
            else
            {
                return "Failed to delete";
            }
           
        }
        [HttpPut]
        [Route("update")]
        [Authorize]
        public string Update(User user)
        {
            UserContest.Entry(user).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            UserContest.SaveChanges();
            return "user updated";
        }
        [HttpPost]
        [Route("Login")]
       // [Authorize]
        public IActionResult Login(LoginRequest obj)
        {
            var user = UserContest.Users.SingleOrDefault(m => m.Name == obj.Name && m.Password == obj.Password);
            if (user != null)
            {
                return Ok(new { message = "success" });
            }
            return Unauthorized(new { message = "Invalid username or password" });
        }

    }
}
