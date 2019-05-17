using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace play_song_ms.Controllers {

  [Route("api/[controller]")]
  [ApiController]
  public class SongsController : ControllerBase {

    // GET api/songs/{id}
    [HttpGet("{id}")]
    public ActionResult<string> Get() {
      return "success";
    }
  }
}
