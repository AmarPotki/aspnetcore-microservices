using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    #pragma warning disable CS8618
    public string Id { get; set; }
    #pragma warning restore CS8618
    [BsonElement("Name")]
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public string? ImageFile { get; set; }
    public decimal Price { get; set; }
}