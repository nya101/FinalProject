using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace AffirmationApp
{
    public partial class DashboardForm : Form
    {
        private Form1 form1;
        public DashboardForm(Form1 mainForm)
        {
            InitializeComponent();
            LoadStatistics();

            form1 = mainForm;

        }

        private void LoadStatistics()
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=affirmationapp;User=wavy_user;Password=wavy_password;"))
            {
                try
                {
                    connection.Open();
                    var cmd = new MySqlCommand("SELECT COUNT(*) FROM affirmations", connection);
                    int totalAffirmations = Convert.ToInt32(cmd.ExecuteScalar());
                    lblTotalAffirmations.Text = $"Total Affirmations: {totalAffirmations}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnManageAffirmations_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 affirmationsForm = new Form1();

            // Show Form1
            affirmationsForm.Show();

            // hide or close the current dashboard
            this.Hide();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }
    }

}