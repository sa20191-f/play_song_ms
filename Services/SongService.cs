using System.Collections.Generic;
using System.Linq;
using play_song_ms.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace play_song_ms.Services {
  public class SongService {
    private readonly IMongoCollection<Song> _songs;

    public SongService(IConfiguration config) {
      var client = new MongoClient(config.GetConnectionString("TracksConnection"));
      var database = client.GetDatabase("trackDB");
      _songs = database.GetCollection<Song>("tracks.files");
    }

    public List<Song> GetAll() {
      return _songs.Find(song => true).ToList();
    }
    public Song Get(string id) {
      Song s = _songs.Find<Song>(song => song.Id == id).FirstOrDefault();
      return s;
    }
  }
}