using NUnit.Framework;
using System;
using NutsLookup;

namespace NutsLookupTests
{
    [TestFixture]
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
            Assert.That(result, Is.EqualTo("DE300")); // Adjust based on actual data
        }

        [Test]
        public void Test_Invalid_Country()
        {
            var result = service.GetNutsCode("XX", "10115");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Test_Invalid_Zip()
        {
            var result = service.GetNutsCode("DE", "99999");
            Assert.That(result, Is.Null);
        }
    }
}