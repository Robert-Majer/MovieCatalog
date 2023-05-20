using MovieCatalog.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly MovieCatalogStorageContext context;

        public QueryExecutor(MovieCatalogStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Excecute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
