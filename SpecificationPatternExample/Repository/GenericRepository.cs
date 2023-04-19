using Microsoft.EntityFrameworkCore;
using SpecificationPatternExample.Data;
using SpecificationPatternExample.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationPatternExample.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> OurListAsyncWithSpec(ISpecification<T> spec)
        {
            return await ApplaySpecification(spec).ToListAsync();
        }
        private IQueryable<T> ApplaySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);
        }
    }
}
