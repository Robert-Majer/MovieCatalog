using Microsoft.EntityFrameworkCore;
using MovieCatalog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess
{
    public class MovieCatalogStorageContext : DbContext
    {
        public MovieCatalogStorageContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

    }
}
