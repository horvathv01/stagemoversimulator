using StageMover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMover.Models
{
    internal class Motor
    {
        public long Id { get; set; }
        public Axis Axis { get; init; }
        public double Speed { get; set; } //units per cycle
        public Motor(long id, Axis axis, double speed) {
            Id = id;
            Axis = axis;
            Speed = speed;
        }

        public void MovePlus(Stage stage, double unit = 0)
        {
            switch (Axis)
            {
                case Axis.X:
                    stage.Position.X += unit == 0 ? Speed : unit;
                    break;
                case Axis.Y:
                    stage.Position.Y += unit == 0 ? Speed : unit;
                    break;
                case Axis.Z:
                    stage.Position.Z += unit == 0 ? Speed : unit;
                    break;
            }
        }

        public void MoveMinus(Stage stage, double unit = 0) 
        { 
            switch(Axis)
            {
                case Axis.X:
                    stage.Position.X -= unit == 0 ? Speed : unit;
                    break;    
                case Axis.Y:
                    stage.Position.Y -= unit == 0 ? Speed : unit;
                    break; 
                case Axis.Z:
                    stage.Position.Z -= unit == 0 ? Speed : unit;
                    break;
            }
        }

        public override string ToString()
        {
            return $"Motor id: {Id}, axis: {Axis}, speed: {Speed}";
        }
    }
}
