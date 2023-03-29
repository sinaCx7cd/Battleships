using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Interfaces
{
    public interface IGamePrinter
    {
        void PrintGame(IBoard playersBoard, IBoard enemysBoard);
    }
}
