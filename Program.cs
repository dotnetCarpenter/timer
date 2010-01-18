using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;

namespace WinFormTimer
{
    static class Program
    {
        public static Process FindSameProcess()
        {
            Process myProcess = Process.GetCurrentProcess();

            foreach (Process p in Process.GetProcessesByName(myProcess.ProcessName))
                if (p.Id != myProcess.Id && p.MainModule.FileName == myProcess.MainModule.FileName)
                    return p;

            return null;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr winHandle);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            bool isNotRunning;
            Mutex mutex = new Mutex(false, "Local\\Timer", out isNotRunning);
            if (isNotRunning)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmTimer());
            }
            else
            {
                Process p = FindSameProcess();
                if (p != null)
                {
                    SetForegroundWindow(p.MainWindowHandle);
                }
            }
        }
    }
}
