using FluentValidation;
using MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationServices.API.Validators
{
    public class AddMovieRequestValidator : AbstractValidator<AddMovieRequest>
    {
        public AddMovieRequestValidator()
        {
            this.RuleFor(x => x.Title).Length(2, 50);
            this.RuleFor(x => x.Year).ExclusiveBetween(1800, 2100);
            this.RuleFor(x => x.Genre).Length(2, 30);
        }
    }
}
