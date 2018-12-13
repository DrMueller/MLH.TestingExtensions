namespace Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses
{
    public class TestingContainerConfiguration
    {
        public bool InitializeAutoMapper { get; }
        public bool LogInitialization { get; }
        public int NamespaceParts { get; }

        public TestingContainerConfiguration(int namespaceParts = 2, bool initializeAutoMapper = false, bool logInitialization = false)
        {
            NamespaceParts = namespaceParts;
            InitializeAutoMapper = initializeAutoMapper;
            LogInitialization = logInitialization;
        }

        public static TestingContainerConfiguration CreateDefult()
        {
            return new TestingContainerConfiguration();
        }
    }
}