using StageMover.Models;
using StageMover.Services;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StageMover
{
    public partial class MainWindow : Window
    {
        private Motor _motorX { get; set; }
        private Motor _motorY { get; set; }
        private Motor _motorZ { get; set; }
        private WorkArea _workArea { get; set; }
        private Stage _stage { get; set; }

        private IMotorService _motorService { get; set; }
        private Simulation _simulation { get; set; }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            //should use factory pattern or dependency injection
            _motorX = new Motor(0, Enums.Axis.X, 1);
            _motorY = new Motor(1, Enums.Axis.Y, 1);
            _motorZ = new Motor(2, Enums.Axis.Z, 1);

            var stageCenter = new Position(
                Math.Floor(RecWorkArea.Width / 2),
                Math.Floor(RecWorkArea.Height / 2),
                1);
            _stage = new Stage(3, stageCenter, Stage.Width, Stage.Height, 1);
            _motorService = new MotorService(_motorX, _motorY, _motorZ, _stage);
            _workArea = new WorkArea(RecWorkArea.Width, RecWorkArea.Height, 100);
            _simulation = new Simulation(_motorService, _stage);

            MotorXSpeed.Text = _motorX.Speed.ToString();
            MotorYSpeed.Text = _motorY.Speed.ToString();
            MotorZSpeed.Text = _motorY.Speed.ToString();

            StageXPos.Text = _stage.Position.X.ToString();
            StageYPos.Text = _stage.Position.Y.ToString();
            StageZPos.Text = _stage.Position.Z.ToString();
        }


        private async void RunSimulation()
        {
            await Task.Run(() =>
            {
                while (!_simulation.Finished)
                {
                    var newPoint = _simulation.Run();
                    Dispatcher.Invoke(() =>
                    {
                        Canvas.SetLeft(Stage, newPoint.X + RecWorkArea.Margin.Left - Stage.ActualWidth / 2);
                        Canvas.SetTop(Stage, newPoint.Y + RecWorkArea.Margin.Top - Stage.ActualHeight / 2);
                        StageXPos.Text = _simulation.Goal == null ? _stage.Position.X.ToString() : _simulation.Goal.X.ToString();
                        StageYPos.Text = _simulation.Goal == null ? _stage.Position.Y.ToString() : _simulation.Goal.Y.ToString();
                        StageZPos.Text = _simulation.Goal == null ? _stage.Position.Z.ToString() : _simulation.Goal.Z.ToString();

                        log.Text = $"Current stage position: X: {_stage.Position.X}, Y: {_stage.Position.Y}, Z: {_stage.Position.Z}";
                    });
                }
            });
            _simulation.Goal = null;
            log.Text = $"Simulation finished. Stage position: X: {_stage.Position.X}, Y: {_stage.Position.Y}, Z: {_stage.Position.Y}, " +
                $"Motor stages: X: {_motorX.Stage}, Y: {_motorY.Stage}, Z: {_motorZ.Stage}";
        }


        private void RecWorkArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point mousePosition = e.GetPosition(RecWorkArea);
            
            double mouseX = Math.Floor(mousePosition.X);
            double mouseY = Math.Floor(mousePosition.Y);
            double topZ = _stage.Position.Z;            
            
            if (EvaluateNewPosition(mouseX, mouseY, topZ))
            {
                _simulation.Goal = new Position(mouseX, mouseY, topZ);
                _simulation.Finished = false;
                log.Text = $"Simulation goal set to {_simulation.Goal}";
                RunSimulation();
            } else
            {
                log.Text = $"Position is invalid: {mouseX}, {mouseY}.";
            }
            
        }

        private bool EvaluateNewPosition(double centerX, double centerY, double topZ)
        {
            //stage is aligned by the top of its center
            return (
                centerX >= _stage.SizeX / 2 && centerX <= _workArea.SizeX - _stage.SizeX / 2 &&
                centerY >= _stage.SizeY / 2 && centerY <= _workArea.SizeY - _stage.SizeY / 2 &&
                topZ >= _stage.SizeZ && topZ <= _workArea.SizeZ
                );
        }

        private void btnMotorXSpeedPlus_Click(object sender, RoutedEventArgs e)
        {
            _motorX.Speed += 1;
            MotorXSpeed.Text = _motorX.Speed.ToString();
        }

        private void btnMotorXSpeedMinus_Click(object sender, RoutedEventArgs e)
        {
            if( _motorX.Speed > 1 ) 
            {
                _motorX.Speed -= 1;
            }
            MotorXSpeed.Text = _motorX.Speed.ToString();
        }

        private void btnMotorYSpeedPlus_Click(object sender, RoutedEventArgs e)
        {
            _motorY.Speed += 1;
            MotorYSpeed.Text = _motorY.Speed.ToString();
        }

        private void btnMotorYSpeedMinus_Click(object sender, RoutedEventArgs e)
        {
            if (_motorY.Speed > 1)
            {
                _motorY.Speed -= 1;
            }
            MotorYSpeed.Text = _motorY.Speed.ToString();
        }

        private void btnMotorZSpeedPlus_Click(object sender, RoutedEventArgs e)
        {
            _motorZ.Speed += 1;
            MotorZSpeed.Text = _motorZ.Speed.ToString();
        }

        private void btnMotorZSpeedMinus_Click(object sender, RoutedEventArgs e)
        {
            if (_motorZ.Speed > 1)
            {
                _motorZ.Speed -= 1;
            }
            MotorZSpeed.Text = _motorZ.Speed.ToString();
        }

        private void btnStageXPosPlus_Click(object sender, RoutedEventArgs e)
        {
            var PosX = _stage.Position.X + 1;
            var PosY = _stage.Position.Y;
            var PosZ = _stage.Position.Z;
            if (EvaluateNewPosition(PosX, PosY, PosZ))
            {
                _simulation.Goal = new Position(PosX, PosY, PosZ);
                _simulation.Finished = false;
                log.Text = $"Simulation goal set to {_simulation.Goal}";
                RunSimulation();
            }
            else
            {
                log.Text = $"Position is invalid: {PosX}, {PosY}, {PosZ}.";
            }
        }

        private void btnStageXPosMinus_Click(object sender, RoutedEventArgs e)
        {
            var PosX = _stage.Position.X - 1;
            var PosY = _stage.Position.Y;
            var PosZ = _stage.Position.Z;
            if (EvaluateNewPosition(PosX, PosY, PosZ))
            {
                _simulation.Goal = new Position(PosX, PosY, PosZ);
                _simulation.Finished = false;
                log.Text = $"Simulation goal set to {_simulation.Goal}";
                RunSimulation();
            }
            else
            {
                log.Text = $"Position is invalid: {PosX}, {PosY}, {PosZ}.";
            }
        }

        private void btnStageYPosPlus_Click(object sender, RoutedEventArgs e)
        {
            var PosX = _stage.Position.X;
            var PosY = _stage.Position.Y + 1;
            var PosZ = _stage.Position.Z;
            if (EvaluateNewPosition(PosX, PosY, PosZ))
            {
                _simulation.Goal = new Position(PosX, PosY, PosZ);
                _simulation.Finished = false;
                log.Text = $"Simulation goal set to {_simulation.Goal}";
                RunSimulation();
            }
            else
            {
                log.Text = $"Position is invalid: {PosX}, {PosY}, {PosZ}.";
            }
        }

        private void btnStageYPosMinus_Click(object sender, RoutedEventArgs e)
        {
            var PosX = _stage.Position.X;
            var PosY = _stage.Position.Y - 1;
            var PosZ = _stage.Position.Z;
            if (EvaluateNewPosition(PosX, PosY, PosZ))
            {
                _simulation.Goal = new Position(PosX, PosY, PosZ);
                _simulation.Finished = false;
                log.Text = $"Simulation goal set to {_simulation.Goal}";
                RunSimulation();
            }
            else
            {
                log.Text = $"Position is invalid: {PosX}, {PosY}, {PosZ}.";
            }
        }

        private void btnStageZPosPlus_Click(object sender, RoutedEventArgs e)
        {
            var PosX = _stage.Position.X;
            var PosY = _stage.Position.Y;
            var PosZ = _stage.Position.Z + 1;
            if (EvaluateNewPosition(PosX, PosY, PosZ))
            {
                _simulation.Goal = new Position(PosX, PosY, PosZ);
                _simulation.Finished = false;
                log.Text = $"Simulation goal set to {_simulation.Goal}";
                RunSimulation();
            }
            else
            {
                log.Text = $"Position is invalid: {PosX}, {PosY}, {PosZ}.";
            }
        }

        private void btnStageZPosMinus_Click(object sender, RoutedEventArgs e)
        {
            var PosX = _stage.Position.X;
            var PosY = _stage.Position.Y;
            var PosZ = _stage.Position.Z - 1;
            if (EvaluateNewPosition(PosX, PosY, PosZ))
            {
                _simulation.Goal = new Position(PosX, PosY, PosZ);
                _simulation.Finished = false;
                log.Text = $"Simulation goal set to {_simulation.Goal}";
                RunSimulation();
            }
            else
            {
                log.Text = $"Position is invalid: {PosX}, {PosY}, {PosZ}.";
            }
        }
    }
}
