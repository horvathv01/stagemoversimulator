using StageMover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Services
{
    internal class Simulation
    {
        private Logger _logger {  get; init; }
        private Motor _motorX { get; init; }
        private Motor _motorY { get; init; }
        private Motor _motorZ { get; init; }
        private WorkArea _workArea { get; init; }

        private Stage _stage { get; init; }

        private Simulation(Logger logger, Motor motorX, Motor motorY, Motor motorZ, WorkArea workArea, Stage stage) 
        {
            bool validationResult = Validate(logger, motorX, motorY, motorZ, workArea, stage);
            if (!validationResult)
            {
                throw new ArgumentException("Simulation cannot be run with the parameters provided. Please try again.");
            } else
            {
                _logger = logger;
                _motorX = motorX;
                _motorY = motorY;
                _motorZ = motorZ;
                _workArea = workArea;
                _stage = stage;
            }
        }

        /// <summary>
        /// Runs the simulation. Should be run in a while loop.
        /// </summary>
        public void Run()
        {
                //check for user input
                //validate user input
                    //true: goal = user input
                    //false: log invalid goal
                //wait one second
                //check goal:
                    //null? --> idle (repeat cycle)
                        //not null --> check current position: same as goal?
                            //true: idle (repeat cycle)
                            //false: step towards goal (with all motors)            
        }

        private bool Validate(Logger logger, Motor motorX, Motor motorY, Motor motorZ, WorkArea workArea, Stage stage)
        {
            if(motorX.Axis != Enums.Axis.X)
            {
                logger.LogInvalidMotor(motorX);
                return false;
            }
            if(motorY.Axis != Enums.Axis.Y)
            {
                logger.LogInvalidMotor(motorY);
                return false;
            }
            if(motorZ.Axis != Enums.Axis.Z)
            {
                logger.LogInvalidMotor(motorZ);
                return false;
            }
            if (stage.SizeX >= workArea.SizeX || stage.SizeY >= workArea.SizeY || stage.SizeZ >= workArea.SizeZ)
            {
                logger.LogInvalidStageOrWorkArea();
                return false;
            }
            return true;
        }

    }
}
