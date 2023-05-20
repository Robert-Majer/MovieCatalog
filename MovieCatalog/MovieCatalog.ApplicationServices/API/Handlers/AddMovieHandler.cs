using AutoMapper;
using MediatR;
using MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse;
using MovieCatalog.DataAccess.CQRS;
using MovieCatalog.DataAccess.CQRS.Commands.MoviesCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationServices.API.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieRequest, AddMovieResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddMovieHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddMovieResponse> Handle(AddMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = this.mapper.Map<DataAccess.Entities.Movie>(request);
            var command = new AddMovieCommand() { Parameter = movie };
            var movieFromDb = await this.commandExecutor.Execute(command);
            return new AddMovieResponse()
            {
                Data = this.mapper.Map<Domain.Models.Movie>(movieFromDb)
            };
        }
    }
}
