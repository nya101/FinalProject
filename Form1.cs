using MySqlConnector;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AffirmationApp
{
    public partial class Form1 : Form
    {
        private DashboardForm dashboard;

        public Form1()
        {
            InitializeComponent();

            comboFilter.Items.Add("All");
            comboFilter.Items.Add("Motivation");
            comboFilter.Items.Add("Self-Love");
            comboFilter.Items.Add("Gratitude");
            comboFilter.SelectedIndex = 0; // Defaults to "All categories "

            LoadAffirmationCards();
        }




        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedCategory = comboFilter.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "combofilter" && selectedCategory != "All")
            {
                // Clears flow layout panel to showcase results
                flowLayoutPanel1.Controls.Clear();

                // Filter based on affirmation category 
                using (var connection = new MySqlConnection("Server=localhost;Database=affirmationapp;User=wavy_user;Password=wavy_password;"))
                {
                    try
                    {
                        connection.Open();
                        var cmd = new MySqlCommand("SELECT Id, AffirmationText, Category, DateAdded FROM affirmations WHERE Category = @category", connection);
                        cmd.Parameters.AddWithValue("@category", selectedCategory);

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Panel card = new Panel
                            {
                                Width = 300,
                                Height = 150,
                                BackColor = Color.White,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(10)
                            };

                            Label lblText = new Label
                            {
                                Text = reader["AffirmationText"].ToString(),
                                Dock = DockStyle.Top,
                                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                AutoSize = false,
                                Height = 60,
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            Label lblCategory = new Label
                            {
                                Text = $"Category: {reader["Category"]}",
                                Dock = DockStyle.Top,
                                Font = new Font("Segoe UI", 9),
                                ForeColor = Color.Gray,
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            Label lblDate = new Label
                            {
                                Text = $"Added: {reader["DateAdded"]}",
                                Dock = DockStyle.Bottom,
                                Font = new Font("Segoe UI", 8),
                                ForeColor = Color.DarkGray,
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            Button btnDelete = new Button
                            {
                                Text = "Delete",
                                Dock = DockStyle.Bottom,
                                Height = 30
                            };

                            btnDelete.Click += (s, ev) =>
                            {
                                int id = Convert.ToInt32(reader["Id"]);
                                DeleteAffirmation(id);
                            };

                            card.Controls.Add(lblDate);
                            card.Controls.Add(lblCategory);
                            card.Controls.Add(lblText);
                            card.Controls.Add(btnDelete);

                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error filtering affirmations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // will load  all affirmations if "All" is selected or there is  no valid selection
                LoadAffirmationCards();
            }
        }



        // Display affirmations in card form in the flowlayout panel
        private void LoadAffirmationCards()
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing cards

            using (var connection = new MySqlConnection("Server=localhost;Database=affirmationapp;User=wavy_user;Password=wavy_password;"))
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT Id, AffirmationText, Category, DateAdded FROM affirmations", connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Capture the affirmation ID
                    int affirmationId = Convert.ToInt32(reader["Id"]);

                    // Card panel
                    Panel card = new Panel
                    {
                        Width = 300,
                        Height = 150,
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10)
                    };

                    //  affirmation text
                    Label lblText = new Label
                    {
                        Text = reader["AffirmationText"].ToString(),
                        Dock = DockStyle.Top,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        AutoSize = false,
                        Height = 60,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    // category label
                    Label lblCategory = new Label
                    {
                        Text = $"Category: {reader["Category"]}",
                        Dock = DockStyle.Top,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gray,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    // date label
                    Label lblDate = new Label
                    {
                        Text = $"Added: {reader["DateAdded"]}",
                        Dock = DockStyle.Bottom,
                        Font = new Font("Segoe UI", 8),
                        ForeColor = Color.DarkGray,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    //  delete button
                    Button btnDelete = new Button
                    {
                        Text = "Delete",
                        Dock = DockStyle.Bottom,
                        Height = 30
                    };

                    // Affirmation ID attach  to the button click event
                    btnDelete.Click += (s, e) =>
                    {
                        DeleteAffirmation(affirmationId);
                    };

                    // labels
                    card.Controls.Add(lblDate);
                    card.Controls.Add(lblCategory);
                    card.Controls.Add(lblText);
                    card.Controls.Add(btnDelete);

                    // card to flowlayout panel
                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }


        // Add new affirmations
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string affirmationText = txtAffirmation.Text;
            string category = comboCategory.Text;

            if (string.IsNullOrWhiteSpace(affirmationText) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please enter both an affirmation and a category.");
                return;
            }

            using (var connection = new MySqlConnection("Server=localhost;Database=affirmationapp;User=wavy_user;Password=wavy_password;"))
            {
                try
                {
                    connection.Open();
                    var cmd = new MySqlCommand("INSERT INTO affirmations (AffirmationText, Category) VALUES (@text, @category)", connection);
                    cmd.Parameters.AddWithValue("@text", affirmationText);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Affirmation added successfully!");
                    LoadAffirmationCards(); // Refresh the cards
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding affirmation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Delete affirmations
        private void DeleteAffirmation(int id)
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=affirmationapp;User=wavy_user;Password=wavy_password;"))
            {
                try
                {
                    connection.Open();
                    var cmd = new MySqlCommand("DELETE FROM affirmations WHERE Id = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Affirmation deleted successfully!");
                    LoadAffirmationCards(); // Refresh the cards
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting affirmation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Search for affirmations
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            flowLayoutPanel1.Controls.Clear();

            using (var connection = new MySqlConnection("Server=localhost;Database=affirmationapp;User=wavy_user;Password=wavy_password;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Id, AffirmationText, Category, DateAdded FROM affirmations WHERE AffirmationText LIKE @keyword";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // create/dispaly cards
                        Panel card = new Panel
                        {
                            Width = 300,
                            Height = 150,
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(10)
                        };

                        Label lblText = new Label
                        {
                            Text = reader["AffirmationText"].ToString(),
                            Dock = DockStyle.Top,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            AutoSize = false,
                            Height = 60,
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        Label lblCategory = new Label
                        {
                            Text = $"Category: {reader["Category"]}",
                            Dock = DockStyle.Top,
                            Font = new Font("Segoe UI", 9),
                            ForeColor = Color.Gray,
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        Label lblDate = new Label
                        {
                            Text = $"Added: {reader["DateAdded"]}",
                            Dock = DockStyle.Bottom,
                            Font = new Font("Segoe UI", 8),
                            ForeColor = Color.DarkGray,
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        Button btnDelete = new Button
                        {
                            Text = "Delete",
                            Dock = DockStyle.Bottom,
                            Height = 30
                        };

                        btnDelete.Click += (s, e) =>
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            DeleteAffirmation(id);
                        };

                        card.Controls.Add(lblDate);
                        card.Controls.Add(lblCategory);
                        card.Controls.Add(lblText);
                        card.Controls.Add(btnDelete);

                        flowLayoutPanel1.Controls.Add(card);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching affirmations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadAffirmationCards();
        }

       
    }


}

    