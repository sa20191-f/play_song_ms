using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using play_song_ms.Services;
using play_song_ms.Models;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using System.IO;

namespace play_song_ms.Controllers {

  [Route("api/[controller]")]
  [ApiController]
  public class SongsController : ControllerBase {

    private readonly SongService _songService;

    public SongsController(SongService songService)
    {
      _songService = songService;
    }

    // GET api/songs/
    [HttpGet]
    public ActionResult<List<Song>> Get() {
      return _songService.GetAll();
    }

    // GET api/songs/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(string id) {
      var client = new MongoClient("mongodb://localhost:27017");
      var database = client.GetDatabase("trackDB");
      IGridFSBucket bucket = new GridFSBucket(database, new GridFSBucketOptions {
        BucketName = "tracks",
      });
      ObjectId idSong = ObjectId.Parse(id);
      Console.WriteLine(idSong);
      var memory = new MemoryStream();  
      using (var stream = await bucket.OpenDownloadStreamAsync(idSong)) {
        await stream.CopyToAsync(memory);
        await stream.CloseAsync(); 
      }
      memory.Position = 0;
      Console.WriteLine("PASE");
      Console.WriteLine(memory);
      return File(memory, "application/octet-stream","alci.mp3");
    }
  }
}
