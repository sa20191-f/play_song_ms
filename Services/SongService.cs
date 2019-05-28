using System.Collections.Generic;
using System.Linq;
using play_song_ms.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;
using System.IO;
using System.Threading.Tasks;

namespace play_song_ms.Services
{
  public class SongService {
    private readonly IMongoCollection<Song_Path> _songs_paths;
    public SongService(IConfiguration config) {
      var client = new MongoClient(config.GetConnectionString("TracksConnection"));
      var database = client.GetDatabase("songs");
      _songs_paths = database.GetCollection<Song_Path>("song_paths");
    }

    public List<Song_Path> GetAll() {
      return _songs_paths.Find(song => true).ToList();
    }
    public string Get(string id) {
      Song_Path song = _songs_paths.Find(song_path => song_path.Id == id).FirstOrDefault();
      return song.path;
    }
  }
}