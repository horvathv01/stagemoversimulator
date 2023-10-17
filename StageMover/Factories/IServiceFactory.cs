using StageMover.Models;
using StageMover.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Factories
{
    interface IServiceFactory
    {
        IMotorService CreateMotorService(Motor motorX, Motor motorY, Motor motorZ, Stage stage);
        Simulation CreateSimulation(IMotorService motorService, Stage stage);
    }
}
