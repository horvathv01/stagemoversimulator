using StageMover.Models;

namespace StageMover.Services
{
    internal class Simulation
    {
        private IMotorService _motorService;
        private Stage _stage { get; init; }

        public Position? Goal { get; set; } = null;

        public bool Finished { get; set; }

        public Simulation(IMotorService motorService, Stage stage) 
        {
            _motorService = motorService;
            _stage = stage;
        }

        public System.Windows.Point Run()
        {
            var point = new System.Windows.Point();
            System.Threading.Thread.Sleep(100);
            if(Goal != null && !_stage.Position.Equals(Goal))
            {
                _motorService.StepTowardsGoal(Goal, _stage.Position);
            } else if(_stage.Position.Equals(Goal))
                {
                    Finished = true;
                }

            point.X = _stage.Position.X;
            point.Y = _stage.Position.Y;
            return point;
        }

    }
}
