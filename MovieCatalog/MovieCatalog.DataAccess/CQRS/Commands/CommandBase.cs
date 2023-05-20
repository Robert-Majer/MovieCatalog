using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParametr, TResult>
    {
        public TParametr? Parameter { get; set; }

        public abstract Task<TResult> Execute(MovieCatalogStorageContext context);
    }
}
