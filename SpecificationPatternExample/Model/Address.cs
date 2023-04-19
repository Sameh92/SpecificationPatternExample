namespace SpecificationPatternExample.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public Publisher Publisher { get; set; }
    }
}