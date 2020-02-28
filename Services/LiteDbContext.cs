using LiteDB;
using Microsoft.Extensions.Options;
using Momus.Models;

namespace Momus.Services
{
  public class LiteDbContext : ILiteDbContext
  {
    public LiteDatabase Database { get; }

    public LiteDbContext(IOptions<LiteDbOptions> options)
    {
      Database = new LiteDatabase(options.Value.DatabaseLocation);
    }
  }
}