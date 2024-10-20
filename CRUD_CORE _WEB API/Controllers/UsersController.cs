using CRUD_CORE__WEB_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize]
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
        [Authorize]
        public string Adduser(User user)
        {
            string response =string.Empty;
            UserContest.Users.Add(user);
            UserContest.SaveChanges();
            return "Add user";
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

    }
}
