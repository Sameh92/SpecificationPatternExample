namespace SpecificationPatternExample.Specification
{
    public class TestInterface : ITestInterface
    {
        public string Name { get; set; } = " HI Wolrd From Sameh";
        public TestInterface()
        {

        }
           
        public void GetInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}
