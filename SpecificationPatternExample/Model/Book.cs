namespace SpecificationPatternExample.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int? NumberOfPage { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher {get;set;}
    }
}
