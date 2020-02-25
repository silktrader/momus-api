using System.Collections.Generic;
using Momus.Models;

namespace Momus.Services
{
  public interface ILiteDbBookService
  {
    BookDto GetOne(string shortUrl);
    IEnumerable<BookDetailsDto> GetAll();
    IEnumerable<BookDetailsDto> GetLatest(int number);

    IEnumerable<BookDetailsDto> GetReadYear(int year);
    IEnumerable<BookDetailsDto> GetUnknownReadYear();

    int Add(BookDto dto);
    bool Update(BookDto dto);
    bool Remove(int id);

    IEnumerable<int?> GetFinishedYears();
  }
}