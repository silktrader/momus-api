using Momus.Models;

namespace Momus.Services
{
  public class DtoMapper : IDtoMapper
  {
    public BookDetailsDto MapDetails(Book book)
    {
      return new BookDetailsDto
      {
        Id = book.Id,
        Isbn = book.Isbn,
        Author = book.Author,
        Title = book.Title,
        Url = book.Url,
        Words = book.Words,
        Language = book.Language,
        Cover = book.Cover,

        Published = book.Published,
        Started = book.Started,
        Finished = book.Finished,
        Reviewed = book.Reviewed,

        Rating = book.Rating,
        Hours = book.Hours
      };
    }

    public BookReviewDto MapReview(Book book)
    {
      return new BookReviewDto
      {
        Contents = book.ReviewHtml
      };
    }

    public BookDto MapBook(Book book)
    {
      return new BookDto
      {
        Details = MapDetails(book),
        Review = MapReview(book)
      };
    }

    public Book MapBookDto(BookDto dto)
    {
      return new Book
      {
        Id = dto.Details.Id,
        Isbn = dto.Details.Isbn,
        Author = dto.Details.Author,
        Title = dto.Details.Title,
        Url = dto.Details.Url,
        Words = dto.Details.Words,
        Language = dto.Details.Language,
        Cover = dto.Details.Cover,

        Published = dto.Details.Published,
        Started = dto.Details.Started,
        Finished = dto.Details.Finished,
        Reviewed = dto.Details.Reviewed,

        Rating = dto.Details.Rating,
        Hours = dto.Details.Hours,

        ReviewHtml = dto.Review.Contents
      };
    }
  }
}