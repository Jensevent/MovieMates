using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieMates_Backend.Containers;
using MovieMates_Backend.DAL;
using MovieMates_Backend.DAL.Db;

namespace MovieMates_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        //private readonly ILogger<GenreController> _logger;
        //private readonly IConfiguration config;
        GenreContainer genreContainer;

        public GenreController(NewContext context)
        {
            genreContainer = new GenreContainer(new GenreDAL(context));
        }


        [HttpGet]
        [Route("all")]
        public ActionResult GetGenres()
        {
            return Ok(genreContainer.GetAllGenres());
        }
    }
}
