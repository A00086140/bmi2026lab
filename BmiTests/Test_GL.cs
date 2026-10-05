using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculator;

namespace BmiTests
{
    [TestClass]
    public class Test_GL
    {
        [TestMethod]
        public void TestMethod1()
        {
            BMI bmi = new BMI() { WeightStones = 12, WeightPounds = 0, HeightFeet = 5, HeightInches = 10 };
            Assert.AreEqual(BMICategory.Normal, bmi.BMICategory);
        }

        [TestMethod]
        [DataRow(12, 0, 5, 10, BMICategory.Normal)]
        [DataRow(15, 0, 5, 10, BMICategory.Obese)]

        public void TestMethod2(int ws, int wp, int hf, int hi, BMICategory cat)
        {
            BMI bmi = new BMI() { WeightStones = ws, WeightPounds = wp, HeightFeet = hf, HeightInches = hi };
            Assert.AreEqual(bmi.BMICategory, cat);
        }
    }

}