using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }



        private void RecWorkArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point mousePosition = e.GetPosition(RecWorkArea);
            

            if (mousePosition.X >= 0 && mousePosition.X <= RecWorkArea.ActualWidth &&
            mousePosition.Y >= 0 && mousePosition.Y <= RecWorkArea.ActualHeight)
            {
                double mouseX = mousePosition.X;
                double mouseY = mousePosition.Y;

                log.Text = $"Mouse X: {mouseX}, Mouse Y: {mouseY}";
            }
        }
    }
}
