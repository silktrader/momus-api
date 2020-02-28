using LiteDB;

namespace Momus.Services
{
  public interface ILiteDbContext
  {
    LiteDatabase Database { get; }
  }
}