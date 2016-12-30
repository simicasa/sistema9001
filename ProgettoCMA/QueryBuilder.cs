using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    class QueryBuilder<T>
    {
        private DbSet dbSet = null;
        private IEnumerable<T> res = null;

        private QueryBuilder()
        {

        }
        public static QueryBuilder<T> from(DbSet dbSet)
        {
            QueryBuilder<T> qb = new QueryBuilder<T>();
            qb.dbSet = dbSet;
            qb.res = qb.dbSet.OfType<T>();
            return qb;
        }
        //priva
        public IEnumerable<T> query()
        {
            return this.res;
        }
        public QueryBuilder<T> where()
        {
            return this;
        }
    }
}
