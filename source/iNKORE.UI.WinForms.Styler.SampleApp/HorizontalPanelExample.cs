using System;

namespace iNKORE.UI.WinForms.Styler.Showcase
{

    public partial class HorizontalPanelExample : iNKORE.UI.WinForms.Styler.AeroForm
    {

        public HorizontalPanelExample()
        {
            InitializeComponent();
        }

        private void HorizontalPanelExample_Load(object sender, EventArgs e)
        {
            label4.Text = Environment.MachineName.ToString();
            label5.Text = "3.00 GB";
            label6.Text = "Intel(R) Pentium(R) 4 CPU 3.40 Ghz (Quad Core)";
        }

    }
}
