using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Nerves.Data.MongoDB;

public class DataBaseConnector
{
    private readonly MongoClient? mongoClient;

    public string ConnectionString { get; init; }

    public bool Connected { get; } = false;

    public DataBaseConnector(string connectStr)
    {
        ConnectionString = connectStr;

        mongoClient = new(ConnectionString);

        Connected = mongoClient is not null;

        Console.WriteLine($"@Init: {nameof(DataBaseConnector)}, Connected: {Connected}");
    }

    public IMongoCollection<T> GetCollection<T>(string dbName, string colName)
    {
        return mongoClient!.GetDatabase(dbName).GetCollection<T>(colName);
    }

    public IMongoQueryable<T> QueryCollection<T>(string dbName, string colName)
    {
        var collection = GetCollection<T>(dbName, colName);
        return collection.AsQueryable();
    }
}
