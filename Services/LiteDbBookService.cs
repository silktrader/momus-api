using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Momus.LiteDb;

namespace Momus.Services {
  public class LiteDbBookService : ILiteDbBookService {
    private LiteDatabase liteDb;
    private ILiteCollection<Book> books => liteDb.GetCollection<Book> ("Books"); // tk export this to options, like database string

    public LiteDbBookService (ILiteDbContext context) {

      liteDb = context.Database;
    }

    public IEnumerable<Book> GetAll () {
      return books.FindAll ();
    }

    public IEnumerable<Book> GetReadYear (int year) {
        return books.Find(book => book.Finished.Value.Year == year);
    }

    public IEnumerable<Book> GetUnknownReadYear() {
      return books.Find(book => book.Finished == null);
    }

    public Book GetOne (string shortUrl) {
      return books.FindOne(item => item.Url == shortUrl);
    }

    public int Add (Book book) {
      return books.Insert (book);
    }

    public bool Update(Book book) {
      return books.Update(book);
    }

    public bool Remove (int id) {
      return books.Delete (id);
    }

    // Unordered list of years when books were read, including `null`
    public IEnumerable<int?> GetFinishedYears() {
      return books.FindAll().Select(book => book.Finished?.Year).Distinct();
    }

  }
}