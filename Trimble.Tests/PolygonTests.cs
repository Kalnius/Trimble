using System.Drawing;
using NUnit.Framework;
using Trimble;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 3, 6, -5, -10, -8, -4 }, 62)]
        [TestCase(new int[] { 2, 5, 5, -3, 1, 10, 4, 2 }, 41)]
        [TestCase(new int[] { 3, -2, 1, 3, 3, -1, 1, 2 }, 7)]
        [TestCase(new int[] { 9, 3, -2, -8, -7, -3, 4, -2 }, 49)]
        public void Polygon1Test(int[] edges, int expectedArea)
        {
            var polygon = new Polygon(edges, new Point(0, 0));
            Assert.AreEqual(expectedArea, polygon.GetArea());
        }
    }
}