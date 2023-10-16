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
        public int Speed { get; set; } //units per seconds
        public Motor(long id, Axis axis, int? speed) {
            Id = id;
            Axis = axis;
            speed = speed == null ? 1 : speed;
        }

        public void MovePlus(Stage stage)
        {
            switch (Axis)
            {
                case Axis.X:
                    stage.Position.X += Speed;
                    break;
                case Axis.Y:
                    stage.Position.Y += Speed;
                    break;
                case Axis.Z:
                    stage.Position.X += Speed;
                    break;
            }
        }

        public void MoveMinus(Stage stage) 
        { 
            switch(Axis)
            {
                case Axis.X:
                    stage.Position.X -= Speed;
                    break;    
                case Axis.Y:
                    stage.Position.X -= Speed;
                    break; 
                case Axis.Z:
                    stage.Position.X -= Speed;
                    break;
            }
        }

        public override string ToString()
        {
            return $"Motor id: ${Id}, axis: ${Axis}, speed: ${Speed}";
        }
    }
}
