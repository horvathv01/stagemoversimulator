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
        public Position Position { get; set; } //stage position means middle of top of stage

        public int SizeX { get; init; }
        public int SizeY { get; init; }
        public int SizeZ { get; init; }
        public Stage(long id, Position position, int? sizeX, int? sizeY, int? sizeZ) 
        {
            Id = id;

            Position = position;

            SizeX = sizeX == null ? 25 : sizeX.Value;
            SizeY = sizeY == null ? 20 : sizeY.Value;
            SizeZ = sizeZ == null ? 5 : sizeZ.Value;
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
