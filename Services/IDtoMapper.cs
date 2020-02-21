using Momus.Models;

namespace Momus.Services
{
  public interface IDtoMapper
  {
    BookDetailsDto MapDetails(Book book);
    BookReviewDto MapReview(Book book);
    BookDto MapBook(Book book);

    Book MapBookDto(BookDto dto);
  }
}