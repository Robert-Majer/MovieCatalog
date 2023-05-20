using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse
{
    public class GetMoviesByYearRequest : IRequest<GetMoviesByYearResponse>
    {
        public int MovieYear { get; set; }
    }
}
