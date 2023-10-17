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
        private Logger _logger;
        private IMotorService _motorService;
        private WorkArea _workArea;
        private Stage _stage { get; init; }

        public Position? Goal { get; set; } = null;

        public string Log { get; private set; }

        public bool Finished { get; set; }

        public Simulation(Logger logger, IMotorService motorService, WorkArea workArea, Stage stage) 
        {
            _logger = logger;
            _motorService = motorService;
            _workArea = workArea;
            _stage = stage;
        }

        public System.Windows.Point Run()
        {
            var point = new System.Windows.Point();
            System.Threading.Thread.Sleep(100);
            if(Goal != null && !_stage.Position.Equals(Goal))
            {
                _motorService.StepTowardsGoal(Goal, _stage.Position);
            } else
            {
                if(_stage.Position.Equals(Goal))
                {
                    Finished = true;
                } else
                {
                    Log = "Please set a valid goal for the stage to go to!";
                }
            }
            
            point.X = _stage.Position.X;
            point.Y = _stage.Position.Y;
            return point;
        }

    }
}
