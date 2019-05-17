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
      MemoryStream song = await _songService.Get(id);
      return File(song, "application/octet-stream","alci.mp3");
    }
  }
}
