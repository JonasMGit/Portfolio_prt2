using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    // URL address
    [Route("api/[controller]")]

    // API attribute
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Instance of DataService
        DataService _dataService;

        public UsersController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult Test()
        {
            return Ok("test");
        }

        /*  // GET api/users -- READ All       
          [HttpGet]
          public List<User> GetUsers()
          {
              List<User> users = _dataService.GetUsers();
              return users;
          }

          // GET api/users/5 -- READ By Id        
          [HttpGet("{id}")]
          public ActionResult<User> GetUserById(int id)
          {
              if (id < 1) return BadRequest("Id must be greater then 0");

              var user = _dataService.GetUser(id);

              return user;
          }*/


          // POST api/users -- CREATE JSON
          [HttpPost]
          public ActionResult<User> Create(string name, string password)
          {
              if (string.IsNullOrEmpty(name))
              {
                  return BadRequest("Username is Required for Creating user");
              }

              if (string.IsNullOrEmpty(password))
              {
                  return BadRequest("Password is Required for Creating user");
              }
              return _dataService.createUser(name, password);
          }

          // PUT api/users/5 -- Update
          /*[HttpPut("{id}")]
          public ActionResult<User> Update (int userId, string newName, string newPassword)
          {
              if (User.Id < 1 || User.Id != userId)
              {
                  return BadRequest("Parameter Id and user ID must be the same");
              }

              return Ok(_dataService.UpdateUser(userId, newName, newPassword));
          }

          // DELETE api/users/5
          [HttpDelete("{id}")]
          public ActionResult<User> Delete(int id)
          {
              var user = _dataService.DeleteUser(id);

              if (user == null)
              {
                  return StatusCode(404, "Did not find user with ID " + id);
              }

              return Ok($"user with Id: {id} is Deleted");
          }*/

    }
}
