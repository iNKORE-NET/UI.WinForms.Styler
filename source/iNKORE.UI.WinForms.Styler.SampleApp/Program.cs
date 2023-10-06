using System;
using System.Windows.Forms;

namespace iNKORE.UI.WinForms.Styler.Showcase {

    internal static class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Compatibility check
            //if (!iNKORE.UI.WinForms.Styler.Controls.OsSupport.IsVistaOrLater)
            //    if (MessageBox.Show("It appears you are not running on Windows Vista (or later). The controls and dialogs implemented in this application might not work or crash.\n\nDo you want to continue?", "Windows Vista or later required", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
            //        return;

            Application.Run(new Main());
        }

    }

}
