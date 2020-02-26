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
    private readonly IDtoSanitizer _dtoSanitizer;

    public BooksController(ILogger<BooksController> logger, ILiteDbBookService bookService, IDtoSanitizer dtoSanitizer)
    {
      _logger = logger;
      _bookService = bookService;
      _dtoSanitizer = dtoSanitizer;
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
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (_bookService.Update(_dtoSanitizer.Sanitize(book)))
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
      var id = _bookService.Add(_dtoSanitizer.Sanitize(bookDto));
      if (id != default)
        // return CreatedAtAction(nameof(GetOne), _bookService.GetOne(id));
        return Ok();
      else
        return BadRequest();
    }
  }
}