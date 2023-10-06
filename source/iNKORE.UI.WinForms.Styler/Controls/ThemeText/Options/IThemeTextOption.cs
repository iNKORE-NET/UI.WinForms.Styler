using System;
using System.Collections.Generic;
using System.Text;

namespace iNKORE.UI.WinForms.Styler.Controls.ThemeText.Options
{
    public abstract class IThemeTextOption
    {

        internal abstract void Apply(ref NativeMethods.DTTOPTS options);

    }
}
