using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;

namespace iNKORE.UI.WinForms.Styler.Controls
{

    /// <summary>
    /// A horizontal panel which resembles what is used for information and navigation in the Control Panel of Windows 7 and Vista.  
    /// </summary>
    /// <remarks>
    /// This control is meant to be used on the left hand side of a form, it creates a graphic border on the right hand side.  Also
    /// I have VB code for this control if anyone needs it, just send me an e-mail at bpell@indiana.edu or blakepell@hotmail.com.
    /// </remarks>
    [ToolboxBitmap(typeof(Panel))]
    [DefaultProperty("Theme")]
    public class StylePanel : Panel
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        /// We are by default setting the background color to Color.Transparent.  The reason for this is that a lot of controls that will
        /// be used with this, namingly the Label and LinkLabel default their back color to the color of the panel and for those controls
        /// to display properly on this panel, their BackColor will need to be Color.Transparent (otherwise, they'll display as a black
        /// box).  This should help to isolate the developer from having to research this.
        /// 
        /// To reduce flicker, especially when glass is enabled, I had to set all three of the below styles.
        /// 
        /// </remarks>
        public StylePanel()
        {
            this.BackColor = Color.Transparent;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();
        }
        private VisualStyleRenderer renderer = new VisualStyleRenderer("Rebar", 0, 0);

        private StylePanelThemes _theme = StylePanelThemes.RebarToolbar;

        public StylePanelThemes Theme
        {
            get => _theme;
            set { _theme = value;this.Invalidate(); }
        }

        /// <summary>
        /// The actual painting of the background of our control.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>
        /// The colors in use here were extracted from an image of the Control Panel taken from a Windows 7 RC1 installation.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Theme == StylePanelThemes.None)
            {
                return;
            }

            string vElement = "";
            int vPart = 0;

            switch (Theme)
            {
                case StylePanelThemes.RebarToolbar:
                    vElement = "Rebar";
                    vPart = 6;
                    break;
                case StylePanelThemes.RebarMediaToolbar:
                    vElement = "Media::Rebar";
                    vPart = 6;
                    break;
                case StylePanelThemes.RebarCommunicationsToolbar:
                    vElement = "Communications::Rebar";
                    vPart = 6;
                    break;
                case StylePanelThemes.RebarBrowserTabBar:
                    vElement = "BrowserTabBar::Rebar";
                    vPart = 6;
                    break;
                case StylePanelThemes.RebarHelpBar:
                    vElement = "Help::Rebar";
                    vPart = 6;
                    break;
                case StylePanelThemes.TooltipBox:
                    vElement = "Tooltip";
                    vPart = 1;
                    break;
                case StylePanelThemes.TooltipBallon:
                    vElement = "Help::Rebar";
                    vPart = 3;
                    break;
                case StylePanelThemes.TaskbarTop:
                    vElement = "Taskbar";
                    vPart = 3;
                    break;
                case StylePanelThemes.TaskbarBottom:
                    vElement = "Taskbar";
                    vPart = 1;
                    break;
                case StylePanelThemes.TaskbarLeft:
                    vElement = "Taskbar";
                    vPart = 4;
                    break;
                case StylePanelThemes.TaskbarRight:
                    vElement = "Taskbar";
                    vPart = 2;
                    break;
                case StylePanelThemes.Caption:
                    vElement = "Window";
                    vPart = 1;
                    break;
                case StylePanelThemes.MinCaption:
                    vElement = "Window";
                    vPart = 3;
                    break;
                case StylePanelThemes.SmallCaption:
                    vElement = "Window";
                    vPart = 2;
                    break;

                case StylePanelThemes.MaxCaption:
                    vElement = "Window";
                    vPart = 5;
                    break;
                case StylePanelThemes.CtrlNavigation:
                    vElement = "ControlPanel";
                    vPart = 1;
                    break;


            }
            if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement(vElement, vPart, 0))/*PlatformHelper.VistaOrHigher && PlatformHelper.VisualStylesEnabled*/) //This seems to be the right check according to the MSDN: https://msdn.microsoft.com/en-us/library/vstudio/ms171735(v=vs.100).aspx
            {

                if (VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement(vElement, vPart, 0)))
                    renderer.SetParameters(vElement, vPart, 0);
                else
                    renderer.SetParameters(vElement, 0, 0);

                if (renderer.IsBackgroundPartiallyTransparent())
                    renderer.DrawParentBackground(e.Graphics, this.ClientRectangle, this);

                renderer.DrawBackground(e.Graphics, this.ClientRectangle);
                //new VisualStyleRenderer(vElement, vPart, 0).DrawBackground(e.Graphics, this.DisplayRectangle);
            }
        }
    }
    public enum StylePanelThemes
    {
        None,
        RebarToolbar,
        RebarMediaToolbar,
        RebarCommunicationsToolbar,
        RebarBrowserTabBar,
        RebarHelpBar,
        TooltipBox,
        TooltipBallon,
        TaskbarTop,
        TaskbarBottom,
        TaskbarLeft,
        TaskbarRight,
        Caption,
        MinCaption,
        SmallCaption,
        MaxCaption,
        CtrlNavigation
    }
}
