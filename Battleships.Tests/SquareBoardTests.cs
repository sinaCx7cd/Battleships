using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Tests
{
    public class SquareBoardTests
    {
        [Test]
        public void Board_WhenCreated_ReturnsEmptyField()
        {
            var board = new SquareBoard(Enumerable.Empty<Spot>());
            var spot = new Spot(0, 0);

            var spotKind = board.GetSpotKind(spot);
            Assert.AreEqual(SpotKind.Empty, spotKind);
        }

        [Test]
        public void Board_WhenCreatedWithShip_ReturnsShipSpotKind()
        {
            var spotWithShip = new Spot(0, 0);
            var listWithShip = new List<Spot>
            {
                spotWithShip
            };

            var board = new SquareBoard(listWithShip);

            var spotKind = board.GetSpotKind(spotWithShip);
            Assert.AreEqual(SpotKind.Ship, spotKind);
        }

        [Test]
        public void Hit_WhenEmptySpotHit_ChangesKindToHitEmpty()
        {
            var board = new SquareBoard(Enumerable.Empty<Spot>());
            var spotToHit = new Spot(0, 0);
            board.Hit(spotToHit);

            var spotKind = board.GetSpotKind(spotToHit);
            Assert.AreEqual(SpotKind.Miss, spotKind);
        }

        [Test]
        public void Hit_WhenSpotWithShipHit_ChangesKindToHitShip()
        {
            var spotWithShip = new Spot(0, 0);
            var listWithShip = new List<Spot>
            {
                spotWithShip
            };

            var board = new SquareBoard(listWithShip);
            board.Hit(spotWithShip);

            var spotKind = board.GetSpotKind(spotWithShip);
            Assert.AreEqual(SpotKind.HitShip, spotKind);
        }

        [Test]
        public void CanHit_WhenEmptySpotWasAlreadyHit_ShouldReturnFalse()
        {
            var board = new SquareBoard(Enumerable.Empty<Spot>());
            var spotToHit = new Spot(0, 0);
            board.Hit(spotToHit);

            Assert.False(board.CanHit(spotToHit));
        }

        [Test]
        public void CanHit_WhenSpotWithShipWasAlreadyHit_ShouldReturnFalse()
        {
            var spotWithShip = new Spot(0, 0);
            var listWithShip = new List<Spot>
            {
                spotWithShip
            };

            var board = new SquareBoard(listWithShip);
            board.Hit(spotWithShip);

            Assert.False(board.CanHit(spotWithShip));
        }

        [Test]
        public void AreAllShipsSunk_WhenThereAreShipsThatAreNotSunk_ReturnsFalse()
        {
            var spotWithShip = new Spot(0, 0);
            var listWithShip = new List<Spot>
            {
                spotWithShip
            };

            var board = new SquareBoard(listWithShip);

            Assert.False(board.AreAllShipsSunk());
        }

        [Test]
        public void AreAllShipsSunk_WhenAllShipsSunk_ReturnsTrue()
        {
            var spotWithShip = new Spot(0, 0);
            var listWithShip = new List<Spot>
            {
                spotWithShip
            };

            var board = new SquareBoard(listWithShip);
            board.Hit(spotWithShip);

            Assert.True(board.AreAllShipsSunk());
        }

        [Test]
        public void CanHitAgain_WhenShipHit_ReturnsTrue()
        {
            var spotWithShip = new Spot(0, 0);
            var spotWithShip2 = new Spot(1, 0);

            var listWithShip = new List<Spot>
            {
                spotWithShip,
                spotWithShip2
            };

            var board = new SquareBoard(listWithShip);
            board.Hit(spotWithShip);

            Assert.True(board.CanHitAgain());
        }

        [Test]
        public void CanHitAgain_WhenShipNotHit_ReturnsFalse()
        {
            var spotWithShip = new Spot(0, 0);
            var spotWithShip2 = new Spot(1, 0);
            var someRandomSpot = new Spot(2, 0);

            var listWithShip = new List<Spot>
            {
                spotWithShip,
                spotWithShip2
            };

            var board = new SquareBoard(listWithShip);
            board.Hit(someRandomSpot);

            Assert.False(board.CanHitAgain());
        }
    }
}
