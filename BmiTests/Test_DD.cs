using BMICalculator;

namespace BmiTests
{
    /// <summary>
    /// Additional tests covering BMIValue and all four categories.
    /// </summary>
    [TestClass]
    public class Test_DD
    {
        // --- BMIValue: numeric calculation ---

        [TestMethod]
        public void BMIValue_ForKnownInputs_ReturnsExpected()
        {
            // 11 st 0 lb, 5 ft 10 in → ~22.10
            var bmi = new BMI
            {
                WeightStones = 11,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 10
            };

            Assert.AreEqual(22.10, bmi.BMIValue, 0.1);
        }

        // --- All four categories ---

        [TestMethod]
        [DataRow(7, 0, 5, 10, BMICategory.Underweight)]
        [DataRow(11, 0, 5, 10, BMICategory.Normal)]
        [DataRow(14, 0, 5, 10, BMICategory.Overweight)]
        [DataRow(17, 0, 5, 10, BMICategory.Obese)]
        public void BMICategory_CoversAllCategories(
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

        // --- Boundary: same stone, different inches moves category ---

        [TestMethod]
        public void BMICategory_ShorterHeight_RaisesCategory()
        {
            var taller = new BMI
            {
                WeightStones = 12,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 10
            };

            var shorter = new BMI
            {
                WeightStones = 12,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 2
            };

            Assert.IsGreaterThan(taller.BMIValue, shorter.BMIValue,
                "Shorter person should have a higher BMI for the same weight");

            Assert.AreNotEqual(taller.BMICategory, shorter.BMICategory);
        }
    }
}