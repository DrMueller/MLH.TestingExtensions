using System;
using ApprovalTests;
using Newtonsoft.Json;

namespace Mmu.Mlh.TestingExtensions.Areas.ApprovalTesting
{
    public static class ApprovalExtensions
    {
        public static void SerializeAndVerifyJson<T>(T objectUnderTest)
        {
            var json = JsonConvert.SerializeObject(objectUnderTest);
            Approvals.VerifyJson(json);
        }
    }
}