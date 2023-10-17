using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Models
{
    internal class WorkArea
    {
        public double SizeX { get; init; }
        public double SizeY { get; init; }
        public double SizeZ { get; init; }

        public WorkArea(double sizeX, double sizeY, double sizeZ) 
        {
            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
        }

        public Position GetMiddleCoordinates()
        {
            double x = Math.Floor(SizeX / 2);
            double y = Math.Floor(SizeY / 2);
            double z = Math.Floor(SizeZ / 2);

            return new Position(x, y, z);
        }

        public override string ToString()
        {
            return $"SizeX: {SizeX}, SizeY: {SizeY}, SizeZ: {SizeZ}";
        }
    }
}
