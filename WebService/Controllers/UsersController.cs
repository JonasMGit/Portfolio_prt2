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
    [Route("api/users")]

    // API attribute
    [ApiController]
    public class UsersController : Controller
    {
        // Instance of DataService
        DataService _dataService;

        public UsersController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)

        {
            _dataService.createUser(user.UserName, user.Password);
            return Created($"api/users/{user}", user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
           var update =  _dataService.UpdateUser(id, user.UserName, user.Password);
            if (update == false) return NotFound();
            return Ok(update);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var delete = _dataService.DeleteUser(id);
            if (delete == false) return NotFound();
            return Ok(delete);

        }

    }
}
