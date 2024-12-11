
namespace AffirmationApp
{
    partial class AddAffirmations
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
            comboBox1AddCategory = new ComboBox();
            button1Submit = new Button();
            SuspendLayout();
            // 
            // AddCategory combo box
            // 
            comboBox1AddCategory.FormattingEnabled = true;
            comboBox1AddCategory.Location = new Point(236, 84);
            comboBox1AddCategory.Name = "comboBox1AddCategory";
            comboBox1AddCategory.Size = new Size(121, 23);
            comboBox1AddCategory.TabIndex = 1;
            comboBox1AddCategory.Text = "AddCategory";
            comboBox1AddCategory.SelectedIndexChanged += comboBox1AddCategory_SelectedIndexChanged;
            // 
            // Submit button
            // 
            button1Submit.Location = new Point(412, 84);
            button1Submit.Name = "button1Submit";
            button1Submit.Size = new Size(75, 23);
            button1Submit.TabIndex = 2;
            button1Submit.Text = "Submit";
            button1Submit.UseVisualStyleBackColor = true;
            button1Submit.Click += button1Submit_Click;
            // 
            // AddAffirmations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1Submit);
            Controls.Add(comboBox1AddCategory);
            Name = "AddAffirmations";
            Text = "AddAffirmations";
            Load += AddAffirmations_Load;
            ResumeLayout(false);
        }

        private void comboBox1AddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox textBox1;

        public TextBox textBox1Add { get; private set; }

        private ComboBox comboBox1AddCategory;
        private Button button1Submit;
    }
}