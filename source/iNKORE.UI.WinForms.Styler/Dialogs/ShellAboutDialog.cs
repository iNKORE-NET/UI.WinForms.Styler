using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace iNKORE.UI.WinForms.Styler.Dialogs
{
    [ToolboxBitmap(typeof(System.Windows.Forms.FontDialog))]
    public class ShellAboutDialog : Component
    {
        [DllImport("shell32.dll")]
        public extern static int ShellAbout(IntPtr hWnd, string szApp, string szOtherStuff, IntPtr hIcon);

        [Category("Appearance")]
        public string AppTitle { get; set; }
        [Category("Appearance")]
        public string OtherInformation { get; set; }
        [Category("Appearance")]
        public IntPtr IconHandle { get; set; }

        public int Show()
        {
            return ShellAbout(IntPtr.Zero, AppTitle, OtherInformation, IconHandle);
        }
        public int ShowDialog(IntPtr hWndParent)
        {
            return ShellAbout(hWndParent, AppTitle, OtherInformation, IconHandle);
        }
        public int ShowDialog(System.Windows.Forms.Form owner)
        {
            return ShellAbout(owner.Handle, AppTitle, OtherInformation, IconHandle);
        }
        public static int ShowDialog(IntPtr hWnd, string szApp, string szOtherStuff, IntPtr hIcon)
        {
            return ShellAbout(hWnd, szApp, szOtherStuff, hIcon);
        }

    }
}
