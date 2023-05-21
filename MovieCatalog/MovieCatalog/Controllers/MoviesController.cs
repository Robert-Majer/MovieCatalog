using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse;

namespace MovieCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ApiControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMediator mediator, ILogger<MovieController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetMovie([FromQuery] GetMovieRequest request)
        {
            _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]  Method: GET (return the last added movie)");
            return this.HandleRequest<GetMovieRequest, GetMovieResponse>(request);
        }

        [HttpGet]
        [Route("Year/{movieYear}")]
        public Task<IActionResult> GetMoviesByYear([FromRoute] int movieYear)
        {
            var request = new GetMoviesByYearRequest()
            {
                MovieYear = movieYear
            };
            _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]  Method: GET/Year, Year: {request.MovieYear}");
            return this.HandleRequest<GetMoviesByYearRequest, GetMoviesByYearResponse>(request);
        }

        [HttpGet]
        [Route("Genre/{movieGenre}")]
        public Task<IActionResult> GetMoviesByGenre([FromRoute] string movieGenre)
        {
            var request = new GetMoviesByGenreRequest()
            {
                MovieGenre = movieGenre
            };
            _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]  Method: GET/Genre, Genre: {request.MovieGenre}");
            return this.HandleRequest<GetMoviesByGenreRequest, GetMoviesByGenreResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddMovie([FromBody] AddMovieRequest request)
        {
            _logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]  Method: POST, Title: {request.Title}, Year: {request.Year}, Genre: {request.Genre}");
            return this.HandleRequest<AddMovieRequest, AddMovieResponse>(request);
        }
    }
}
