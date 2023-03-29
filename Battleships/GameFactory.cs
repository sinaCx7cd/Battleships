using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class GameFactory
    {
        private readonly IShipPlacementStrategy _shipPlacementStrategy;

        public GameFactory(IShipPlacementStrategy shipPlacementStrategy)
        {
            _shipPlacementStrategy = shipPlacementStrategy;
        }

        public IBattleshipsGame BuildGame()
        {
            var shipsPlacedForHuman = _shipPlacementStrategy.PlaceShips();
            var humanBoard = new SquareBoard(shipsPlacedForHuman);
            var humanPlayer = new HumanPlayer();

            var shipsPlacedForComputer = _shipPlacementStrategy.PlaceShips();
            var computersBoard = new SquareBoard(shipsPlacedForComputer);
            var computerPlayer = new ComputerPlayer();

            return new StandardBattleshipsGame(humanPlayer, humanBoard, computerPlayer, computersBoard, new GamePrinter());
        }
    }
}
