using PRO131_01.Forms; 
using System.Windows.Forms;

namespace PRO131_01
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormBH()); 
        }
    }
}
