using SpecificationPatternExample.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpecificationPatternExample.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IReadOnlyList<T>> OurListAsyncWithSpec(ISpecification<T> spec);
    }
}
