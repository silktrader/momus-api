using System.Collections.Generic;
using Momus.Models;

namespace Momus.Services
{
  public interface ILiteDbBookService
  {
    IEnumerable<BookDetailsDto> GetAll();
    BookDto GetOne(string shortUrl);

    IEnumerable<BookDetailsDto> GetReadYear(int year);
    IEnumerable<BookDetailsDto> GetUnknownReadYear();

    int Add(BookDto dto);
    bool Update(BookDto dto);
    bool Remove(int id);

    IEnumerable<int?> GetFinishedYears();
  }
}