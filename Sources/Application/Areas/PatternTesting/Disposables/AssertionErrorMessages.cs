namespace Mmu.Mlh.TestingExtensions.Areas.PatternTesting.Disposables
{
    public static class AssertionErrorMessages
    {
        public const string MemberCalledAfterDisposedErrorMessage = "Member invoked on a disposed object.";
        public const string ObjectNotDisposedErrorMessage = "Object not disposed when expected.";
    }
}