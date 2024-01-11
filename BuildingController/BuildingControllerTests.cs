using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingController
{
    [TestFixture]
    class BuildingControllerTests { 

        [TestCase(3, 3, 3)]
        [TestCase(4, 4, 3)]
        [TestCase(1, 7, 7)]
        public void IsTriangle_ValidSides_ReturnsTrue(int a, int b, int c)
        {
            // Arrange
            BuildingController ta = new BuildingController();

            // Act
            bool result = ta.IsTriangle(a, b, c);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase(0, 0, 0)]
        [TestCase(-1, 5, 5)]  // Negative side length
        [TestCase(1, 10, 12)] // Triangle Inequality Violation
        public void IsTriangle_InvalidSides_ReturnsFalse(int a, int b, int c)
        {
            // Arrange
            BuildingController ta = new BuildingController();

            // Act
            bool result = ta.IsTriangle(a, b, c);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 2, 3)]
        [TestCase(5, 1, 1)]
        public void ClassifyTriangle_InvalidSides_ReturnsNotATriangle(int a, int b, int c)
        {
            // Arrange
            BuildingController ta = new BuildingController();

            // Act
            string result = ta.ClassifyTriangle(a, b, c);

            // Assert
            Assert.AreEqual(result, "not a triangle");
        }

        [TestCase(5, 5, 5)]
        [TestCase(10, 10, 10)]
        [TestCase(7, 7, 7)]
        public void ClassifyTriangle_EqualSides_ReturnsEquilateral(int a, int b, int c)
        {
            // Arrange
            BuildingController ta = new BuildingController();

            // Act
            string result = ta.ClassifyTriangle(a, b, c);

            // Assert
            Assert.AreEqual(result, "equilateral");
        }

        [TestCase(5, 5, 3)]
        [TestCase(10, 10, 15)]
        [TestCase(7, 12, 12)]
        public void ClassifyTriangle_Isosceles_ReturnsIsosceles(int a, int b, int c)
        {
            // Arrange
            BuildingController ta = new BuildingController();

            // Act
            string result = ta.ClassifyTriangle(a, b, c);

            // Assert
            Assert.AreEqual(result, "isosceles");
        }

        [TestCase(4, 5, 6)]
        [TestCase(7, 8, 9)]
        [TestCase(10, 11, 12)]
        public void ClassifyTriangle_Scalene_ReturnsScalene(int a, int b, int c)
        {
            // Arrange
            BuildingController ta = new BuildingController();

            // Act
            string result = ta.ClassifyTriangle(a, b, c);

            // Assert
            Assert.AreEqual(result, "scalene");
        }
    }
}
