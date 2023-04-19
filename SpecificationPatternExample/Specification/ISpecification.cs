using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SpecificationPatternExample.Specification
{
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> OurInclues { get;  }
        List<string> OurIncludeStrings { get; }
        Expression<Func<T,object>> OurOrderBy { get; }
        Expression<Func<T, object>> OurOrderByDes { get; }
        Expression<Func<T, object>> OurGroupBy { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }


    }
}
