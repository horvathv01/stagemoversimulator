using StageMover.Enums;
using StageMover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Factories
{
    class ModelFactory : IModelFactory
    {
        public Motor CreateMotor(long id, Axis axis, double speed = 1)
        {
            return new Motor(id, axis, speed);
        }

        public Stage CreateStage(long id, Position position, double sizeX, double sizeY, double sizeZ)
        {
            return new Stage(id, position, sizeX, sizeY, sizeZ);
        }

        public WorkArea CreateWorkArea(double sizeX, double sizeY, double sizeZ)
        {
            return new WorkArea(sizeX, sizeY, sizeZ);
        }
    }
}
