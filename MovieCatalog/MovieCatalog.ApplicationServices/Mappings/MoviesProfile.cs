using AutoMapper;
using MovieCatalog.ApplicationServices.API.Domain.MoviesRequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ApplicationServices.Mappings
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            this.CreateMap<AddMovieRequest, DataAccess.Entities.Movie>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Year, y => y.MapFrom(z => z.Year))
                .ForMember(x => x.Genre, y => y.MapFrom(z => z.Genre));

            this.CreateMap<MovieCatalog.DataAccess.Entities.Movie, MovieCatalog.ApplicationServices.API.Domain.Models.Movie>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Year, y => y.MapFrom(z => z.Year))
                .ForMember(x => x.Genre, y => y.MapFrom(z => z.Genre)); 
        }
    }
}
