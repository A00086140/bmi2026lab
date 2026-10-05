using BMICalculator;

namespace bmi2026lab.Tests
{
    [TestClass]
    public class BmiTests
    {
        // Simple test — one input, one expected result
        [TestMethod]
        public void BMICategory_ForNormalWeight_ReturnsNormal()
        {
            var bmi = new BMI
            {
                WeightStones = 12,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 10
            };

            Assert.AreEqual(BMICategory.Normal, bmi.BMICategory);
        }

        // Data-driven test — same logic, multiple inputs.
        // Runs once per DataRow.
        [TestMethod]
        [DataRow(12, 0, 5, 10, BMICategory.Normal)]
        [DataRow(15, 0, 5, 10, BMICategory.Obese)]
        public void BMICategory_ForVariousWeights_ReturnsExpected(
            int stones, int pounds, int feet, int inches, BMICategory expected)
        {
            var bmi = new BMI
            {
                WeightStones = stones,
                WeightPounds = pounds,
                HeightFeet = feet,
                HeightInches = inches
            };

            Assert.AreEqual(expected, bmi.BMICategory);
        }
    }
}