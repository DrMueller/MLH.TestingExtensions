namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.Models
{
    public class Address
    {
        public string[] Streets { get; }

        public Address(params string[] streets)
        {
            Streets = streets;
        }
    }
}