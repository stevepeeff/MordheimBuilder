using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainModel.Tests
{
    [TestClass]
    public class GenericTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            GenericUsage q = new GenericUsage(10);
            //GenericUsage<int> x = new GenericUsage<int>(10);
        }
    }
}