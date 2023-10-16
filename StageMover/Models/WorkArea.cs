using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Models
{
    internal class WorkArea
    {
        public int SizeX { get; init; }
        public int SizeY { get; init; }
        public int SizeZ { get; init; }

        public WorkArea(Stage stage, int sizeX, int sizeY, int sizeZ) 
        {
            if(stage.SizeX >= sizeX || stage.SizeY >= sizeY ||  stage.SizeZ >= sizeZ)
            {
                throw new ArgumentException("Work area should be larger than the stage!");
            }

            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
        }

        public Position GetMiddleCoordinates()
        {
            int x = (int)Math.Floor((double)(SizeX / 2));
            int y = (int)Math.Floor((double)(SizeY / 2));
            int z = (int)Math.Floor((double)(SizeZ / 2));

            return new Position(x, y, z);
        }

        public override string ToString()
        {
            return $"SizeX: ${SizeX}, SizeY: ${SizeY}, SizeZ: ${SizeZ}";
        }
    }
}
