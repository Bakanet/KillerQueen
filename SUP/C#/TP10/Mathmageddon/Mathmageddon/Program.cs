using OxyPlot;
using OxyPlot.GtkSharp;
using OxyPlot.Series;
using Gtk;

namespace TPC10
{
    class MainClass
    {
        public static void Main()
        {
            // Viewer (OSX and Linux compatible)
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}