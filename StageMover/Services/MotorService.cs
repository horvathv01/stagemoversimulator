using StageMover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Services
{
    class MotorService : IMotorService
    {
        private readonly Motor _motorX;
        private readonly Motor _motorY;
        private readonly Motor _motorZ;
        private readonly Stage _stage;

        public MotorService(Motor motorX, Motor motorY, Motor motorZ, Stage stage)
        {
            _motorX = motorX;
            _motorY = motorY;   
            _motorZ = motorZ;
            _stage = stage;
        }

        public void StepTowardsGoal(Position goal, Position currentPosition)
        {
            //X
            if(goal.X > currentPosition.X)
            {
                var distanceX = goal.X - currentPosition.X;
                if (distanceX >= _motorX.Speed)
                {
                    _motorX.MovePlus(_stage);
                } else
                {
                    _motorX.MovePlus(_stage, 1);
                }
            } 
            else if (goal.X < currentPosition.X)
            {
                var distanceX = currentPosition.X - goal.X;
                if(distanceX >= _motorX.Speed) { 
                    _motorX.MoveMinus(_stage);
                } else
                {
                    _motorX.MoveMinus(_stage, 1);
                }
            }

            //Y
            if (goal.Y > currentPosition.Y)
            {
                var distanceY = goal.Y - currentPosition.Y;
                if (distanceY >= _motorY.Speed)
                {
                    _motorY.MovePlus(_stage);
                }
                else
                {
                    _motorY.MovePlus(_stage, 1);
                }

            }
            else if (goal.Y < currentPosition.Y)
            {
                var distanceY = currentPosition.Y - goal.Y;
                if (distanceY >= _motorY.Speed)
                {
                    _motorY.MoveMinus(_stage);
                }
                else
                {
                    _motorY.MoveMinus(_stage, 1);
                }
            }

            //Z
            if (goal.Z > currentPosition.Z)
            {
                var distanceZ = goal.Z - currentPosition.Z;
                if (distanceZ >= _motorZ.Speed)
                {
                    _motorZ.MovePlus(_stage);
                }
                else
                {
                    _motorZ.MovePlus(_stage, 1);
                }

            }
            else if (goal.Z < currentPosition.Z)
            {
                var distanceZ = currentPosition.Z - goal.Z;
                if (distanceZ >= _motorZ.Speed)
                {
                    _motorZ.MoveMinus(_stage);
                }
                else
                {
                    _motorZ.MoveMinus(_stage, 1);
                }
            }

        }
    }
}
