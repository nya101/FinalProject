namespace AffirmationApp
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            labelDashboard = new Label();
            lblTotalAffirmations = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // labelDashboard
            // 
            labelDashboard.AutoSize = true;
            labelDashboard.BackColor = Color.Thistle;
            labelDashboard.Location = new Point(21, 12);
            labelDashboard.Name = "labelDashboard";
            labelDashboard.Size = new Size(64, 15);
            labelDashboard.TabIndex = 0;
            labelDashboard.Text = "Dashboard";
            // 
            // lblTotalAffirmations
            // 
            lblTotalAffirmations.AutoSize = true;
            lblTotalAffirmations.BackColor = Color.Thistle;
            lblTotalAffirmations.Location = new Point(805, 34);
            lblTotalAffirmations.Name = "lblTotalAffirmations";
            lblTotalAffirmations.Size = new Size(98, 15);
            lblTotalAffirmations.TabIndex = 1;
            lblTotalAffirmations.Text = "TotalAffirmations";
            // 
            // button1
            // 
            button1.BackColor = Color.Thistle;
            button1.Location = new Point(12, 106);
            button1.Name = "button1";
            button1.Size = new Size(216, 140);
            button1.TabIndex = 2;
            button1.Text = "Manage Affirmations";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(942, 661);
            Controls.Add(button1);
            Controls.Add(lblTotalAffirmations);
            Controls.Add(labelDashboard);
            ForeColor = SystemColors.WindowText;
            Name = "DashboardForm";
            Text = "DashboardForm";
            Load += DashboardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDashboard;
        private Label lblTotalAffirmations;
        private Button button1;
    }
}