using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace iNKORE.UI.WinForms.Styler.Controls
{
    partial class AdvTabControl
    {
        /// <summary>
        /// This class represents low level hook to updown control used to scroll tabs. We need it to know the
        /// position of scroller and to draw hot tab as normal when the mouse moves from that tab to scroller.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        private class NativeUpDown : NativeWindow
        {
            public NativeUpDown(AdvTabControl ctrl) { parentControl = ctrl; }

            private int x;

            private AdvTabControl parentControl;

            /// <summary>
            /// Reports about current position of tab scroller.
            /// </summary>
            public int X { get { return x; } }

            protected override void WndProc(ref Message m)
            {
                //if native updown is destroyed we need release our hook
                if (m.Msg == NativeMethods.WM_DESTROY || m.Msg == NativeMethods.WM_NCDESTROY)
                    this.ReleaseHandle();
                else if (m.Msg == NativeMethods.WM_WINDOWPOSCHANGING)
                {
                    //When a scroller position is changed we should remember that new position.
                    NativeMethods.WINDOWPOS wp = (NativeMethods.WINDOWPOS)m.GetLParam(typeof(NativeMethods.WINDOWPOS));
                    this.x = wp.x;
                }
                else if (m.Msg == NativeMethods.WM_MOUSEMOVE && parentControl.lastHotIndex > 0 &&
                    parentControl.lastHotIndex != parentControl.SelectedIndex)
                {
                    //redrawing a former hot tab as normal one
                    using (Graphics context = Graphics.FromHwnd(parentControl.Handle))
                    {
                        VisualStyleRenderer rend = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
                        parentControl.DrawTabItem(context, parentControl.lastHotIndex, parentControl.GetTabRect(parentControl.lastHotIndex), rend);
                        if (parentControl.lastHotIndex - parentControl.SelectedIndex == 1)
                        {
                            Rectangle selRect = parentControl.GetTabRect(parentControl.SelectedIndex);
                            selRect.Inflate(2, 2);
                            rend.SetParameters(rend.Class, rend.Part, (int)TabItemState.Selected);
                            parentControl.DrawTabItem(context, parentControl.SelectedIndex, selRect, rend);
                        }
                    }
                }
                else if (m.Msg == NativeMethods.WM_LBUTTONDOWN)
                {
                    Rectangle invalidRect = parentControl.GetTabRect(parentControl.SelectedIndex);
                    invalidRect.X = 0; invalidRect.Width = 2;
                    invalidRect.Inflate(0, 2);
                    parentControl.Invalidate(invalidRect);
                }
                base.WndProc(ref m);
            }
        }
    }
}