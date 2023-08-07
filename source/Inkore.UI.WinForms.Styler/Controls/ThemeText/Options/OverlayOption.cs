using System;
using System.Collections.Generic;
using System.Text;

namespace Inkore.UI.WinForms.Styler.Controls.ThemeText.Options
{
    public class OverlayOption : IThemeTextOption
    {

        public OverlayOption(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled { get; set; }

        #region IThemeTextOption Members

        internal override void Apply(ref NativeMethods.DTTOPTS options)
        {
            options.dwFlags |= NativeMethods.DTTOPSFlags.DTT_APPLYOVERLAY;
            options.fApplyOverlay = Enabled;
        }

        #endregion
    }
}
