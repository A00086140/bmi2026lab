using Proj_Calc;

namespace Proj_Unittest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3, CalculcatorClass.Add(1, 2));
            Assert.AreEqual(0, CalculcatorClass.Add(-1, 1));
            Assert.AreEqual(201, CalculcatorClass.Add(1, 200));
        }
    }
}
