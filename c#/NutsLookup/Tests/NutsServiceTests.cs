using NUnit.Framework;
using System;

namespace NutsLookup.Tests
{
    public class NutsServiceTests
    {
        private NutsService service;

        [SetUp]
        public void Setup()
        {
            service = new NutsService();
        }

        [TearDown]
        public void Teardown()
        {
            service.Dispose();
        }

        [Test]
        public void Test_Valid_Lookup()
        {
            var result = service.GetNutsCode("DE", "10115");
            Assert.AreEqual("DE300", result); // Adjust based on actual data
        }

        [Test]
        public void Test_Invalid_Country()
        {
            var result = service.GetNutsCode("XX", "10115");
            Assert.IsNull(result);
        }

        [Test]
        public void Test_Invalid_Zip()
        {
            var result = service.GetNutsCode("DE", "99999");
            Assert.IsNull(result);
        }
    }
}
