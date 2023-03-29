using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class GreedyRandomShipPlacementStrategy : IShipPlacementStrategy
    {
        private readonly Random _random = new Random();
        public IEnumerable<Spot> PlaceShips()
        {
            var spotsWithShips = new List<Spot>();

            spotsWithShips.AddRange(PlaceShipRandomly(GameConfig.BattleshipSize, spotsWithShips));
            spotsWithShips.AddRange(PlaceShipRandomly(GameConfig.DestroyerSize, spotsWithShips));
            spotsWithShips.AddRange(PlaceShipRandomly(GameConfig.DestroyerSize, spotsWithShips));

            return spotsWithShips;
        }

        private IEnumerable<Spot> PlaceShipRandomly(int shipSize, IEnumerable<Spot> existingShips)
        {
            while (true)
            {
                var randomNSpots = GetNRandomSpotsNextToEachother(shipSize)!;
                if(randomNSpots.All(spot => CanShipBePlaced(spot, existingShips)))
                {
                    return randomNSpots;
                }
            }
        }

        private IEnumerable<Spot> GetNRandomSpotsNextToEachother(int n)
        {
            var listOfSpots = new List<Spot>();

            var currentX = _random.Next(0, GameConfig.BoardSize - 1);
            var currentY = _random.Next(0, GameConfig.BoardSize - 1);

            var spot = new Spot(currentX, currentY);

            listOfSpots.Add(spot);

            var shouldGoHorizontally = GetRandomDecision();
            var verticalIncrement = shouldGoHorizontally ? 0 : (GetRandomDecision() ? 1 : -1);
            var horizontalIncrement = shouldGoHorizontally ? (GetRandomDecision() ? 1 : -1) : 0;

            for (int i = 0; i < n - 1; i++)
            {
                currentX += horizontalIncrement;
                currentY += verticalIncrement;

                var nextSpot = new Spot(currentX, currentY);
                listOfSpots.Add(nextSpot);
            }

            return listOfSpots;
        }

        private bool CanShipBePlaced(Spot spot, IEnumerable<Spot> existingShips)
        {
            return spot.X >= 0
                && spot.Y >= 0 
                && spot.X <= GameConfig.BoardSize - 1 
                && spot.Y <= GameConfig.BoardSize - 1
                && !existingShips.Contains(spot);
        }

        private bool GetRandomDecision()
        {
            return _random.Next(0, 2) > 0;
        }
    }
}
