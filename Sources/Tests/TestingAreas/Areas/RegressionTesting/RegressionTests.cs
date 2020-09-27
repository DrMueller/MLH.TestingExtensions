using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Mmu.Mlh.TestingExtensions.Areas.ApprovalTesting;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.RegressionTesting
{
    [TestFixture]
    public class RegressionTests
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void Regression_MultipleIndviduals()
        {
            var individuals = new List<Individual>
            {
                new Individual("Matthias", "Müller", new DateTime(1986, 12, 29)),
                new Individual("Hans", "Muster", new DateTime(2000, 02, 02))
            };

            ApprovalExtensions.SerializeAndVerifyJson(individuals);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void Regression_OneIndvidual()
        {
            var individual = new Individual("Matthias", "Müller", new DateTime(1986, 12, 29));
            ApprovalExtensions.SerializeAndVerifyJson(individual);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void Regression_WithScrubber()
        {
            var individual = new Individual("Matthias", "Müller", new DateTime(1986, 12, 29));
            var json = JsonConvert.SerializeObject(individual);
            Approvals.Verify(json, str => str.Replace("Matthias", "Ueli", StringComparison.OrdinalIgnoreCase));
        }
    }
}