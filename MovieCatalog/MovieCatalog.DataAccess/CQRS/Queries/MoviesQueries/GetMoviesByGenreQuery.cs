using Microsoft.EntityFrameworkCore;
using MovieCatalog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess.CQRS.Queries.MoviesQueries
{
    public class GetMoviesByGenreQuery : QueryBase<List<Movie>>
    {
        public string Genre { get; set; }

        public override async Task<List<Movie>> Execute(MovieCatalogStorageContext context)
        {
            var movies = await context.Movies.Where(x => x.Genre == this.Genre).ToListAsync();

            if(movies.Count > 0 )
            {
                return movies;
            }

            return null;
        }
    }
}
