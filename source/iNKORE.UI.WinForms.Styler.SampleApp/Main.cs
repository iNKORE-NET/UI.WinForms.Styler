using iNKORE.UI.WinForms.Styler.Controls;
using iNKORE.UI.WinForms.Styler;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using iNKORE.UI.WinForms.Styler.Dialogs;
using TaskDialog = iNKORE.UI.WinForms.Styler.Dialogs.TaskDialog;
using TaskDialogButton = iNKORE.UI.WinForms.Styler.Dialogs.TaskDialogButton;
using TaskDialogIcon = iNKORE.UI.WinForms.Styler.Dialogs.TaskDialogIcon;
using iNKORE.UI.WinForms.Styler.Controls.Rebar;

namespace iNKORE.UI.WinForms.Styler.Showcase
{

    public partial class Main : iNKORE.UI.WinForms.Styler.AeroForm
    {

        private Form _thumbnailedWindow = null;

        public Main()
        {
            InitializeComponent();

            _thumbnailedWindow = new ThumbnailedWindow();
            //_thumbnailedWindow.Show(this);
            _thumbnailedWindow.Location = new Point(Location.X + Size.Width, Location.Y);

            thumbnailViewer1.SetThumbnail(_thumbnailedWindow, true);

            ResizeRedraw = true;

            _sampleProgressDialog.DoWork += new DoWorkEventHandler(_sampleProgressDialog_DoWork);

            //panel1.Controls.Remove(toolStrip1);

            ToolStripManager.Renderer = new ToolStripAeroRenderer(ToolbarTheme.Toolbar);

            rebarWrapper1.Bands.Add(new Styler.Controls.Rebar.BandWrapper()
            {
                UseCoolbarColors = true,
                Child = menuStrip1,
                Caption = "MenuStrip",
                GripSettings = GripperSettings.Always
            });
            rebarWrapper1.Bands.Add(new Styler.Controls.Rebar.BandWrapper()
            {
                UseCoolbarColors = true,
                Child = toolStrip1,
                Caption = "ToolStrip",
                GripSettings = GripperSettings.Always
            });
            rebarWrapper1.Bands.Add(new Styler.Controls.Rebar.BandWrapper()
            {
                UseCoolbarColors = true,
                Child = advTextBox1,
                Caption = "TextBox",
                GripSettings = GripperSettings.Always
            });
            rebarWrapper1.Bands.Add(new Styler.Controls.Rebar.BandWrapper()
            {
                UseCoolbarColors = true,
                Child = searchTextBox1,
                Caption = "Search",
                GripSettings = GripperSettings.Always
            });

            advComboBox1.SelectedIndex = 0;

            listView1.SetCurrentGroupState(ListViewGroupState.Collapsible | ListViewGroupState.Selected);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            GlassMargins = new Padding(0, Panel_TopNavArea.Height, 0, themedLabel2.Height);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _thumbnailedWindow.Close();

            base.OnClosing(e);
        }

        private void td_info(object sender, EventArgs e)
        {

        }

        private void ts_warning(object sender, EventArgs e)
        {

        }

        private void td_error(object sender, EventArgs e)
        {

        }

        private void td_shield(object sender, EventArgs e)
        {

        }

        private void td_shielderror(object sender, EventArgs e)
        {

        }

        private void td_shieldsuccess(object sender, EventArgs e)
        {

        }

        private void td_blueshield(object sender, EventArgs e)
        {

        }

        private void td_grayshield(object sender, EventArgs e)
        {

        }

        private void td_complex(object sender, EventArgs e)
        {

        }


        private EventHandler<iNKORE.UI.WinForms.Styler.Dialogs.TimerEventArgs> tickHandler;
        private int cTicks = 0;
        private void td_progress(object sender, EventArgs e)
        {

        }

        private void commandLink3_Click(object sender, EventArgs e)
        {
            ControlPanel cp = new ControlPanel();
            cp.ShowDialog();
            cp.Dispose();
        }

        private void commandLink1_Click(object sender, EventArgs e)
        {

        }

        private void commandLink4_Click(object sender, EventArgs e)
        {
            HorizontalPanelExample hp = new HorizontalPanelExample();
            hp.ShowDialog();
            hp.Dispose();
        }

