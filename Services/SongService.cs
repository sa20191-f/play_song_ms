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
    private readonly IMongoCollection<Song> _songs;
    private readonly IGridFSBucket _songsBucket;
    public SongService(IConfiguration config) {
      var client = new MongoClient(config.GetConnectionString("TracksConnection"));
      var database = client.GetDatabase("trackDB");
      _songs = database.GetCollection<Song>("tracks.files");
      _songsBucket = new GridFSBucket(database, new GridFSBucketOptions {
        BucketName = "tracks",
      });
    }

    public List<Song> GetAll() {
      return _songs.Find(song => true).ToList();
    }
    public async Task<MemoryStream> Get(string id) {
      ObjectId idSong = ObjectId.Parse(id);
      var song = new MemoryStream();  
      using (var stream = await _songsBucket.OpenDownloadStreamAsync(idSong)) {
        await stream.CopyToAsync(song);
        await stream.CloseAsync(); 
      }
      song.Position = 0;
      return song;
    }
  }
}