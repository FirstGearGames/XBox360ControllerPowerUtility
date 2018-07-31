using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Xbox360ControllerPowerUtility
{
    static class Program
    {
        private const string SUB_KEY = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string APP_NAME = "Xbox_360_Controller_POWER_UTILITY";

        private static System.Threading.Mutex singleton = new Mutex(true, APP_NAME);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (CheckStartupConditions(args))
            {
                Application.Exit();
                return;
            }

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

        private static bool CheckStartupConditions(string[] args)
        {
            if (args.Length != 1)
                return false;

            string argument = args[0].ToLower();
            switch (argument)
            {
                case "addstartup":
                    AddToStartup();
                    return true;
                case "removestartup":
                    RemoveFromStartup();
                    return true;
                default:
                    return false;
            }

        }

        private static void AddToStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(SUB_KEY, true);
            rk.SetValue(APP_NAME, Application.ExecutablePath);

        }
        private static void RemoveFromStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(SUB_KEY, true);
            rk.DeleteValue(APP_NAME, false);
        }
    }
}