        private async void buttonVDesktop_Click(object sender, EventArgs e)
        {
            // Some delay to allow users to switch virtual desktop

            //labelVDesktopCurrent.Text = (VirtualDesktopManager.IsWindowOnCurrentVirtualDesktop(this)) ?
            //    "Form is on currently active virtual desktop" :
            //    "Form is NOT on currently active virtual desktop";

            //labelVDesktopId.Text = VirtualDesktopManager.GetWindowDesktopId(this).Id.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _thumbnailedWindow.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (advComboBox1.SelectedIndex)
            {
                case 0:
                    ShowTaskDialog();
                    break;
                case 1:
                    ShowTaskDialogWithCommandLinks();
                    break;
                case 2:
                    ShowProgressDialog();
                    break;
                case 3:
                    ShowCredentialDialog();
                    break;
                case 4:
                    ShowFolderBrowserDialog();
                    break;
                case 5:
                    ShowOpenFileDialog();
                    break;
                case 6:
                    ShowSaveFileDialog();
                    break;
                case 7:
                    new ShellAboutDialog() { AppTitle = "Styler from iNKORE!", OtherInformation = "Some text" }.ShowDialog(this);
                    break;
            }

        }

        private ProgressDialog _sampleProgressDialog = new ProgressDialog()
        {
            WindowTitle = "Progress dialog sample",
            Text = "This is a sample progress dialog...",
            Description = "Processing...",
            ShowTimeRemaining = true,
        };


        private void ShowTaskDialog()
        {
            if (TaskDialog.OSSupportsTaskDialogs)
            {
                using (TaskDialog dialog = new TaskDialog())
                {
                    dialog.WindowTitle = "Task dialog sample";
                    dialog.MainInstruction = "This is an example task dialog.";
                    dialog.Content = "Task dialogs are a more flexible type of message box. Among other things, task dialogs support custom buttons, command links, scroll bars, expandable sections, radio buttons, a check box (useful for e.g. \"don't show this again\"), custom icons, and a footer. Some of those things are demonstrated here.";
                    dialog.ExpandedInformation = "Ookii.org's Task Dialog doesn't just provide a wrapper for the native Task Dialog API; it is designed to provide a programming interface that is natural to .Net developers.";
                    dialog.Footer = "Task Dialogs support footers and can even include <a href=\"https://github.com/iNKOREStudios/UI.WinForms.Styler\">hyperlinks</a>.";
                    dialog.FooterIcon = TaskDialogIcon.Information;
                    dialog.EnableHyperlinks = true;
                    TaskDialogButton customButton = new TaskDialogButton("A custom button");
                    TaskDialogButton okButton = new TaskDialogButton(ButtonType.Ok);
                    TaskDialogButton cancelButton = new TaskDialogButton(ButtonType.Cancel);
                    dialog.Buttons.Add(customButton);
                    dialog.Buttons.Add(okButton);
                    dialog.Buttons.Add(cancelButton);
                    dialog.HyperlinkClicked += new EventHandler<HyperlinkClickedEventArgs>(TaskDialog_HyperLinkClicked);
                    TaskDialogButton button = dialog.ShowDialog(this);
                    if (button == customButton)
                        MessageBox.Show(this, "You clicked the custom button", "Task Dialog Sample");
                    else if (button == okButton)
                        MessageBox.Show(this, "You clicked the OK button.", "Task Dialog Sample");
                }
            }
            else
            {
                MessageBox.Show(this, "This operating system does not support task dialogs.", "Task Dialog Sample");
            }
        }

