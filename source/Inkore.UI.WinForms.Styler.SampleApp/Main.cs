using Inkore.UI.WinForms.Styler.Controls;
using Inkore.UI.WinForms.Styler;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;

namespace Inkore.UI.WinForms.Styler.Showcase
{

    public partial class Main : Inkore.UI.WinForms.Styler.AeroForm
    {

        private Form _thumbnailedWindow = null;

        public Main()
        {
            InitializeComponent();

            _thumbnailedWindow = new ThumbnailedWindow();
            _thumbnailedWindow.Show(this);
            _thumbnailedWindow.Location = new Point(Location.X + Size.Width, Location.Y);

            thumbnailViewer1.SetThumbnail(_thumbnailedWindow, true);

            ResizeRedraw = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            GlassMargins = new Padding(0, themedLabel1.Height, 0, themedLabel2.Height);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _thumbnailedWindow.Close();

            base.OnClosing(e);
        }

        private void td_info(object sender, EventArgs e)
        {

        }

        private void ts_warning(object sender, EventArgs e)
        {

        }

        private void td_error(object sender, EventArgs e)
        {

        }

        private void td_shield(object sender, EventArgs e)
        {

        }

        private void td_shielderror(object sender, EventArgs e)
        {

        }

        private void td_shieldsuccess(object sender, EventArgs e)
        {

        }

        private void td_blueshield(object sender, EventArgs e)
        {

        }

        private void td_grayshield(object sender, EventArgs e)
        {

        }

        private void td_complex(object sender, EventArgs e)
        {

        }


        private EventHandler<Inkore.UI.WinForms.Styler.Dialogs.TimerEventArgs> tickHandler;
        private int cTicks = 0;
        private void td_progress(object sender, EventArgs e)
        {

        }

        private void commandLink3_Click(object sender, EventArgs e)
        {
            ControlPanel cp = new ControlPanel();
            cp.ShowDialog();
            cp.Dispose();
        }

        private void commandLink1_Click(object sender, EventArgs e)
        {

        }

        private void commandLink4_Click(object sender, EventArgs e)
        {
            HorizontalPanelExample hp = new HorizontalPanelExample();
            hp.ShowDialog();
            hp.Dispose();
        }

        private async void buttonVDesktop_Click(object sender, EventArgs e)
        {
            // Some delay to allow users to switch virtual desktop

            buttonVDesktop.Text = "5...";
            await Task.Delay(1000);
            buttonVDesktop.Text = "4...";
            await Task.Delay(1000);
            buttonVDesktop.Text = "3...";
            await Task.Delay(1000);
            buttonVDesktop.Text = "2...";
            await Task.Delay(1000);
            buttonVDesktop.Text = "1...";
            await Task.Delay(1000);

            buttonVDesktop.Text = "Refresh again?";

            //labelVDesktopCurrent.Text = (VirtualDesktopManager.IsWindowOnCurrentVirtualDesktop(this)) ?
            //    "Form is on currently active virtual desktop" :
            //    "Form is NOT on currently active virtual desktop";

            //labelVDesktopId.Text = VirtualDesktopManager.GetWindowDesktopId(this).Id.ToString();
        }
    }

}
