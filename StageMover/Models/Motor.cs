using StageMover.Enums;

namespace StageMover.Models
{
    internal class Motor
    {
        public long Id { get; set; }
        public Axis Axis { get; init; }
        public double Speed { get; set; } //steps per cycle

        public double Stage { get; set; } //current distance from start (0), measured in motor steps

        public Motor(long id, Axis axis, double speed) {
            Id = id;
            Axis = axis;
            Speed = speed;
            Stage = 0;
        }

        public void MovePlus(Stage stage, double unit = 0)
        {
            double currentSteps = unit == 0 ? Speed : unit;
            Stage += currentSteps;
            switch (Axis)
            {
                case Axis.X:
                    stage.Position.X += currentSteps;
                    break;
                case Axis.Y:
                    stage.Position.Y += currentSteps;
                    break;
                case Axis.Z:
                    stage.Position.Z += currentSteps;
                    break;
            }
            
        }

        public void MoveMinus(Stage stage, double unit = 0) 
        {
            double currentSteps = unit == 0 ? Speed : unit;
            Stage -= currentSteps;
            switch (Axis)
            {
                case Axis.X:
                    stage.Position.X -= currentSteps;
                    break;    
                case Axis.Y:
                    stage.Position.Y -= currentSteps;
                    break; 
                case Axis.Z:
                    stage.Position.Z -= currentSteps;
                    break;
            }
        }

        public override string ToString()
        {
            return $"Motor id: {Id}, axis: {Axis}, speed: {Speed}";
        }
    }
}
