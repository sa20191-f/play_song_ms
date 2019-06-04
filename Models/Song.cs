using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace play_song_ms.Models
{
  public class Song_Path
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("path")]
    public string path { get; set; }
    [BsonElement("__v")]
    public int v { get; set; }
    [BsonElement("song_name")]
    public string song_name { get; set; }
    [BsonElement("artist")]
    public string artist { get; set; }
  }
}