// Copyright (c) Sven Groot (Inkore.UI.WinForms.Styler.org) 2006
// See license.txt for details
using System;

namespace Inkore.UI.WinForms.Styler.Dialogs
{
    internal class AdvFileDialogEvents : Interop.IFileDialogEvents, Interop.IFileDialogControlEvents
    {
        private readonly AdvFileDialog _dialog;

        public AdvFileDialogEvents(AdvFileDialog dialog)
        {
            _dialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
        }

        #region IFileDialogEvents Members

        public Interop.HRESULT OnFileOk(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd)
        {
            if (_dialog.DoFileOk(pfd))
                return Inkore.UI.WinForms.Styler.Dialogs.Interop.HRESULT.S_OK;
            else
                return Inkore.UI.WinForms.Styler.Dialogs.Interop.HRESULT.S_FALSE;
        }

        public Interop.HRESULT OnFolderChanging(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd, Inkore.UI.WinForms.Styler.Dialogs.Interop.IShellItem psiFolder)
        {
            return Inkore.UI.WinForms.Styler.Dialogs.Interop.HRESULT.S_OK;
        }

        public void OnFolderChange(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd)
        {
        }

        public void OnSelectionChange(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd)
        {
        }

        public void OnShareViolation(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd, Inkore.UI.WinForms.Styler.Dialogs.Interop.IShellItem psi, out NativeMethods.FDE_SHAREVIOLATION_RESPONSE pResponse)
        {
            pResponse = NativeMethods.FDE_SHAREVIOLATION_RESPONSE.FDESVR_DEFAULT;
        }

        public void OnTypeChange(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd)
        {
        }

        public void OnOverwrite(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd, Inkore.UI.WinForms.Styler.Dialogs.Interop.IShellItem psi, out NativeMethods.FDE_OVERWRITE_RESPONSE pResponse)
        {
            pResponse = NativeMethods.FDE_OVERWRITE_RESPONSE.FDEOR_DEFAULT;
        }

        #endregion

        #region IFileDialogControlEvents Members

        public void OnItemSelected(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialogCustomize pfdc, int dwIDCtl, int dwIDItem)
        {
        }

        public void OnButtonClicked(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialogCustomize pfdc, int dwIDCtl)
        {
            if (dwIDCtl == AdvFileDialog.HelpButtonId)
                _dialog.DoHelpRequest();
        }

        public void OnCheckButtonToggled(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialogCustomize pfdc, int dwIDCtl, bool bChecked)
        {
        }

        public void OnControlActivating(Inkore.UI.WinForms.Styler.Dialogs.Interop.IFileDialogCustomize pfdc, int dwIDCtl)
        {
        }

        #endregion
    }
}
