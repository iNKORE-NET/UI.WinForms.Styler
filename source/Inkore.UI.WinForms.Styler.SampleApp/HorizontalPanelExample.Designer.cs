namespace Inkore.UI.WinForms.Styler.Showcase
{
    partial class HorizontalPanelExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HorizontalPanelExample));
            panelTop = new Panel();
            advButton1 = new Controls.AdvButton();
            panelDividers = new Panel();
            labeledDivider4 = new Controls.LabeledDivider();
            labeledDivider3 = new Controls.LabeledDivider();
            labeledDivider2 = new Controls.LabeledDivider();
            labeledDivider1 = new Controls.LabeledDivider();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            layout = new TableLayoutPanel();
            panelBottom = new Controls.HorizontalPanel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelTop.SuspendLayout();
            panelDividers.SuspendLayout();
            layout.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(advButton1);
            panelTop.Controls.Add(panelDividers);
            panelTop.Controls.Add(labeledDivider1);
            panelTop.Controls.Add(label9);
            panelTop.Controls.Add(label8);
            panelTop.Controls.Add(label7);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(688, 377);
            panelTop.TabIndex = 1;
            // 
            // advButton1
            // 
            advButton1.Location = new Point(439, 239);
            advButton1.Name = "advButton1";
            advButton1.ShowShield = true;
            advButton1.Size = new Size(119, 46);
            advButton1.TabIndex = 5;
            advButton1.Text = "advButton1";
            advButton1.UseVisualStyleBackColor = true;
            // 
            // panelDividers
            // 
            panelDividers.AutoScroll = true;
            panelDividers.Controls.Add(labeledDivider4);
            panelDividers.Controls.Add(labeledDivider3);
            panelDividers.Controls.Add(labeledDivider2);
            panelDividers.Location = new Point(31, 191);
            panelDividers.Name = "panelDividers";
            panelDividers.Size = new Size(374, 148);
            panelDividers.TabIndex = 4;
            // 
            // labeledDivider4
            // 
            labeledDivider4.DividerColor = Color.FromArgb(176, 191, 222);
            labeledDivider4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labeledDivider4.ForeColor = Color.FromArgb(0, 51, 170);
            labeledDivider4.Location = new Point(3, 155);
            labeledDivider4.Name = "labeledDivider4";
            labeledDivider4.Size = new Size(340, 42);
            labeledDivider4.TabIndex = 2;
            labeledDivider4.Text = "Divider 3";
            // 
            // labeledDivider3
            // 
            labeledDivider3.DividerColor = Color.FromArgb(176, 191, 222);
            labeledDivider3.DividerPosition = Styler.Controls.LabeledDivider.DividerPositions.Below;
            labeledDivider3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labeledDivider3.ForeColor = Color.FromArgb(0, 51, 170);
            labeledDivider3.Location = new Point(3, 85);
            labeledDivider3.Name = "labeledDivider3";
            labeledDivider3.Size = new Size(340, 42);
            labeledDivider3.TabIndex = 1;
            labeledDivider3.Text = "Divider 2";
            // 
            // labeledDivider2
            // 
            labeledDivider2.DividerColor = Color.FromArgb(176, 191, 222);
            labeledDivider2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labeledDivider2.ForeColor = Color.FromArgb(0, 51, 170);
            labeledDivider2.Location = new Point(3, 11);
            labeledDivider2.Name = "labeledDivider2";
            labeledDivider2.Size = new Size(340, 42);
            labeledDivider2.TabIndex = 0;
            labeledDivider2.Text = "Divider 1";
            // 
            // labeledDivider1
            // 
            labeledDivider1.DividerColor = Color.FromArgb(176, 191, 222);
            labeledDivider1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labeledDivider1.ForeColor = Color.FromArgb(0, 51, 170);
            labeledDivider1.Location = new Point(31, 102);
            labeledDivider1.Name = "labeledDivider1";
            labeledDivider1.Size = new Size(633, 30);
            labeledDivider1.TabIndex = 3;
            labeledDivider1.Text = "Disclaimer:";
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(53, 135);
            label9.Name = "label9";
            label9.Size = new Size(609, 63);
            label9.TabIndex = 2;
            label9.Text = "The workstation name below is correct, but the memory and processor are hard coded and just for display purposes.";
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(27, 51);
            label8.Name = "label8";
            label8.Size = new Size(654, 63);
            label8.TabIndex = 1;
            label8.Text = resources.GetString("label8.Text");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.HotTrack;
            label7.Location = new Point(25, 7);
            label7.Name = "label7";
            label7.Size = new Size(111, 25);
            label7.TabIndex = 0;
            label7.Text = "Information";
            // 
            // layout
            // 
            layout.ColumnCount = 1;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(panelBottom, 0, 1);
            layout.Controls.Add(panelTop, 0, 0);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 33);
            layout.Margin = new Padding(0);
            layout.Name = "layout";
            layout.RowCount = 2;
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 89F));
            layout.Size = new Size(694, 472);
            layout.TabIndex = 2;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.Transparent;
            panelBottom.Controls.Add(label6);
            panelBottom.Controls.Add(label5);
            panelBottom.Controls.Add(label4);
            panelBottom.Controls.Add(pictureBox1);
            panelBottom.Controls.Add(label3);
            panelBottom.Controls.Add(label2);
            panelBottom.Controls.Add(label1);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panelBottom.Location = new Point(0, 383);
            panelBottom.Margin = new Padding(0);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(694, 89);
            panelBottom.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(186, 53);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 6;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(186, 32);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 5;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(186, 10);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 4;
            label4.Text = "label4";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(13, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.InactiveCaptionText;
            label3.Location = new Point(109, 53);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Processor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.InactiveCaptionText;
            label2.Location = new Point(116, 32);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 1;
            label2.Text = "Memory:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.InactiveCaptionText;
            label1.Location = new Point(95, 10);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Workstation:";
            // 
            // HorizontalPanelExample
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(694, 505);
            Controls.Add(layout);
            MinimumSize = new Size(709, 510);
            Name = "HorizontalPanelExample";
            Padding = new Padding(0, 33, 0, 0);
            Text = "Horizontal panel example";
            Load += HorizontalPanelExample_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelDividers.ResumeLayout(false);
            layout.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label label8;
        private Label label7;
        private Label label9;
        private Inkore.UI.WinForms.Styler.Controls.LabeledDivider labeledDivider1;
        private Panel panelDividers;
        private Inkore.UI.WinForms.Styler.Controls.LabeledDivider labeledDivider4;
        private Inkore.UI.WinForms.Styler.Controls.LabeledDivider labeledDivider3;
        private Inkore.UI.WinForms.Styler.Controls.LabeledDivider labeledDivider2;
        private TableLayoutPanel layout;
        private Inkore.UI.WinForms.Styler.Controls.HorizontalPanel panelBottom;
        private Label label6;
        private Label label5;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Controls.AdvButton advButton1;
    }
}