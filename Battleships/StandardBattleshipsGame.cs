using Battleships.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class StandardBattleshipsGame : IBattleshipsGame
    {
        private readonly IPlayer _humanPlayer;
        private readonly IBoard _humanBoard;
        private readonly IPlayer _computerPlayer;
        private readonly IBoard _computerBoard;
        private readonly IGamePrinter _gamePrinter;
        private IPlayer _currentPlayer;

        public StandardBattleshipsGame(IPlayer humanPlayer, IBoard humanBoard, IPlayer computerPlayer,
            IBoard computerBoard, IGamePrinter gamePrinter)
        {
            _humanPlayer = humanPlayer;
            _humanBoard = humanBoard;
            _computerPlayer = computerPlayer;
            _computerBoard = computerBoard;
            _gamePrinter = gamePrinter;

            _currentPlayer = _humanPlayer;
        }

        public void StartGame()
        {          
            while (true)
            {
                var enemyPlayer = _currentPlayer == _humanPlayer ? _computerPlayer : _humanPlayer;
                var enemyBoard = _currentPlayer == _humanPlayer ? _computerBoard : _humanBoard;

                _gamePrinter.PrintGame(_humanBoard, _computerBoard);
                _currentPlayer.ExecuteTurn(enemyBoard);

                if (enemyBoard.AreAllShipsSunk())
                {
                    break;
                }
                
                if (enemyBoard.CanHitAgain())
                {
                    continue;
                }
                
                _currentPlayer = enemyPlayer;
            }
        }
    }
}
