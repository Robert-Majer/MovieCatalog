using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse;

namespace MovieCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ApiControllerBase
    {
        public MovieController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetMovie([FromQuery] GetMovieRequest request)
        {
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
            return this.HandleRequest<GetMoviesByGenreRequest, GetMoviesByGenreResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddMovie([FromBody] AddMovieRequest request)
        {
            return this.HandleRequest<AddMovieRequest, AddMovieResponse>(request);
        }
    }
}
