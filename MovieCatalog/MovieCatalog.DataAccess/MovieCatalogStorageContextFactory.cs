using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess
{
    public class MovieCatalogStorageContextFactory : IDesignTimeDbContextFactory<MovieCatalogStorageContext>
    {
        public MovieCatalogStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieCatalogStorageContext>();
            optionsBuilder.UseInMemoryDatabase("MovieCatalogDb");
            return new MovieCatalogStorageContext(optionsBuilder.Options);
        }
    }
}
