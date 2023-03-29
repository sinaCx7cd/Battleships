using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Tests
{
    internal class ShipPlacementStrategyTests
    {
        [Test]
        public void PlaceShips_WhenCalled_ReturnsExactlyOneBattleShipAndTwoDestroyers()
        {
            var strategy = new GreedyRandomShipPlacementStrategy();
            var ships = strategy.PlaceShips();

            var sizeOfBattleship = 5;
            var sizeOfDestroyer = 4;

            var countOfFields = sizeOfBattleship + 2 * sizeOfDestroyer;

            Assert.AreEqual(countOfFields, ships.Count());
        }
    }
}
