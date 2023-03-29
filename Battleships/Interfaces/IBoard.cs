using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public interface IBoard
    {
        bool CanHit(Spot spot);
        void Hit(Spot spot);
        bool AreAllShipsSunk();
        SpotKind GetSpotKind(Spot spot);
        bool CanHitAgain();
    }
}
