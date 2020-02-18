using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Momus.Services;

namespace Momus.Controllers
{
     [ApiController]
  [Route ("api/[controller]")]
  public class StatsController : ControllerBase {

      private readonly ILiteDbBookService _bookService;

      public StatsController(ILiteDbBookService bookService)
      {
      _bookService = bookService;
    }

    [HttpGet ("finished-years")]
    public ActionResult<IEnumerable<int?>> GetFinishedYears() {
      return Ok(_bookService.GetFinishedYears());
    }
        
    }
}