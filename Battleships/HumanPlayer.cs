using Battleships.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class HumanPlayer : IPlayer
    {
        public void ExecuteTurn(IBoard enemyBoard)
        {
            var coordinates = Console.ReadLine();

            if (string.IsNullOrEmpty(coordinates))
            {
                ExecuteTurn(enemyBoard);
            }

            enemyBoard.Hit(Spot.FromCoordinateString(coordinates!));
        }
    }
}
