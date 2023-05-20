﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse
{
    public class GetMovieRequest : IRequest<GetMovieResponse>
    {
    }
}
