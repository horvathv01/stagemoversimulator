using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Models
{
    internal class Stage
    {
        public long Id {  get; init; }
        public Position Position { get; set; }

        public double SizeX { get; init; }
        public double SizeY { get; init; }
        public double SizeZ { get; init; }
        public Stage(long id, Position position, double sizeX, double sizeY, double sizeZ) 
        {
            Id = id;

            Position = position;

            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
        }

        public override string ToString()
        {
            return $"Id: ${Id}, ${Position}, SizeX: ${SizeX}, SizeY: ${SizeY}, SizeZ: ${SizeZ}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Stage
                && ((Stage)obj).Id == Id
                && ((Stage)obj).SizeX == SizeX
                && ((Stage)obj).SizeY == SizeY
                && ((Stage)obj).SizeZ == SizeZ;
        }
    }
}
