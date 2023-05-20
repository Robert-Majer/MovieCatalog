using Microsoft.EntityFrameworkCore;
using MovieCatalog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess.CQRS.Queries.MoviesQueries
{
    public class GetMovieQuery : QueryBase<Movie>
    {
        public override async Task<Movie> Execute(MovieCatalogStorageContext context)
        {
            var movie = await context.Movies.LastOrDefaultAsync();
            return movie;
        }
    }
}
