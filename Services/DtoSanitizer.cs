using Momus.Models;

namespace Momus.Services
{
  public class DtoSanitizer : IDtoSanitizer
  {
    public BookDto Sanitize(BookDto book)
    {
      // ensure all tags are lowercase
      for (var i = 0; i < book.Details.Tags.Length; i++)
        book.Details.Tags[i] = book.Details.Tags[i].ToLower();

      return book;
    }
  }
}