using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Models
{
    internal class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"X: ${X}, Y: ${Y}, Z: ${Z}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Position
                && ((Position)obj).X == X
                && ((Position)obj).Y == Y
                && ((Position)obj).Z == Z;
        }
    }
}
