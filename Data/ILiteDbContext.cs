using LiteDB;

namespace Momus.LiteDb
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}