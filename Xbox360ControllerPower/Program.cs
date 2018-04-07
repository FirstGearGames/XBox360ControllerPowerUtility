using System;
using System.Threading;
using System.Windows.Forms;

namespace Xbox360ControllerPowerUtility
{
    static class Program
    {
        private static System.Threading.Mutex singleton = new Mutex(true, "Xbox_360_Controller_POWER_UTILITY");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Allow only once instance of the program to run.
            if (!singleton.WaitOne(TimeSpan.Zero, true))
            {
                //there is already another instance running!
                Application.Exit();
            }
            //Program isn't running yet.
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }

        }
    }
}
