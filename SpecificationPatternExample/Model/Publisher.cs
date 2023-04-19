using System.Collections.Generic;

namespace SpecificationPatternExample.Model
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Book> Books { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}