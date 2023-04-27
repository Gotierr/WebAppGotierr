using GogoWeb.API.Context;
using GogoWeb.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GogoWeb.API.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppWebContext webContext;

        public UserController(AppWebContext webContext)
        {
            this.webContext = webContext;
        }

        [HttpGet]
        public IEnumerable<User> GetAll() => webContext.Users;

        [HttpGet("{id}")]
        public User GetById(int id) => webContext.Users.
            FirstOrDefault(u => u.Id == id);

        [HttpPost]
        public User CreateUser([FromBody] User user)
        {
            webContext.Users.Add(user);
            webContext.SaveChanges();
            return user;
        }

        [HttpPut("{id}")]
        public void UpdateUser(int id, [FromBody] User user) 
        {
            var userToUpdate = webContext.Users.FirstOrDefault(u => u.Id == id);
            if (userToUpdate != null)
            {
                webContext.Entry<User>(userToUpdate).CurrentValues.SetValues(user);
                webContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            var user = webContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                webContext.Users.Remove(user);
                webContext.SaveChanges();
            }
        }
    }
}
