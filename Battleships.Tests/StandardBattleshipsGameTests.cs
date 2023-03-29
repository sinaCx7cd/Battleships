using Battleships.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Tests
{
    public class StandardBattleshipsGameTests
    {
        private Mock<IPlayer> playerA = null!;
        private Mock<IPlayer> playerB = null!;

        private Mock<IBoard> playerABoard = null!;
        private Mock<IBoard> playerBBoard = null!;

        [SetUp]
        public void Setup()
        {
            playerA = new Mock<IPlayer>();
            playerB = new Mock<IPlayer>();

            playerABoard = new Mock<IBoard>();
            playerBBoard = new Mock<IBoard>();

            playerA.Setup(p => p.ExecuteTurn(playerBBoard.Object));
            playerB.Setup(p => p.ExecuteTurn(playerABoard.Object));
        }


        [Test]
        public void StartGame_WhenCalled_ShouldExecutePlayersTurnsAndReturn()
        {
            var printer = new Mock<IGamePrinter>();

            playerBBoard.Setup(b => b.AreAllShipsSunk()).Returns(false);
            playerABoard.Setup(b => b.AreAllShipsSunk()).Returns(true);

            var game = new StandardBattleshipsGame(playerA.Object, playerABoard.Object, playerB.Object, playerBBoard.Object, printer.Object);

            game.StartGame();

            playerA.Verify(p => p.ExecuteTurn(playerBBoard.Object), Times.Once());
            playerB.Verify(p => p.ExecuteTurn(playerABoard.Object), Times.Once());
        }

        [Test]
        public void StartGame_WhenCalledAndPlayerHits_ShouldGiveHimAnotherTry()
        {
            var printer = new Mock<IGamePrinter>();

            playerBBoard.Setup(b => b.AreAllShipsSunk()).Returns(false);
            playerBBoard.SetupSequence(b => b.CanHitAgain()).Returns(true).Returns(false);

            playerABoard.Setup(b => b.AreAllShipsSunk()).Returns(true);

            var game = new StandardBattleshipsGame(playerA.Object, playerABoard.Object, playerB.Object, playerBBoard.Object, printer.Object);

            game.StartGame();

            playerA.Verify(p => p.ExecuteTurn(playerBBoard.Object), Times.Exactly(2));
            playerB.Verify(p => p.ExecuteTurn(playerABoard.Object), Times.Once());
        }
    }
}
