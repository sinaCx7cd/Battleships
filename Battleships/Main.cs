using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Battleships
    {
        public static void Main()
        {
            var shipPlacementStrategy = new GreedyRandomShipPlacementStrategy();
            var gameFactory = new GameFactory(shipPlacementStrategy);
            var game = gameFactory.BuildGame();

            game.StartGame();
        }
    }
}
