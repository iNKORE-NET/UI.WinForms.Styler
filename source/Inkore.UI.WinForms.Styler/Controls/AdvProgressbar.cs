
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Inkore.UI.WinForms.Styler.Controls
{
    [ToolboxBitmap(typeof(ProgressBar))]
    public class AdvProgressBar:System.Windows.Forms.ProgressBar
    {
        public AdvProgressBar()
        {
            NativeMethods.SendMessage(this.Handle, NativeMethods.PBM_SETSTATE, NativeMethods.PBST_NORMAL, 0);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParams = base.CreateParams;
                //Allows for smooth transition even when progressbar value is subtracted
                cParams.Style |= NativeMethods.PBS_SMOOTHREVERSE;
                return cParams;
            }
        }

        private AdvProgressStates ps_ = AdvProgressStates.Normal;
        [Description("Gets or sets the ProgressBar state."), Category("Appearance"), DefaultValue(AdvProgressStates.Normal)]
        public AdvProgressStates ProgressState
        {
            get
            {
                return ps_;
            }
            set
            {
                ps_ = value;
                SetState(ps_);
            }
        }

        public void SetState(AdvProgressStates State)
        {
            NativeMethods.SendMessage(this.Handle, NativeMethods.PBM_SETSTATE, NativeMethods.PBST_NORMAL, 0);
            //above required for values to be updated properly, but causes a slight flicker
            switch (State)
            {
                case AdvProgressStates.Normal:
                    NativeMethods.SendMessage(this.Handle, NativeMethods.PBM_SETSTATE, NativeMethods.PBST_NORMAL, 0);
                    break;
                case AdvProgressStates.Error:
                    NativeMethods.SendMessage(this.Handle, NativeMethods.PBM_SETSTATE, NativeMethods.PBST_ERROR, 0);
                    break;
                case AdvProgressStates.Paused:
                    NativeMethods.SendMessage(this.Handle, NativeMethods.PBM_SETSTATE, NativeMethods.PBST_PAUSED, 0);
                    break;
                //case States.Partial:
                //The blue progressbar is not available
                //    VistaConstants.SendMessage(this.Handle, VistaConstants.PBM_SETSTATE, PBST_PARTIAL, 0);
                //    break;
                default:
                    NativeMethods.SendMessage(this.Handle, NativeMethods.PBM_SETSTATE, NativeMethods.PBST_NORMAL, 0);
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                case NativeMethods.WM_PAINT:
                    //Paint event
                    SetState(ps_); //Paint the progressbar properly
                    break;
            }
            base.WndProc(ref m);
        }
    }
    public enum AdvProgressStates
    {
        Normal, Error, Paused
    }
}
