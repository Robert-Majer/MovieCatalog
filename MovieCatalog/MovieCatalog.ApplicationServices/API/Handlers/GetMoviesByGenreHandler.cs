using AutoMapper;
using MediatR;
using MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse;
using MovieCatalog.ApplicationServices.API.ErrorHandling;
using MovieCatalog.DataAccess.CQRS.Queries.MoviesQueries;
using MovieCatalog.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationServices.API.Handlers
{
    public class GetMoviesByGenreHandler : IRequestHandler<GetMoviesByGenreRequest, GetMoviesByGenreResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetMoviesByGenreHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetMoviesByGenreResponse> Handle(GetMoviesByGenreRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMoviesByGenreQuery()
            {
                Genre = request.MovieGenre
            };

            var movies = await this.queryExecutor.Excecute(query);
            if (movies == null)
            {
                return new GetMoviesByGenreResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedMovies = this.mapper.Map<List<Domain.Models.Movie>>(movies);
            var response = new GetMoviesByGenreResponse()
            {
                Data = mappedMovies
            };
            return response;
        }
    }
}
