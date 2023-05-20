using AutoMapper;
using MediatR;
using MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse;
using MovieCatalog.ApplicationServices.API.ErrorHandling;
using MovieCatalog.DataAccess.CQRS;
using MovieCatalog.DataAccess.CQRS.Queries.MoviesQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationServices.API.Handlers
{
    public class GetMoviesByYearHandler : IRequestHandler<GetMoviesByYearRequest, GetMoviesByYearResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetMoviesByYearHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetMoviesByYearResponse> Handle(GetMoviesByYearRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMoviesByYearQuery()
            {
                Year = request.MovieYear
            };

            var movies = await this.queryExecutor.Excecute(query);
            if (movies == null)
            {
                return new GetMoviesByYearResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedMovies = this.mapper.Map<List<Domain.Models.Movie>>(movies);
            var response = new GetMoviesByYearResponse()
            {
                Data = mappedMovies
            };
            return response;
        }
    }
}
