namespace Core.Database.MongoDB;

public interface IMongoConfig
{
    public string MongoConnectionString { get; set; }
    public string MongoDatabaseName { get; set; }
}