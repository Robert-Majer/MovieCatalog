using AutoMapper;
using MediatR;
using MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse;
using MovieCatalog.DataAccess.CQRS;
using MovieCatalog.DataAccess.CQRS.Queries.MoviesQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationServices.API.Handlers
{
    public class GetMovieHandler : IRequestHandler<GetMovieRequest, GetMovieResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetMovieHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetMovieResponse> Handle(GetMovieRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMovieQuery();
            var movie = await queryExecutor.Excecute(query);
            var mappedProduct = mapper.Map<Domain.Models.Movie>(movie);
            var response = new GetMovieResponse()
            {
                Data = mappedProduct
            };
            return response;
        }
    }
}
