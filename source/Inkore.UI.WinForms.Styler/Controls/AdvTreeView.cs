

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Inkore.UI.WinForms.Styler.Controls {
	[ToolboxBitmap(typeof(TreeView))]
	public class AdvTreeView : System.Windows.Forms.TreeView {
		public AdvTreeView() {
			base.HotTracking = true;
			base.ShowLines = false;
		}

        private bool hScroll=false;

        [Browsable(true)]
        public bool ShowHScroll
        {
            get { return hScroll; }
            set { hScroll = value; this.Refresh(); }
        }

		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
                if (!hScroll)
                {
                    cp.Style |= NativeMethods.TVS_NOHSCROLL;
                }
				return cp;
			}
		}

		[Browsable(false)]
		private new bool HotTracking {
			get { return base.HotTracking; }
			set { base.HotTracking = true; }
		}

		[Browsable(false)]
		private new bool ShowLines {
			get { return base.ShowLines; }
			set { base.ShowLines = false; }
		}

		protected override void OnHandleCreated(EventArgs e) {
			base.OnHandleCreated(e);

			NativeMethods.SetWindowTheme(base.Handle, "explorer", null);

			int style = NativeMethods.SendMessage(base.Handle, Convert.ToUInt32(NativeMethods.TVM_GETEXTENDEDSTYLE), 0, 0);
			style |= (NativeMethods.TVS_EX_AUTOHSCROLL | NativeMethods.TVS_EX_FADEINOUTEXPANDOS | NativeMethods.TVS_EX_DOUBLEBUFFER);
			NativeMethods.SendMessage(base.Handle, NativeMethods.TVM_SETEXTENDEDSTYLE, 0, style);
			
		}
	}
}
