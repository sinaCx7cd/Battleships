using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class SquareBoard : IBoard
    {
        private readonly List<Spot> _spotsWithShips;
        private readonly List<Spot> _hitSpots;
        private bool _canHitAgain;

        public SquareBoard(IEnumerable<Spot> spotsWithShips)
        {
            _spotsWithShips = spotsWithShips.ToList();
            _hitSpots = new List<Spot>();
        }

        public bool AreAllShipsSunk()
        {
            return _spotsWithShips.All(hitSpot => _hitSpots.Contains(hitSpot));
        }

        public bool CanHit(Spot spot)
        {
            return !_hitSpots.Contains(spot);
        }

        public bool CanHitAgain()
        {
            return _canHitAgain;
        }

        public SpotKind GetSpotKind(Spot spot)
        {
            var isHit = _hitSpots.Contains(spot);
            var isShip = _spotsWithShips.Contains(spot);

            if(isHit && isShip)
            {
                return SpotKind.HitShip;
            }

            if(isHit && !isShip)
            {
                return SpotKind.Miss;
            }

            if(isShip && !isHit)
            {
                return SpotKind.Ship;
            }

            return SpotKind.Empty;
        }

        public void Hit(Spot spot)
        {
            _canHitAgain = _spotsWithShips.Contains(spot);
            _hitSpots.Add(spot);
        }
    }
}
