using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Momus.Services;

namespace Momus.Controllers {
  [ApiController]
  [Route ("api/[controller]")]
  public class BooksController : ControllerBase {

    private readonly ILogger<BooksController> _logger;
    private readonly ILiteDbBookService _bookService;

    public BooksController (ILogger<BooksController> logger, ILiteDbBookService bookService) {
      _logger = logger;
      _bookService = bookService;
    }

    // [HttpGet]
    // public IEnumerable<Book> Get () {
    //   return _bookService.GetAll ();
    // }

    [HttpGet ("{shortUrl}")]
    public ActionResult<Book> GetOne(string shortUrl) {
      return Ok(_bookService.GetOne(shortUrl));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book) {
      if (_bookService.Update(book))
       return NoContent();
      return NotFound();
    }

    [HttpGet("year/{year}")]
    public ActionResult<Book[]> GetReadYear (int year) {
      return Ok (_bookService.GetReadYear (year));
    }

    [HttpGet("year/unknown")]
    public ActionResult<Book[]> GetUnknownReadYear () {
      return Ok (_bookService.GetUnknownReadYear ());
    }

    [HttpPost]
    public ActionResult<Book> Add (Book book) {
      var id = _bookService.Add (book);
      if (id != default)
        // return CreatedAtAction(nameof(GetOne), _bookService.GetOne(id));
        return Ok ();
      else
        return BadRequest ();
    }
  }
}