using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Inkore.UI.WinForms.Styler.Controls
{
    /// <summary>
    /// This class supports rendering of TabControl correctly when using bottom alignment with a visual
    /// style enabled. When it is disabled, the default method of rendering is used.
    /// </summary>
    public partial class AdvTabControl : TabControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:VSControls.UxTabControl" /> class.
        /// </summary>
        public AdvTabControl()
        {
            this.Alignment = TabAlignment.Bottom;
            this.HotTrack = true;

            fUpDown = new NativeUpDown(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.fSysFont != IntPtr.Zero)
            {
                NativeMethods.DeleteObject(this.fSysFont);
                this.fSysFont = IntPtr.Zero;
            }
            fUpDown.ReleaseHandle();
            base.Dispose(disposing);
        }

        #region Some overridden properties

        [Browsable(true), DefaultValue(TabAlignment.Bottom)]
        new public TabAlignment Alignment
        {
            get { return base.Alignment; }
            set { /*if (value <= TabAlignment.Bottom)*/ base.Alignment = value; }
        }

        [Browsable(true), DefaultValue(true)]
        new public bool HotTrack
        {
            get { return base.HotTrack; }
            set { base.HotTrack = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        new public TabAppearance Appearance
        {
            get { return base.Appearance; }
            set { if (value == TabAppearance.Normal) base.Appearance = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        new public TabDrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { if (value == TabDrawMode.Normal) base.DrawMode = value; }
        }
        public bool PageMarginless { get; set; }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return PageMarginless ? new Rectangle(rect.Left - 4, rect.Top - 4, rect.Width + 8, rect.Height + 8) : rect;
            }
        }
        #endregion

        //This field tells us whether custom drawing is turned on.
        private bool fCustomDraw;

        /// <summary>
        /// Turns custom drawing on/off and sets native font for the control (it's required for tabs to
        /// adjust their size correctly). If one doesn't install native font manually then Windows will
        /// install an ugly system font for the control.
        /// </summary>
        private void InitializeDrawMode()
        {
            this.fCustomDraw = Application.RenderWithVisualStyles && TabRenderer.IsSupported;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque, this.fCustomDraw);
            this.UpdateStyles();
            if (this.fCustomDraw) //custom drawing will be used
            {
                if (this.fSysFont == IntPtr.Zero) this.fSysFont = this.Font.ToHfont();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.fSysFont, (IntPtr)1);
            }
            else //default drawing will be used
            {
                /* Note, that in the SendMessage call below we do not delete HFONT passed to the control. If we do
                 * so we will see an ugly system font. I think in this case the control deletes this font by itself
                 * when disposing or finalizing.*/
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.Font.ToHfont(), (IntPtr)1);
                //but we need to delete the font(if any) created when being in custom drawing mode
                if (this.fSysFont != IntPtr.Zero)
                {
                    NativeMethods.DeleteObject(this.fSysFont);
                    this.fSysFont = IntPtr.Zero;
                }
            }
        }

        /* A handle of a font used for custom drawing. We do not use this native font directly, but tab control
         * adjusts size of tabs and tab scroller basing on the size of that font.*/
        private IntPtr fSysFont = IntPtr.Zero;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            //after the control has been created we should turn custom drawing on/off etc.
            InitializeDrawMode();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (this.fCustomDraw)
            {
                /* The control is being custom drawn and managed font size is changed. We should inform the system
                 * about such a great event for it to adjust tabs' sizes. And indeed, we have to create a new
                 * native font from managed one.*/
                if (this.fSysFont != IntPtr.Zero) NativeMethods.DeleteObject(this.fSysFont);
                this.fSysFont = this.Font.ToHfont();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.fSysFont, (IntPtr)1);
            }
        }

        protected override void WndProc(ref Message m)
        {
            /* If a visual theme changes we have to reinitialize drawing mode to prevent an exception from being
             * thrown by TabRenderer when switching from visual style to "Windows Classic" and vise versa.*/
            if (m.Msg == NativeMethods.WM_THEMECHANGED) InitializeDrawMode();
            else if (m.Msg == NativeMethods.WM_PARENTNOTIFY && (m.WParam.ToInt32() & 0xffff) == NativeMethods.WM_CREATE)
            {
                /* Tab scroller has been created (there are too many tabs to display and the control is not multiline), so
                 * let's attach our hook to it.*/
                StringBuilder className = new StringBuilder(16);
                if (NativeMethods.RealGetWindowClass(m.LParam, className, 16) > 0 && className.ToString() == "msctls_updown32")
                {
                    fUpDown.ReleaseHandle();
                    fUpDown.AssignHandle(m.LParam);
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Draws our tab control.
        /// </summary>
        /// <param name="g">The <see cref="T:System.Drawing.Graphics"/> object used to draw the tab control.</param>
        /// <param name="clipRect">The <see cref="T:System.Drawing.Rectangle"/> that specifies the clipping rectangle
        /// of the control.</param>
        private void DrawCustomTabControl(Graphics g, Rectangle clipRect)
        {
            /* In this method we draw only those parts of the control which intersect with the
             * clipping rectangle. It's some kind of optimization.*/
            if (!this.Visible) return;

            //selected tab index and rectangle
            int iSel = this.SelectedIndex;
            Rectangle selRect = iSel != -1 ? this.GetTabRect(iSel) : Rectangle.Empty;

            Rectangle rcPage = this.ClientRectangle;
            //correcting page rectangle
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    {
                        int trunc = selRect.Height * this.RowCount + 2;
                        rcPage.Y += trunc; rcPage.Height -= trunc;
                    } break;
                case TabAlignment.Bottom: rcPage.Height -= selRect.Height * this.RowCount + 1;
                    break;
            }

            //draw page itself
            if (rcPage.IntersectsWith(clipRect)) TabRenderer.DrawTabPage(g, rcPage);

            int tabCount = this.TabCount;
            if (tabCount == 0) return;

            //drawing unselected tabs
            this.lastHotIndex = HitTest();//hot tab
            VisualStyleRenderer tabRend = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
            for (int iTab = 0; iTab < tabCount; iTab++)
                if (iTab != iSel)
                {
                    Rectangle tabRect = this.GetTabRect(iTab);
                    if (tabRect.Right >= 3 && tabRect.IntersectsWith(clipRect))
                    {
                        TabItemState state = iTab == this.lastHotIndex ? TabItemState.Hot : TabItemState.Normal;
                        tabRend.SetParameters(tabRend.Class, tabRend.Part, (int)state);
                        DrawTabItem(g, iTab, tabRect, tabRend);
                    }
                }

            /* Drawing of a selected tab. We'll also increase the selected tab's rectangle. It should be a little
             * bigger than other tabs.*/
            selRect.Inflate(2, 2);
            if (iSel != -1 && selRect.IntersectsWith(clipRect))
            {
                tabRend.SetParameters(tabRend.Class, tabRend.Part, (int)TabItemState.Selected);
                DrawTabItem(g, iSel, selRect, tabRend);
            }
        }

        /// <summary>
        /// Draws a single tab.
        /// </summary>
        /// <param name="g">A <see cref="T:System.Drawing.Graphics"/> object used to draw the tab control.</param>
        /// <param name="index">An index of the tab being drawn.</param>
        /// <param name="tabRect">A <see cref="T:System.Drawing.Rectangle"/> object specifying tab's bounds.</param>
        /// <param name="rend">A <see cref="T:System.Windows.Forms.VisualStyles.VisualStyleRenderer"/> object for rendering the tab.</param>
        private void DrawTabItem(Graphics g, int index, Rectangle tabRect, VisualStyleRenderer rend)
        {
            //if the scroller is visible and the tab is fully placed under it, we don't need to draw such tab
            if (fUpDown.X > 0 && tabRect.X >= fUpDown.X) return;

            bool tabSelected = rend.State == (int)TabItemState.Selected;
            // We will draw our tab on a bitmap and then transfer image to the control's graphic context.
            using (GdiMemoryContext memGdi = new GdiMemoryContext(g, tabRect.Width, tabRect.Height))
            {
                Rectangle drawRect = new Rectangle(0, 0, tabRect.Width, tabRect.Height);
                rend.DrawBackground(memGdi.Graphics, drawRect);
                if (tabSelected && tabRect.X == 0)
                {
                    int corrY = memGdi.Height - 1;
                    memGdi.SetPixel(0, corrY, memGdi.GetPixel(0, corrY - 1));
                }
                // An important moment. If tabs alignment is bottom, we should flip the image to display the tab correctly.
                if (this.Alignment == TabAlignment.Bottom) memGdi.FlipVertical();

                TabPage pg = this.TabPages[index];//tab page whose tab we're drawing
                //trying to get a tab image if any
                Image pagePict = this.GetImageByIndexOrKey(pg.ImageIndex, pg.ImageKey);
                if (pagePict != null)
                {
                    //If tab image is present we should draw it.
                    Point imgLoc = new Point(tabSelected ? 8 : 6, 2);
                    int imgRight = imgLoc.X + pagePict.Width;

                    if (this.Alignment == TabAlignment.Bottom)
                        imgLoc.Y = drawRect.Bottom - pagePict.Height - (tabSelected ? 4 : 2);
                    if (RightToLeftLayout) imgLoc.X = drawRect.Right - imgRight;
                    memGdi.Graphics.DrawImageUnscaled(pagePict, imgLoc);
                    //Correcting rectangle for drawing text.
                    drawRect.X += imgRight; drawRect.Width -= imgRight;
                }
                //drawing tab text
                TextRenderer.DrawText(memGdi.Graphics, pg.Text, this.Font, drawRect, rend.GetColor(ColorProperty.TextColor),
                    TextFormatFlags.SingleLine | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                //If the tab has part under scroller we shouldn't draw that part.
                if (fUpDown.X > 0 && fUpDown.X >= tabRect.X && fUpDown.X < tabRect.Right)
                    tabRect.Width -= tabRect.Right - fUpDown.X;
                memGdi.DrawContextClipped(g, tabRect);
            }
        }

        /// <summary>
        /// This function attempts to get a tab image by index first, or, if not set, then by key.
        /// </summary>
        /// <param name="index">An index of tab image in tab control image list.</param>
        /// <param name="key">A key of tab image in tab control image list.</param>
        /// <returns><see cref="T:System.Drawing.Image"/> that represents image of the tab or null, if not set.</returns>
        private Image GetImageByIndexOrKey(int index, string key)
        {
            if (this.ImageList == null) return null;
            else if (index > -1) return this.ImageList.Images[index];
            else if (key.Length > 0) return this.ImageList.Images[key];
            else return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            /* Sort of a trick: we paint the parent control's background on this control. To do that right,
             * we're going to transform "e" into the parent's coordinate system and after we're done, we'll reset it back.*/
            Point offsetPoint = this.Location;
            e.Graphics.TranslateTransform(-offsetPoint.X, -offsetPoint.Y);
            InvokePaintBackground(this.Parent, e);
            e.Graphics.TranslateTransform(offsetPoint.X, offsetPoint.Y);

            // Now we're going to draw the tab control itself.
            DrawCustomTabControl(e.Graphics, e.ClipRectangle);
        }

        /// <summary>
        /// Gets hot tab index.
        /// </summary>
        /// <returns>Index of the tab over that the mouse is hovering or -1 if the mouse isn't over any tab.</returns>
        private int HitTest()
        {
            NativeMethods.TCHITTESTINFO hti = new NativeMethods.TCHITTESTINFO();
            Point mousePos = this.PointToClient(TabControl.MousePosition);
            hti.pt.x = mousePos.X; hti.pt.y = mousePos.Y;

            GCHandle handle = GCHandle.Alloc(hti, GCHandleType.Pinned);
            int result = (int)NativeMethods.SendMessage(this.Handle, NativeMethods.TCM_HITTEST, IntPtr.Zero, handle.AddrOfPinnedObject());
            handle.Free();

            return result;
        }

        /* We have to remember the index of last hot tab for our native updown hook to overdraw that tab as
         * normal when the mouse is moving over it.*/
        private int lastHotIndex = -1;

        //a reference to our hook
        private NativeUpDown fUpDown;
    }
}