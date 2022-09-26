using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLayer;

namespace KutuphaneOtomasyon
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseConnection con = new DatabaseConnection();
            con.pathAl(Application.StartupPath);
            Application.Run(new Acilis());
        }
    }
}
