using Inkore.UI.WinForms.Styler.Controls.Design;
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

namespace Inkore.UI.WinForms.Styler.Controls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class WindowFrame
        : Control
    {
        private WindowFramePart part = WindowFramePart.Caption;
        private bool active = true;

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
        public WindowFramePart WindowPart { get { return part; } set { part = value; Invalidate(); } }
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
        public bool IsActive { get { return active; } set { active = value; Invalidate(); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationButton"/> class.
        /// </summary>
        public WindowFrame()
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
            if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement("Window", (int)this.part, this.active ? 1 : 2))/*PlatformHelper.VistaOrHigher && PlatformHelper.VisualStylesEnabled*/) //This seems to be the right check according to the MSDN: https://msdn.microsoft.com/en-us/library/vstudio/ms171735(v=vs.100).aspx
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
            new VisualStyleRenderer("Window", (int)this.part, this.active ? 1 : 2).DrawBackground(g, this.DisplayRectangle);

            //Draw Focus Rectangle
            if (this.Focused && this.ShowFocusCues)
            {
                ControlPaint.DrawFocusRectangle(g, this.DisplayRectangle);
            }
        }
    }
    public enum WindowFramePart
    {
        Caption = 1,
        SmallCaption = 2,
        MinCaption = 3,
        SmallMinCaption = 4,
        MaxCaption = 5,
        SmallMaxCaption = 6,
        FrameLeft = 7,
        FrameRight = 8,
        FrameBottom = 9,
        SmallFrameLeft = 10,
        SmallFrameRight = 11,
        SmallFrameBottom = 12,
    }
}
