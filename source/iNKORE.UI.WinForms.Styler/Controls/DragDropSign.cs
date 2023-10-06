using iNKORE.UI.WinForms.Styler.Controls.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel.Design;

namespace iNKORE.UI.WinForms.Styler.Controls
{
    /// <summary>
    /// A simple Back/Forward Button drawn by Windows via Visual Styles if available.
    /// </summary>
    /// <remarks>
    /// The button is drawn with Visual Styles (Navigation > BackButton/ForwardButton). If running on XP or another OS, the button is drawn manually (in a kinda-Metro-Style)
    /// </remarks>
    public class DragDropSign
        : Control
    {
        /// <summary>
        /// Returns the default size.
        /// </summary>
        /// <value>
        /// The default size.
        /// </value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(25, 25);
            }
        }

        private DragDropSignStyle style = DragDropSignStyle.Copy;

        /// <summary>
        /// Indicates the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[DefaultValue(NavigationButtonType.Back)]
        [RefreshProperties(RefreshProperties.All)]
        [Description("Indicates the type.")]
        [Category("Appearance")]
        public DragDropSignStyle Style { get { return style; } set { style = value;this.Invalidate(); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationButton"/> class.
        /// </summary>
        public DragDropSign()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        /// <summary>
        /// Raises the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement("Navigation", 0, 0))/*PlatformHelper.VistaOrHigher && PlatformHelper.VisualStylesEnabled*/) //This seems to be the right check according to the MSDN: https://msdn.microsoft.com/en-us/library/vstudio/ms171735(v=vs.100).aspx
            {
                this.PaintWithVisualStyles(e.Graphics);
            }
            else
            {
                //this.PaintManually(e.Graphics);
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Paints the button with visual styles.
        /// </summary>
        /// <param name="g">The targeted graphics.</param>
        protected virtual void PaintWithVisualStyles(Graphics g)
        {
            //Draw button
            new VisualStyleRenderer("DragDrop", (int)this.Style, 0).DrawBackground(g, this.DisplayRectangle);

            //Draw Focus Rectangle
            if (this.Focused && this.ShowFocusCues)
            {
                ControlPaint.DrawFocusRectangle(g, this.DisplayRectangle);
            }
        }

        /*
        protected Pen normalPen;
        protected Brush hoverBrush;
        protected Pen hoverArrowPen;
        protected Brush pressedBrush;
        protected Pen pressedArrowPen;
        protected Pen disabledPen;
        /// <summary>
        /// Paints the button manually.
        /// </summary>
        /// <param name="g">The targeted graphics.</param>
        protected virtual void PaintManually(Graphics g)
        {
            
            if (normalPen == null)
            {
                normalPen = new Pen(SystemColors.ControlDark, 2);
                hoverBrush = new SolidBrush(SystemColors.ControlDark);
                hoverArrowPen = new Pen(this.BackColor, 2);
                pressedBrush = new SolidBrush(SystemColors.ControlDarkDark);
                pressedArrowPen = new Pen(this.BackColor, 2);
                disabledPen = new Pen(SystemColors.ControlLight, 2);
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath gp = new GraphicsPath())
            {
                var innerRect = new Rectangle(4, 4, this.Width - 8, this.Height - 8);
                if (this.IsBallon)
                    gp.AddLines(new PointF[] { new PointF(innerRect.X + innerRect.Width * 0.5f, innerRect.Y + innerRect.Height * 0.25f), new PointF(innerRect.X + innerRect.Width * 0.25f, innerRect.Y + innerRect.Height * 0.5f), new PointF(innerRect.X + innerRect.Width * 0.5f, innerRect.Y + innerRect.Height * 0.75f) });
                else
                    gp.AddLines(new PointF[] { new PointF(innerRect.X + innerRect.Width * 0.5f, innerRect.Y + innerRect.Height * 0.25f), new PointF(innerRect.X + innerRect.Width * 0.75f, innerRect.Y + innerRect.Height * 0.5f), new PointF(innerRect.X + innerRect.Width * 0.5f, innerRect.Y + innerRect.Height * 0.75f) });
                gp.StartFigure();
                gp.AddLine(new PointF(innerRect.X + innerRect.Width * 0.25f, innerRect.Y + innerRect.Height * 0.5f), new PointF(innerRect.X + innerRect.Width * 0.75f, innerRect.Y + innerRect.Height * 0.5f));

                if (!this.Enabled)
                {
                    g.DrawEllipse(this.disabledPen, new Rectangle(5, 5, this.Width - 10, this.Height - 10));
                    g.DrawPath(this.disabledPen, gp);
                }
                else
                {
                    switch (this.state)
                    {
                        case PushButtonState.Normal:
                            g.DrawEllipse(this.normalPen, new Rectangle(5, 5, this.Width - 10, this.Height - 10));
                            g.DrawPath(this.normalPen, gp);
                            break;
                        case PushButtonState.Hot:
                            g.FillEllipse(this.hoverBrush, new Rectangle(4, 4, this.Width - 8, this.Height - 8));
                            g.DrawPath(this.hoverArrowPen, gp);
                            break;
                        case PushButtonState.Pressed:
                            g.FillEllipse(this.pressedBrush, new Rectangle(4, 4, this.Width - 8, this.Height - 8));
                            g.DrawPath(this.pressedArrowPen, gp);
                            break;
                        default:
                            g.DrawEllipse(this.disabledPen, new Rectangle(5, 5, this.Width - 10, this.Height - 10));
                            g.DrawPath(this.disabledPen, gp);
                            break;
                    }
                }
            }
            
        }    */


        /// <summary>
        /// Raises the <see cref="EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnEnabledChanged(e);
        }

        /*
        protected override void Dispose(bool disposing)
        {
            //Dispose brushes and pens if manual drawing was used
            //if (this.normalPen != null)
            //{
                //this.normalPen.Dispose();
                //this.hoverBrush.Dispose();
                //this.hoverArrowPen.Dispose();
                //this.pressedBrush.Dispose();
                //this.pressedArrowPen.Dispose();
                //this.disabledPen.Dispose();
            //}

            base.Dispose(disposing);
        }
        */
    }
    public enum DragDropSignStyle
    {
        Copy = 1,
        Move = 2,
        UpdateMetadata = 3,
        CreateLink = 4,
        Warning = 5,
        None = 6,
        ImageBg = 7,
        TextBg = 8
    }
}
