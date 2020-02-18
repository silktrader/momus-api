using LiteDB;
using Microsoft.Extensions.Options;
using Momus.LiteDb;

namespace Momus.Data
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