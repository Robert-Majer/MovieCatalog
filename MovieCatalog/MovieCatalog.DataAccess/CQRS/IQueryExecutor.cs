using MovieCatalog.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Excecute<TResult>(QueryBase<TResult> query);
    }
}
