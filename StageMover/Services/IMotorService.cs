using StageMover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Services
{
    interface IMotorService
    {
        public void StepTowardsGoal(Position goal, Position currentPosition);
    }
}
