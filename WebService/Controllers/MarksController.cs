using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("api/mark")]
    [ApiController]
    public class MarksController : Controller
    {
        private readonly IDataService _dataService;
        public MarksController(DataService dataService)
        {
            _dataService = dataService;
        }


        [HttpPost]
        public IActionResult PostMarks([FromBody]Mark mark)
        {

            _dataService.CreateMarking(mark.Id, mark.CreationDate, mark.PostId, mark.UserId);

            return Created($"api/mark/{mark}", mark);

        }


        [HttpDelete]
        public IActionResult DeleteMarks(int id, DateTime creationdate, int postid, int userid)
        {
            var del = _dataService.DeleteMarking(id, creationdate,postid, userid);

            if (del==false) return NotFound();
            return Ok(del);
        }
            
           
          
    }

    


}