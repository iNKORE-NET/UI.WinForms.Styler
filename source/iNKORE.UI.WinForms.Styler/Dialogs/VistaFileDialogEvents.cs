// Copyright (c) Sven Groot (iNKORE.UI.WinForms.Styler.org) 2006
// See license.txt for details
using System;

namespace iNKORE.UI.WinForms.Styler.Dialogs
{
    internal class AdvFileDialogEvents : Interop.IFileDialogEvents, Interop.IFileDialogControlEvents
    {
        private readonly AdvFileDialog _dialog;

        public AdvFileDialogEvents(AdvFileDialog dialog)
        {
            _dialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
        }

        #region IFileDialogEvents Members

        public Interop.HRESULT OnFileOk(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd)
        {
            if (_dialog.DoFileOk(pfd))
                return iNKORE.UI.WinForms.Styler.Dialogs.Interop.HRESULT.S_OK;
            else
                return iNKORE.UI.WinForms.Styler.Dialogs.Interop.HRESULT.S_FALSE;
        }

        public Interop.HRESULT OnFolderChanging(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd, iNKORE.UI.WinForms.Styler.Dialogs.Interop.IShellItem psiFolder)
        {
            return iNKORE.UI.WinForms.Styler.Dialogs.Interop.HRESULT.S_OK;
        }

        public void OnFolderChange(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd)
        {
        }

        public void OnSelectionChange(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd)
        {
        }

        public void OnShareViolation(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd, iNKORE.UI.WinForms.Styler.Dialogs.Interop.IShellItem psi, out NativeMethods.FDE_SHAREVIOLATION_RESPONSE pResponse)
        {
            pResponse = NativeMethods.FDE_SHAREVIOLATION_RESPONSE.FDESVR_DEFAULT;
        }

        public void OnTypeChange(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd)
        {
        }

        public void OnOverwrite(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialog pfd, iNKORE.UI.WinForms.Styler.Dialogs.Interop.IShellItem psi, out NativeMethods.FDE_OVERWRITE_RESPONSE pResponse)
        {
            pResponse = NativeMethods.FDE_OVERWRITE_RESPONSE.FDEOR_DEFAULT;
        }

        #endregion

        #region IFileDialogControlEvents Members

        public void OnItemSelected(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialogCustomize pfdc, int dwIDCtl, int dwIDItem)
        {
        }

        public void OnButtonClicked(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialogCustomize pfdc, int dwIDCtl)
        {
            if (dwIDCtl == AdvFileDialog.HelpButtonId)
                _dialog.DoHelpRequest();
        }

        public void OnCheckButtonToggled(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialogCustomize pfdc, int dwIDCtl, bool bChecked)
        {
        }

        public void OnControlActivating(iNKORE.UI.WinForms.Styler.Dialogs.Interop.IFileDialogCustomize pfdc, int dwIDCtl)
        {
        }

        #endregion
    }
}
