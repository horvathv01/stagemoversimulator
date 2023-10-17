using StageMover.Models;
using StageMover.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Factories
{
    class ServiceFactory : IServiceFactory
    {
        public IMotorService CreateMotorService(Motor motorX, Motor motorY, Motor motorZ, Stage stage)
        {
            return new MotorService(motorX, motorY, motorZ, stage);
        }

        public Simulation CreateSimulation(IMotorService motorService, Stage stage)
        {
            return new Simulation(motorService, stage);
        }
    }
}
