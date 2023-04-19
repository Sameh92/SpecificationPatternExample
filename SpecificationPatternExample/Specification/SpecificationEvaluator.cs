using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SpecificationPatternExample.Specification
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery( IQueryable<T> query, ISpecification<T> spec)
        {
            //var query = Ourquery;
            if(spec.Criteria!=null)
            {
                query = query.Where(spec.Criteria);
            }
            query = spec.OurInclues.Aggregate(query, (current, include) => current.Include(include));
            query=spec.OurIncludeStrings.Aggregate(query, (current, include) => current.Include(include));
            if(spec.OurOrderBy!=null)
            {
                query= query.OrderBy(spec.OurOrderBy);
            }
            if (spec.OurOrderByDes != null)
            {
                query= query.OrderByDescending(spec.OurGroupBy);
            }
            if (spec.OurGroupBy != null)
            {
                query = query.GroupBy(spec.OurGroupBy).SelectMany(x=>x);
            }
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            return query;
        }
    }
}
