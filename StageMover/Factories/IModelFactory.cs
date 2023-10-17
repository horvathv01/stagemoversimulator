using StageMover.Enums;
using StageMover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Factories
{
    interface IModelFactory
    {
       Motor CreateMotor(long id, Axis axis, double speed);
       Stage CreateStage(long id, Position position, double sizeX, double sizeY, double sizeZ);
       WorkArea CreateWorkArea(double sizeX, double sizeY, double sizeZ);

    }
}
