using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieNet.Tools
{
    public class MainWindowProperties
    {
        public static MainWindowProperties mainWindowProperties = new MainWindowProperties();
        public MainWindowProperties()
        {
            mainWindow = new Window();
            mainWindow.WindowStyle = WindowStyle.None;
            mainWindow.ResizeMode = ResizeMode.NoResize;
            mainWindow.Left = 0;
            mainWindow.Top = 0;
            mainWindow.Width = SystemParameters.FullPrimaryScreenWidth;
            mainWindow.Height = SystemParameters.FullPrimaryScreenHeight;
            mainWindow.Topmost = true;
            Height = mainWindow.Height;
            Width = mainWindow.Width;
            VerticalPosition = mainWindow.Top + (mainWindow.Height / 2);
            HorizontalPosition = mainWindow.Left;
        }
        public Window mainWindow;
        public double Height { get; set; }
        public double Width { get; set; }
        public double VerticalPosition { get; set; }
        public double HorizontalPosition { get; set; }
        
    } 
}
