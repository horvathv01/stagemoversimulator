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
        public string LogMovement(Stage stage)
        {
            return $"Stage {stage.Id} has been moved to new position: {stage.Position}.";
        }

        public string LogInvalidMovement(Stage stage, Position position)
        {
            return $"Stage {stage.Id} cannot be moved to position {position}";
        }

        public string LogChangeSpeed(Motor motor)
        {
            return $"Speed of motor {motor.Id} with axis {motor.Axis} has been changed to {motor.Speed}.";
        }

        public string LogInvalidMotor(Motor motor)
        {
            return $"Motor with id {motor.Id} has an invalid axis setting.";
        }

        public string LogInvalidStageOrWorkArea()
        {
            return "Work area should be larger than the stage!";
        }
    }
}
