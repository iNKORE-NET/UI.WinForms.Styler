using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Styler.Controls
{
	/// <summary>A button that displays an image and no text.</summary>
	[ToolboxItem(true), ToolboxBitmap(typeof(ThemedImageButton), "ThemedImageButton.bmp")]
	public class ThemedImageButton : ButtonBase
	{
		private ToolTip toolTip;

		/// <summary>Initializes a new instance of the <see cref="ThemedImageButton"/> class.</summary>
		public ThemedImageButton()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.ResizeRedraw |
				ControlStyles.UserPaint, true);

			ButtonState = PushButtonState.Normal;
			toolTip = new ToolTip();
			toolTip.SetToolTip(this, ToolTipText);
			StyleClass = "BUTTON";
			StylePart = 1;
		}
        public bool IsDesignMode
        {
            get
            {
                Control p = this;
                while (p != null)
                {
                    var site = p.Site;
                    if (site != null && site.DesignMode)
                        return true;
                    p = p.Parent;
                }
                return false;
            }
        }
        /// <summary>Gets or sets the background color of the control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"/> value representing the background color.</returns>
        public override Color BackColor
		{
			//get => OnGlass ? Color.Transparent : base.BackColor;
			set => base.BackColor = value;
		}

		/// <summary>Gets or sets the style class.</summary>
		/// <value>The style class.</value>
		[DefaultValue("BUTTON"), Category("Appearance")]
		public string StyleClass { get; set; }

		/// <summary>Gets or sets the style part.</summary>
		/// <value>The style part.</value>
		[DefaultValue(1), Category("Appearance")]
		public int StylePart { get; set; }

		/// <summary>Gets or sets the text associated with this control.</summary>
		/// <returns>The text associated with this control.</returns>
		[DefaultValue(""), Category("Appearance")]
		public override string Text
		{
			get => base.Text;
			set => base.Text = value;
		}

		/// <summary>Gets or sets the tool tip text.</summary>
		/// <value>The tool tip text.</value>
		[DefaultValue(""), Category("Appearance")]
		public string ToolTipText
		{
			get => toolTip.GetToolTip(this);
			set => toolTip.SetToolTip(this, value);
		}

        [DefaultValue(ToolStripItemDisplayStyle.Text), Category("Appearance")]
        public ToolStripItemDisplayStyle DisplayStyle { get; set; }

        /// <summary>Gets or sets the state of the button.</summary>
        /// <value>The state of the button.</value>
        protected PushButtonState ButtonState { get; set; }

		/// <summary>Retrieves the default size for the control.</summary>
		/// <value></value>
		/// <returns>The default <see cref="T:System.Drawing.Size"/> of the control.</returns>
		protected override Size DefaultSize => new Size(30, 30);

        /// <summary>Gets a value indicating whether on glass.</summary>
        /// <value><c>true</c> if on glass; otherwise, <c>false</c>.</value>
        //private bool OnGlass => !this.IsDesignMode && Dialogs.Glass.IsDwmCompositionEnabled;

		/// <summary>Retrieves the size of a rectangular area into which a control can be fitted.</summary>
		/// <param name="proposedSize">The custom-sized area for a control.</param>
		/// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.</returns>
		public override Size GetPreferredSize(Size proposedSize) => DefaultSize;

		/// <summary>For button user use to simulate a click operate.</summary>
		public void PerformClicked() => base.OnClick(EventArgs.Empty);

		/// <summary>Process Enabled property changed</summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			ButtonState = Enabled ? PushButtonState.Normal : PushButtonState.Disabled;
			Invalidate();
			base.OnEnabledChanged(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.</summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected override void OnGotFocus(EventArgs e)
		{
			Invalidate();
			base.OnGotFocus(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"/> event.</summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected override void OnLostFocus(EventArgs e)
		{
			Invalidate();
			base.OnLostFocus(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
			ButtonState = PushButtonState.Pressed;
			Invalidate();
			base.OnMouseDown(e);
		}

		/// <summary>Raises the <see cref="M:System.Windows.Forms.Control.OnMouseEnter(System.EventArgs)"/> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnMouseEnter(EventArgs e)
		{
			ButtonState = PushButtonState.Hot;
			Invalidate();
			base.OnMouseEnter(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"/> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnMouseLeave(EventArgs e)
		{
			ButtonState = Enabled ? PushButtonState.Normal : PushButtonState.Disabled;
			Invalidate();
			base.OnMouseLeave(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"/> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
			ButtonState = Enabled ? PushButtonState.Hot : PushButtonState.Disabled;
			Invalidate();
			base.OnMouseUp(e);
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			if (Visible)
			{
				var g = e.Graphics;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.CompositingQuality = CompositingQuality.HighQuality;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;

				PaintButton(e.Graphics, e.ClipRectangle);
			}
		}

		/// <summary>Paints the background of the control.</summary>
		/// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains information about the control to paint.</param>
		protected override void OnPaintBackground(PaintEventArgs pevent) => base.OnPaintBackground(pevent);
		/// <summary>Primary function for painting the button. This method should be overridden instead of OnPaint.</summary>
		/// <param name="graphics">The graphics.</param>
		/// <param name="bounds">The bounds.</param>
		protected virtual void PaintButton(Graphics graphics, Rectangle bounds)
		{
            if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement("Navigation", 0, 0))/*PlatformHelper.VistaOrHigher && PlatformHelper.VisualStylesEnabled*/) //This seems to be the right check according to the MSDN: https://msdn.microsoft.com/en-us/library/vstudio/ms171735(v=vs.100).aspx
            {
                new VisualStyleRenderer(StyleClass, StylePart, this.Enabled ? (int)ButtonState : (int)PushButtonState.Disabled).DrawBackground(graphics, this.DisplayRectangle);
            }
            if ((DisplayStyle & ToolStripItemDisplayStyle.Image) == ToolStripItemDisplayStyle.Image)
            {
                //var rea = new ToolStripItemImageRenderEventArgs(e.Graphics, this, InternalLayout.ImageRectangle)
                //{
                //    ShiftOnPress = true
                //};
                //renderer.DrawItemImage(rea);

            }

            if ((DisplayStyle & ToolStripItemDisplayStyle.Text) == ToolStripItemDisplayStyle.Text)
            {
                renderer.DrawItemText(new ToolStripItemTextRenderEventArgs(e.Graphics, this, Text, InternalLayout.TextRectangle, ForeColor, Font, InternalLayout.TextFormat));
            }
            //         if (InitializeRenderer())
            //{
            //	if (OnGlass)
            //	{
            //		DrawWrapper(graphics, bounds, hdc => DrawGlassBackground(hTheme, hdc, StylePart, (int)ButtonState, bounds, false, bounds));
            //	}
            //	else
            //	{
            //		using (var hdc = new SafeDCHandle(graphics))
            //		{
            //			DrawThemeParentBackground(Handle, hdc, bounds);
            //			RECT rr = bounds;
            //			DrawThemeBackground(hTheme, hdc, StylePart, (int)ButtonState, ref rr, null);
            //		}
            //	}
            //}
            //else
            //{
            //	if (ImageList != null && ImageList.Images.Count > 0)
            //	{
            //		var idx = (int)ButtonState - 1;
            //		if (ImageList.Images.Count == 1)
            //			idx = 0;
            //		else if (ImageList.Images.Count == 2)
            //			idx = ButtonState == PushButtonState.Disabled ? 1 : 0;
            //		else if (ImageList.Images.Count == 3)
            //			idx = ButtonState == PushButtonState.Normal ? 0 : idx - 1;
            //		var forceDisabled = !Enabled && ImageList.Images.Count == 1;
            //		if (OnGlass)
            //		{
            //			VisualStyleRendererExtension.DrawGlassImage(null, graphics, bounds, ImageList.Images[idx], forceDisabled);
            //		}
            //		else
            //		{
            //			if (!Application.RenderWithVisualStyles && VisualStyleInformation.IsSupportedByOS)
            //			{
            //				var g = graphics.BeginContainer();
            //				var translateRect = bounds;
            //				graphics.TranslateTransform(-bounds.Left, -bounds.Top);
            //				var pe = new PaintEventArgs(graphics, translateRect);
            //				InvokePaintBackground(Parent, pe);
            //				InvokePaint(Parent, pe);
            //				graphics.ResetTransform();
            //				graphics.EndContainer(g);
            //			}
            //			else
            //				graphics.Clear(Parent.BackColor);
            //			if (forceDisabled)
            //				ControlPaint.DrawImageDisabled(graphics, ImageList.Images[idx], 0, 0, Color.Transparent);
            //			else
            //			{
            //				//base.ImageList.Draw(graphics, bounds.X, bounds.Y, bounds.Width, bounds.Height, idx);
            //				//VisualStyleRendererExtender.DrawGlassImage(null, graphics, bounds, base.ImageList.Images[idx], forceDisabled); // Not 7
            //				graphics.DrawImage(ImageList.Images[idx], bounds, bounds, GraphicsUnit.Pixel); // Works on XP, not 7, with Parent.BackColor
            //			}
            //		}
            //	}
            //	/*else if (this.ImageList != null && this.ImageList.Images.Count > 1)
            //	{
            //		int idx = (int)ButtonState - 1;
            //		if (this.ImageList.Images.Count == 2)
            //			idx = ButtonState == PushButtonState.Disabled ? 1 : 0;
            //		if (this.ImageList.Images.Count == 3)
            //			idx = ButtonState == PushButtonState.Normal ? 0 : idx - 1;
            //		if (rnd != null && !this.IsDesignMode() && DesktopWindowManager.IsCompositionEnabled())
            //			rnd.DrawGlassIcon(graphics, bounds, this.ImageList, idx);
            //		else
            //			this.ImageList.Draw(graphics, bounds.X, bounds.Y, bounds.Width, bounds.Height, idx);
            //	}*/
            //	// No image so draw standard button
            //	else
            //	{
            //		ButtonRenderer.DrawParentBackground(graphics, bounds, this);
            //		ButtonRenderer.DrawButton(graphics, bounds, ButtonState);
            //	}
            //}

            if (Focused)
				ControlPaint.DrawFocusRectangle(graphics, bounds);
		}

		//private void InitializeImageList(Size imageSize) => ImageList = new ImageList() { ImageSize = imageSize, ColorDepth = ColorDepth.Depth32Bit, TransparentColor = Color.Transparent };

		//private bool InitializeRenderer()
		//{
		//	if (Application.RenderWithVisualStyles || DesktopWindowManager.IsCompositionEnabled())
		//	{
		//		try
		//		{
		//			hTheme = new SafeThemeHandle(OpenThemeData(Handle, StyleClass));
		//			return true;
		//		}
		//		catch { }
		//	}
		//	return false;
		//}
	}
}