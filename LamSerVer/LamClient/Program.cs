using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            User user = new User();

            if (user.ShowDialog() != DialogResult.OK)
            {
                if (user.NameLogin() != "")
                {
                    ClientLam ClientLam = new ClientLam();
                    Application.Run(ClientLam);
                }
                else
                {
                    MessageBox.Show("Enter your Name Login!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Application.Exit();
            }

        }
    }
}