        private void ShowTaskDialogWithCommandLinks()
        {
            if (TaskDialog.OSSupportsTaskDialogs)
            {
                using (TaskDialog dialog = new TaskDialog())
                {
                    dialog.WindowTitle = "Task dialog sample";
                    dialog.MainInstruction = "This is a sample task dialog with command links.";
                    dialog.Content = "Besides regular buttons, task dialogs also support command links. Only custom buttons are shown as command links; standard buttons remain regular buttons.";
                    dialog.ButtonStyle = TaskDialogButtonStyle.CommandLinks;
                    TaskDialogButton elevatedButton = new TaskDialogButton("An action requiring elevation");
                    elevatedButton.CommandLinkNote = "Both regular buttons and command links can show the shield icon to indicate that the action they perform requires elevation. It is up to the application to actually perform the elevation.";
                    elevatedButton.ElevationRequired = true;
                    TaskDialogButton otherButton = new TaskDialogButton("Some other action");
                    TaskDialogButton cancelButton = new TaskDialogButton(ButtonType.Cancel);
                    dialog.Buttons.Add(elevatedButton);
                    dialog.Buttons.Add(otherButton);
                    dialog.Buttons.Add(cancelButton);
                    dialog.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show(this, "This operating system does not support task dialogs.", "Task Dialog Sample");
            }
        }

        private void ShowProgressDialog()
        {
            if (_sampleProgressDialog.IsBusy)
                MessageBox.Show(this, "The progress dialog is already displayed.", "Progress dialog sample");
            else
                _sampleProgressDialog.Show(); // Show a modeless dialog; this is the recommended mode of operation for a progress dialog.
        }

        private void ShowCredentialDialog()
        {
            using (CredentialDialog dialog = new CredentialDialog())
            {
                // The window title will not be used on Vista and later; there the title will always be "Windows Security".
                dialog.WindowTitle = "Credential dialog sample";
                dialog.MainInstruction = "Please enter your username and password.";
                dialog.Content = "Since this is a sample the credentials won't be used for anything, so you can enter anything you like.";
                dialog.ShowSaveCheckBox = true;
                dialog.ShowUIForSavedCredentials = true;
                // The target is the key under which the credentials will be stored.
                // It is recommended to set the target to something following the "Company_Application_Server" pattern.
                // Targets are per user, not per application, so using such a pattern will ensure uniqueness.
                dialog.Target = "Ookii_DialogsWpfSample_www.example.com";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show(this, string.Format("You entered the following information:\nUser name: {0}\nPassword: {1}", dialog.Credentials.UserName, dialog.Credentials.Password), "Credential dialog sample");
                    // Normally, you should verify if the credentials are correct before calling ConfirmCredentials.
                    // ConfirmCredentials will save the credentials if and only if the user checked the save checkbox.
                    dialog.ConfirmCredentials(true);
                }
            }
        }

        private void ShowFolderBrowserDialog()
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Please select a folder.";
            dialog.UseDescriptionForTitle = true; // This applies to the Vista style dialog only, not the old dialog.

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
            {
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            }

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(this, $"The selected folder was:{Environment.NewLine}{dialog.SelectedPath}", "Sample folder browser dialog");
            }
        }


        private void ShowOpenFileDialog()
        {
            // As of .Net 3.5 SP1, WPF's Microsoft.Win32.OpenFileDialog class still uses the old style
            AdvOpenFileDialog dialog = new AdvOpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            if (!AdvFileDialog.IsAdvFileDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular open file dialog will be used. Please use Windows Vista to see the new dialog.", "Sample open file dialog");
            if (dialog.ShowDialog(this) == DialogResult.OK)
                MessageBox.Show(this, "The selected file was: " + dialog.FileName, "Sample open file dialog");
        }

        private void ShowSaveFileDialog()
        {
            AdvSaveFileDialog dialog = new AdvSaveFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.DefaultExt = "txt";
            // As of .Net 3.5 SP1, WPF's Microsoft.Win32.SaveFileDialog class still uses the old style
            if (!AdvFileDialog.IsAdvFileDialogSupported)
                MessageBox.Show(this, "Because you are not using Windows Vista or later, the regular save file dialog will be used. Please use Windows Vista to see the new dialog.", "Sample save file dialog");
            if (dialog.ShowDialog(this) == DialogResult.OK)
                MessageBox.Show(this, "The selected file was: " + dialog.FileName, "Sample save file dialog");
        }

        private void TaskDialog_HyperLinkClicked(object sender, HyperlinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Href);
        }

        private void _sampleProgressDialog_DoWork(object sender, DoWorkEventArgs e)
        {
            // Implement the operation that the progress bar is showing progress of here, same as you would do with a background worker.
            for (int x = 0; x <= 100; ++x)
            {
                Thread.Sleep(500);
                // Periodically check CancellationPending and abort the operation if required.
                if (_sampleProgressDialog.CancellationPending)
                    return;
                // ReportProgress can also modify the main text and description; pass null to leave them unchanged.
                // If _sampleProgressDialog.ShowTimeRemaining is set to true, the time will automatically be calculated based on
                // the frequency of the calls to ReportProgress.
                _sampleProgressDialog.ReportProgress(x, null, string.Format(System.Globalization.CultureInfo.CurrentCulture, "Processing: {0}%", x));
            }
        }
    }

}
