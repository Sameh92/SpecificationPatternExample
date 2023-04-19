using SpecificationPatternExample.Model;
using SpecificationPatternExample.Specification;

namespace SpecificationPatternExample.Repository
{
    public class BookSpecification: SpecificationBase<Book>
    {
        public BookSpecification(int price):base(x=>price>0)
        {
            AddInculde(x=>x.Publisher);
            AddStringInculde($"{nameof(Book.Publisher)}.{nameof(Publisher.Address)}");
        }
    }
}
