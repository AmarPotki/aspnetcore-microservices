using Catalog.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data;

public interface ICatalogContext
{
    IMongoCollection<Product> ProductCollection { get; }
}
public class CatalogContext : ICatalogContext
{
    public CatalogContext(IOptions<DatabaseSettingOption> databaseSetting)
    {
        MongoClient client = new(databaseSetting.Value.ConnectionString);
        var database = client.GetDatabase(databaseSetting.Value.DatabaseName);
        ProductCollection = database.GetCollection<Product>(databaseSetting.Value.CollectionName);
       
    }


    public IMongoCollection<Product> ProductCollection { get; }
}