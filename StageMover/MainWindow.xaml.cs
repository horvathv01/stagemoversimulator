using StageMover.Models;
using StageMover.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StageMover
{
    public partial class MainWindow : Window
    {
        private Logger _logger { get; set; }
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

            //should use dependency injection/factory pattern
            _logger = new Logger();
            _motorX = new Motor(0, Enums.Axis.X, 1);
            _motorY = new Motor(1, Enums.Axis.Y, 1);
            _motorZ = new Motor(2, Enums.Axis.Z, 1);

            var stageCenter = new Position(
                Canvas.GetLeft(Stage) + Stage.ActualWidth / 2,
                Canvas.GetTop(Stage) + Stage.ActualHeight / 2,
                1);
            _stage = new Stage(3, stageCenter, Stage.ActualWidth, Stage.ActualHeight, 1);
            _motorService = new MotorService(_motorX, _motorY, _motorZ, _stage);
            _workArea = new WorkArea(RecWorkArea.ActualWidth, RecWorkArea.ActualHeight, 10);
            _simulation = new Simulation(_logger, _motorService, _workArea, _stage);
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
                        Canvas.SetLeft(Stage, newPoint.X);
                        Canvas.SetTop(Stage, newPoint.Y);
                        log.Text = $"newPointX: {newPoint.X}, newPointY: {newPoint.Y}";
                    });
                }
                Dispatcher.Invoke(() => log.Text = "Simulation finished");
            });
        }


        private void RecWorkArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point mousePosition = e.GetPosition(RecWorkArea);
            
            double mouseX = Math.Floor(mousePosition.X);
            double mouseY = Math.Floor(mousePosition.Y);
            
            
            if (EvaluateNewPosition(mouseX, mouseY))
            {
                _simulation.Goal = new Position(mouseX + RecWorkArea.Margin.Left - Stage.ActualWidth / 2,
                    mouseY + RecWorkArea.Margin.Top - Stage.ActualHeight / 2, 1);
                _simulation.Finished = false;
                log.Text = $"Simulation goal set to {_simulation.Goal}";
                RunSimulation();
            } else
            {
                log.Text = $"Position is invalid: {mouseX}, {mouseY}.";
            }
        }

        private bool EvaluateNewPosition(double centerX, double centerY)
        {
             return (
                centerX >= Stage.ActualWidth / 2 && centerX <= RecWorkArea.ActualWidth - Stage.ActualWidth / 2 &&
                centerY >= Stage.ActualHeight / 2 && centerY <= RecWorkArea.ActualHeight - Stage.ActualHeight / 2
                );
        }
    }
}
