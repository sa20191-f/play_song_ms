using Microsoft.AspNetCore.Mvc;

namespace play_song_ms.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase {

    // GET api/test/
    [HttpGet]
    public ActionResult<string> Get() {
      return "It works";
    }
  }
}
