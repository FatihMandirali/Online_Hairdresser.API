using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Online_Hairdresser.MongoData.Entity;

public class RefreshToken
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("UserId")]
    public int UserId { get; set; }
    
    [BsonElement("RefreshTokenContent")]
    public string RefreshTokenContent { get; set; }
    
    [BsonElement("RefreshTokenExpDate")]
    public DateTime RefreshTokenExpDate{ get; set; }
}