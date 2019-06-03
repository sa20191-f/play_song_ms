using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using play_song_ms.Services;
using play_song_ms.Models;
using System.IO;

namespace play_song_ms.Controllers
{

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
    public ActionResult<List<Song_Path>> Get() {
      return _songService.GetAll();
    }
    
    // GET api/songs/{id}
    [HttpGet("{id}")]
    public Song_Path Get(string id) {
      Song_Path path = _songService.Get(id);
      return path;
    }
  }
}
