using Microsoft.AspNetCore.Mvc;
using net01_API.DataModels;
using net01_API.Service;
using System.Collections.Generic;

namespace net01_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Get užklausa neturi body
        // URI - nuo .com.
        // [FromRoute]

        private readonly IReg _registry;

        public UserController(IReg regList)
        {
            _registry = regList;
        }


        [HttpPost("AddUser")]
        public IEnumerable<User> AddUser([FromBody] User user)
        {
            return _registry.RegUser(user);
        }


        [HttpGet("RenderUsers")]
        public IEnumerable<User> RenderUsers()
        {
            return _registry.RenderUsers();
        }

        //[HttpPut("UpdateUser")]
        //public IEnumerable<User> UpdateUser([FromBody] User user)
        //{
        //    var userToUpdate = _Users.First(x => x.Name == user.Name);
        //    userToUpdate.Name = user.Name;
        //    userToUpdate.LastName = user.LastName;
        //    userToUpdate.Email = user.Email;
        //    return (IEnumerable<User>)user;
        //}

    }
}
