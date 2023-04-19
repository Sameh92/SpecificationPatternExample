using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SpecificationPatternExample.Specification
{
    public class SpecificationBase<T> : ISpecification<T> where T : class
    {
        public SpecificationBase(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> OurInclues { get; } = new List<Expression<Func<T, object>>>();
        public List<string> OurIncludeStrings { get; }=new List<string>();

        public Expression<Func<T, object>> OurOrderBy { get; private set; }

        public Expression<Func<T, object>> OurOrderByDes { get; private set; }

        public Expression<Func<T, object>> OurGroupBy { get; private set; }

        public int Take { get; private set; }

        public int Skip  { get;  set; }
        public bool IsPagingEnabled  { get; private set; }

        protected void AddInculde (Expression<Func<T, object>> IncludeExpression)
        {
            OurInclues.Add(IncludeExpression);
        }
        protected void AddStringInculde(string includeString)
        {
            OurIncludeStrings.Add(includeString);
        }
        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OurOrderBy = orderByExpression;
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OurOrderByDes = orderByDescendingExpression;
        }

        protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            OurGroupBy = groupByExpression;
        }
    }
}
