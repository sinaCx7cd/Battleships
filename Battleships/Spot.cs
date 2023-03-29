using Battleships.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Battleships
{
    public record Spot(int X, int Y)
    {
        public static Spot FromCoordinateString(string coordinates)
        {
            EnsureCoordinatesValid(coordinates);

            var xCoordinate = coordinates[0] - 'A';
            var yCoordinate = Int32.Parse(coordinates.Substring(1)) - 1;

            return new Spot(xCoordinate, yCoordinate);
        }

        public static void EnsureCoordinatesValid(string coordinates)
        {
            var validationRegex = new Regex("^([A-J][2-9]|[A-J]1|[A-J]10)$");
            if (string.IsNullOrEmpty(coordinates) || !validationRegex.Matches(coordinates).Any())
            {
                throw new InvalidCoordinatesException("Coordinates could not be parsed. Make sure they are in right format.");
            }
        }
    }
}
