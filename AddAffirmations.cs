using MySqlConnector;

namespace AffirmationApp
{
    public partial class AddAffirmations : Form
    {
        private string? category;

        public AddAffirmations()
        {
            InitializeComponent();

            comboBox1AddCategory.Items.Add("Motivation");
            comboBox1AddCategory.Items.Add("Self-Love");
            comboBox1AddCategory.Items.Add("Gratitude");


        }

        public object? affirmationText { get; private set; }

        private void button1Submit_Click(object sender, EventArgs e)
        {



            //// gets values from the TextBox and ComboBox
            string affirmationText = textBox1Add.Text.Trim();
            string category = comboBox1AddCategory.SelectedItem?.ToString(); // retrieves  selected category

            // Validates input
            if (string.IsNullOrEmpty((string?)affirmationText) || string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please enter both an affirmation and select a category.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DATABASE CONNECTION 
            using (var connection = new MySqlConnection("Server=localhost;Database=affirmationapp;User=wavy_user;Password=wavy_password;"))
            {
                try
                {
                    connection.Open(); //Open

                    // INSERT SQL query
                    var cmd = new MySqlCommand("INSERT INTO affirmations (AffirmationText, Category, DateAdded) VALUES (@text, @category, NOW())", connection);
                    cmd.Parameters.AddWithValue("@text", affirmationText);
                    _ = cmd.Parameters.AddWithValue("@category", comboBox1AddCategory_SelectedIndexChanged);


                    cmd.ExecuteNonQuery();

                    // Confirm success to the user
                    MessageBox.Show("Affirmation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // clear
                    textBox1Add.Clear();
                    comboBox1AddCategory.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    // handle errors 

                    MessageBox.Show($"Error adding affirmation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddAffirmations_Load(object sender, EventArgs e)
        {
            try
            {
                //combo box categories
                comboBox1AddCategory.Items.Clear();
                comboBox1AddCategory.Items.Add("Motivation");
                comboBox1AddCategory.Items.Add("Self-Love");
                comboBox1AddCategory.Items.Add("Gratitude");

                // show  first category as defualt 
                if (comboBox1AddCategory.Items.Count > 0)
                {
                    comboBox1AddCategory.SelectedIndex = 0;
                }

                // Clears the TextBox for new  data input
                textBox1Add.Clear();

                
                MessageBox.Show("Form loaded successfully. You can now add affirmations!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle load errora
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
