using Battleships.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    // Simple UI just to show the game
    internal class GamePrinter : IGamePrinter
    {
        public void PrintGame(IBoard playersBoard, IBoard enemysBoard)
        {
            Console.Clear();

            Console.WriteLine("Your board");
            PrintBoard(playersBoard, false);

            Console.WriteLine();
            Console.WriteLine("Enemy board");
            PrintBoard(enemysBoard, true);

            Console.WriteLine();
            Console.WriteLine("S - your ship");
            Console.WriteLine("X - sank ship");
            Console.WriteLine("x - miss");
        }

        private void PrintBoard(IBoard board, bool isEnemyBoard)
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int i = 0; i < GameConfig.BoardSize; i++)
            {
                Console.Write($"{i + 1}");

                if (i != GameConfig.BoardSize - 1)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < GameConfig.BoardSize; j++)
                {
                    var currentSpot = new Spot(j, i);
                    var spotKind = board.GetSpotKind(currentSpot);

                    Console.Write(' ');
                    Console.Write(GetSpotDisplay(spotKind, isEnemyBoard));
                }

                Console.WriteLine();
            }
        }

        private char GetSpotDisplay(SpotKind spotKind, bool isEnemyBoard)
        {
            switch (spotKind)
            {
                case SpotKind.Empty:
                    return ' ';
                case SpotKind.Ship:
                    return isEnemyBoard ? ' ' : 'S';
                case SpotKind.Miss:
                    return 'x';
                case SpotKind.HitShip:
                    return 'X';
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
