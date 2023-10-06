using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace iNKORE.UI.WinForms.Styler.Controls.ThemeText.Options
{
    public class BorderOption : IThemeTextOption
    {

        public BorderOption(Color c, int size)
        {
            BorderColor = c;
            BorderSize = size;
        }

        public Color BorderColor { get; set; }
        public int BorderSize { get; set; }


        #region IThemeTextOption Members

        internal override void Apply(ref NativeMethods.DTTOPTS options)
        {
            options.dwFlags |= NativeMethods.DTTOPSFlags.DTT_BORDERCOLOR | NativeMethods.DTTOPSFlags.DTT_BORDERSIZE;
            options.crBorder = ColorTranslator.ToWin32(BorderColor);
            options.iBorderSize = BorderSize;
        }

        #endregion
    }
}
