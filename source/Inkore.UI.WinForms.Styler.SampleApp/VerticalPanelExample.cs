using System;
using System.Windows.Forms;

namespace Inkore.UI.WinForms.Styler.Showcase {

    public partial class ControlPanel : Inkore.UI.WinForms.Styler.AeroForm {

        public ControlPanel() {
            InitializeComponent();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Close();
        }

    }

}
