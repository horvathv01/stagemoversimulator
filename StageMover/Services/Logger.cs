using StageMover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Services
{
    internal class Logger
    {
        public void LogMovement(Stage stage, Position position)
        {
            Console.WriteLine($"Stage ${stage.Id} has been moved to new position: ${position}.");
        }

        public void LogInvalidMovement(Stage stage, Position position)
        {
            Console.WriteLine($"Stage ${stage.Id} cannot be moved to position ${position}");
        }

        public void LogChangeSpeed(Motor motor)
        {
            Console.WriteLine($"Speed of motor ${motor.Id} has been changed to ${motor.Speed}.");
        }

        public void LogInvalidMotor(Motor motor)
        {
            Console.WriteLine($"Motor with id ${motor.Id} has an invalid axis setting.");
        }

        public void LogInvalidStageOrWorkArea()
        {
            Console.WriteLine("Work area should be larger than the stage!");
        }
    }
}
