using System.Collections.Generic;

namespace Momus.Services {
  public interface ILiteDbBookService {
    IEnumerable<Book> GetAll ();
    Book GetOne (string shortUrl);

    IEnumerable<Book> GetReadYear (int year);
    IEnumerable<Book> GetUnknownReadYear();
    
    int Add (Book book);
    bool Update(Book book);
    bool Remove (int id);

    IEnumerable<int?> GetFinishedYears();
  }
}