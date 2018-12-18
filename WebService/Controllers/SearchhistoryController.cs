using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("api/searchhistory")]
    [ApiController]
    public class SearchhistoryController : Controller
    {
        private readonly IDataService _dataService;
        public SearchhistoryController(DataService dataService)
        {
            _dataService = dataService;
        }


        [HttpGet("{userid}", Name = nameof(GetSearchhistory))]
        public IActionResult GetSearchhistory(int userid, int page = 0, int pageSize = 10)
        {
            var searchh = _dataService.SearchHistories(userid, page, pageSize);

            var total = _dataService.GetNumberOfSearches();
            var pages = Math.Ceiling(total / (double)pageSize);
            var prev = page > 0 ? Url.Link(nameof(GetSearchhistory), new { page = page - 1, pageSize }) : null;
            var next = page < pages - 1 ? Url.Link(nameof(GetSearchhistory), new { page = page + 1, pageSize }) : null;

            var result = new
            {
                total,
                pages,
                prev,
                next,
                searchh
            };
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteSearchhistory([FromBody] SearchHistories searchHistory)
        {
            var Searchh = _dataService.ClearSearch(searchHistory.Search , searchHistory.UserId);
            if (Searchh == false) return NotFound();
            return Ok(Searchh);
        }

        [HttpPost("add")]
        public IActionResult CreateSearch( [FromBody] SearchHistories searchHistories)
        {
            var createSearch = _dataService.SaveSearch(searchHistories.Search, searchHistories.UserId);
            return Created($"api/searchhistory/{createSearch}", createSearch);

        }
    }
}