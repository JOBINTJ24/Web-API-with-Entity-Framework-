﻿using CRUD_CORE__WEB_API.Models;
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
        public List<User> GetUsers()
        {
            return UserContest.Users.ToList();
        }
        [HttpGet]
        [Route("GetusersById")]
        public User GetUsersId(int id)
        {
            return UserContest.Users.Where(x=>x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("Adduser")]
        public string Adduser(User user)
        {
            string response =string.Empty;
            UserContest.Users.Add(user);
            UserContest.SaveChanges();
            return "Add user";
        }

        [HttpDelete]
        [Route("Deleters")]
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
    }
}
