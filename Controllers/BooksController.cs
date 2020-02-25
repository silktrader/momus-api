using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Momus.Models;
using Momus.Services;

namespace Momus.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {

    private readonly ILogger<BooksController> _logger;
    private readonly ILiteDbBookService _bookService;

    public BooksController(ILogger<BooksController> logger, ILiteDbBookService bookService)
    {
      _logger = logger;
      _bookService = bookService;
    }

    // [HttpGet]
    // public IEnumerable<Book> Get () {
    //   return _bookService.GetAll ();
    // }

    [HttpGet("{shortUrl}")]
    public ActionResult<BookDto> GetOne(string shortUrl)
    {
      return _bookService.GetOne(shortUrl);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, BookDto book)
    {
      if (_bookService.Update(book))
        return NoContent();
      return NotFound();
    }

    [HttpGet("year/{year}")]
    public ActionResult<IEnumerable<BookDetailsDto>> GetReadYear(int year)
    {
      return Ok(_bookService.GetReadYear(year));
    }

    [HttpGet("year/unknown")]
    public ActionResult<BookDto[]> GetUnknownReadYear()
    {
      return Ok(_bookService.GetUnknownReadYear());
    }

    [HttpGet("latest")]
    public ActionResult<IEnumerable<BookDetailsDto>> LatestReviews([FromQuery] int latest)
    {
      return Ok(_bookService.GetLatest(latest));
    }

    [HttpPost]
    public ActionResult Add(BookDto bookDto)
    {
      var id = _bookService.Add(bookDto);
      if (id != default)
        // return CreatedAtAction(nameof(GetOne), _bookService.GetOne(id));
        return Ok();
      else
        return BadRequest();
    }
  }
}