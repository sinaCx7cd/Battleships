using Battleships.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Tests
{
    public class SpotTests
    {
        [Test]
        public void FromCoordinateString_WhenFirstSpotPassed_TransformsCorrectly()
        {
            var spot = Spot.FromCoordinateString("A1");
            Assert.AreEqual(new Spot(0, 0), spot);
        }

        [Test]
        public void FromCoordinateString_WhenLastSpotPassed_TransformsCorrectly()
        {
            var spot = Spot.FromCoordinateString("J10");
            Assert.AreEqual(new Spot(9, 9), spot);
        }

        [Test]
        public void FromCoordinateString_WhenInvalidPointPassed_Throws()
        {
            Assert.Throws<InvalidCoordinatesException>(() => Spot.FromCoordinateString("K10"));
        }
    }
}
