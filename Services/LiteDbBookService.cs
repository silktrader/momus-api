using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Momus.LiteDb;
using Momus.Models;

namespace Momus.Services
{
  public class LiteDbBookService : ILiteDbBookService
  {
    private readonly LiteDatabase liteDb;
    private readonly IDtoMapper mapper;
    private ILiteCollection<Book> books => liteDb.GetCollection<Book>("Books"); // tk export this to options, like database string

    public LiteDbBookService(ILiteDbContext context, IDtoMapper mapper)
    {

      liteDb = context.Database;
      this.mapper = mapper;
    }

    public BookDto GetOne(string shortUrl)
    {
      return mapper.MapBook(books.FindOne(item => item.Url == shortUrl));
    }

    public IEnumerable<BookDetailsDto> GetAll()
    {
      return books.FindAll().Select(book => mapper.MapDetails(book));
    }

    public IEnumerable<BookDetailsDto> GetLatest(int number)
    {
      return books.FindAll().OrderBy(book => book.Reviewed).Take(number).Select(book => mapper.MapDetails(book));
    }

    public IEnumerable<BookDetailsDto> GetReadYear(int year)
    {
      return books.Find(book => book.Finished.Value.Year == year).Select(book => mapper.MapDetails(book));
    }

    public IEnumerable<BookDetailsDto> GetUnknownReadYear()
    {
      return books.Find(book => book.Finished == null).Select(book => mapper.MapDetails(book));
    }

    public int Add(BookDto dto)
    {
      return books.Insert(mapper.MapBookDto(dto));
    }

    public bool Update(BookDto dto)
    {
      return books.Update(mapper.MapBookDto(dto));
    }

    public bool Remove(int id)
    {
      return books.Delete(id);
    }

    // Unordered list of years when books were read, including `null`
    public IEnumerable<int?> GetFinishedYears()
    {
      return books.FindAll().Select(book => book.Finished?.Year).Distinct();
    }

  }
}