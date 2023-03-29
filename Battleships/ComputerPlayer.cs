using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class ComputerPlayer : IPlayer
    {
        private readonly Random _random = new Random();

        public void ExecuteTurn(IBoard enemyBoard)
        {
            while (true)
            {
                var spot = new Spot(_random.Next(0, GameConfig.BoardSize - 1), _random.Next(0, GameConfig.BoardSize - 1));
                if (enemyBoard.CanHit(spot))
                {
                    enemyBoard.Hit(spot);
                    break;
                }
            }
        }
    }
}
