using DomainModel.Tests.GenericProperty;
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
            ValueTyepBase x = new ValueTypeInt(10);

            Assert.AreEqual(10, x.TheValueType);
            Assert.AreEqual(x.TheValueType.GetType(), typeof(int));
            //GenericUsage<int> x = new GenericUsage<int>(10);
        }
    }
}