using System.Collections.Generic;
using MostSuitableStation.Model;
using NUnit.Framework;

namespace MostSuitableStation.Tests
{
    [TestFixture]
    public class SuitableStationHelperTests
    {
        private readonly List<Station> _stations = new List<Station>
        {
            new Station { Coordinates = new Point { X = 0, Y = 0 }, Reach = 10 },
            new Station { Coordinates = new Point { X = 20, Y = 20 }, Reach = 5 },
            new Station { Coordinates = new Point { X = 10, Y = 0 }, Reach = 12 }
        };

        [Test]
        public void Point_0_0_Returns_Station_0_0_With_Power_100()
        {
            var point = new Point { X = 0, Y = 0 };
            var expectedMessage =
                $"Best link station for point {point.X}, {point.Y} is 0, 0 with power 100";

            var result = new SuitableStationHelper(_stations)
                .MostSuitableStationFor(point);

            Assert.AreEqual(expectedMessage, result);
        }

        [Test]
        public void Point_100_100_Returns_No_Link()
        {
            var point = new Point { X = 100, Y = 100 };
            var expectedMessage =
                $"No link station within reach for point {point.X}, {point.Y}";

            var result = new SuitableStationHelper(_stations)
                .MostSuitableStationFor(point);

            Assert.AreEqual(expectedMessage, result);
        }

        [Test]
        public void Point_15_10_Returns_Station_10_0()
        {
            var point = new Point { X = 15, Y = 10 };
            var expectedMessage =
                $"Best link station for point {point.X}, {point.Y} is 10, 0";

            var result = new SuitableStationHelper(_stations)
                .MostSuitableStationFor(point);

            Assert.That(result.StartsWith(expectedMessage));
        }

        [Test]
        public void Point_18_18_Returns_Station_20_20()
        {
            var point = new Point { X = 18, Y = 18 };
            var expectedMessage =
                $"Best link station for point {point.X}, {point.Y} is 20, 20";

            var result = new SuitableStationHelper(_stations)
                .MostSuitableStationFor(point);

            Assert.That(result.StartsWith(expectedMessage));
        }
    }
}
