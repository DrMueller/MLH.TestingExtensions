namespace Mmu.Mlh.TestingExtensions.Areas.Common.Assertions.Models
{
    public class AssertionResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        private AssertionResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static AssertionResult CreateFail(string message)
        {
            return new AssertionResult(false, message);
        }

        public static AssertionResult CreateSuccess()
        {
            return new AssertionResult(true, string.Empty);
        }
    }
}