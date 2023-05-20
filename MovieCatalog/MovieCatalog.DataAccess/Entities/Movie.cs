using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess.Entities
{
    public class Movie : EntityBase
    {
        public string? Title { get; set; }
        public int Year { get; set; }
        public string? Genre { get; set; }
    }
}
