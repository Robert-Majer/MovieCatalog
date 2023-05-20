using MovieCatalog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess.CQRS.Commands.MoviesCommands
{
    public class AddMovieCommand : CommandBase<Movie, Movie>
    {
        public override async Task<Movie> Execute(MovieCatalogStorageContext context)
        {
            await context.Movies.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
