// Copyright ?Sven Groot (Inkore.UI.WinForms.Styler.org) 2009
// BSD license; see license.txt for details.

using System;
using System.Windows.Forms;

namespace Inkore.UI.WinForms.Styler.Dialogs.Interop
{
    class WindowHandleWrapper : IWin32Window
    {
        private IntPtr _handle;

        public WindowHandleWrapper(IntPtr handle)
        {
            _handle = handle;
        }

        #region IWin32Window Members

        public IntPtr Handle
        {
            get { return _handle; }
        }

        #endregion
    }
}