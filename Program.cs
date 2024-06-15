using FlyWithUs.Utils;

namespace FlyWithUs
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainView());
        }
    }
}