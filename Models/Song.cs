using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace play_song_ms.Models
{
  public class Song
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("length")]
    public int length { get; set; }
    
    [BsonElement("chunkSize")]
    public int chunkSize { get; set; }

    [BsonElement("uploadDate")]
    public BsonDateTime uploadDate { get; set; }

    [BsonElement("filename")]
    public string filename { get; set; }
    
    [BsonElement("md5")]
    public string md5 { get; set; }
  }
}