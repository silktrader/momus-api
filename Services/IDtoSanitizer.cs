using Momus.Models;

namespace Momus.Services
{
  public interface IDtoSanitizer
  {
    BookDto Sanitize(BookDto book);
  }
}