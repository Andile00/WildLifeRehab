using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Text;

namespace WildLifeRehab
{
    public partial class Form1 : Form
    {
        private readonly AnimalFileService _fileService = new AnimalFileService();
        private List<Animal> _animals = new List<Animal>();

        //Main form for viewing and managing anial records, including adding, searching, deleting, and generating summaries
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        // Sets up the grid, ensures the file exists, and loads data on startup
        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            _fileService.EnsureFileExists();
            RefreshGrid(showSkippedMessage: true);
        }

        // Applies read-only grid settings and defines the 7 columns in the required order
        private void ConfigureGrid()
        {
            dgvAnimals.ReadOnly = true;
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.MultiSelect = false;
            dgvAnimals.AutoGenerateColumns = false;
            dgvAnimals.Columns.Clear();

            AddColumn("Animal ID", nameof(Animal.AnimalId));
            AddColumn("Name", nameof(Animal.Name));
            AddColumn("Species", nameof(Animal.Species));
            AddColumn("Age", nameof(Animal.Age));
            AddColumn("Recovery Score", nameof(Animal.RecoveryScore));
            AddColumn("Status", nameof(Animal.Status));
            AddColumn("Housing Unit", nameof(Animal.HousingUnit));
        }

        // Adds one text column bound to an Animal property
        private void AddColumn(string header, string property)
        {
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = property,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        // Reloads from the file and rebinds the grid, so no duplicate rows appear
        public void RefreshGrid(bool showSkippedMessage = false)
        {
            var result = _fileService.LoadAll();
            _animals = result.Animals;

            dgvAnimals.DataSource = null;
            dgvAnimals.DataSource = _animals;

            if (showSkippedMessage && result.Skipped > 0)
                MessageBox.Show($"{result.Skipped} lines skipped (invalid format).",
                    "Load Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnimalId.Text) ||
               string.IsNullOrWhiteSpace(txtName.Text) ||
               string.IsNullOrWhiteSpace(txtSpecies.Text) ||
               !int.TryParse(txtAge.Text, out int age) ||
               !int.TryParse(txtScore.Text, out int Score))

            {
                MessageBox.Show("Please fill all fields correctly.");
                return;

            }
            var animal = new Animal
            {
                AnimalId = txtAnimalId.Text.Trim().ToUpper(),
                Name = txtName.Text.Trim(),
                Species = txtSpecies.Text.Trim(),
                Age = age,
                RecoveryScore = Score

            };
            // 3. Apply classification (Sets Status and HousingUnit based on score)
            animal.ApplyClassification();

            // 4. Save to the text file using your existing service
            bool success = _fileService.AppendOne(animal);

            if (success)
            {
                MessageBox.Show("Animal added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the input fields for the next entry
                ClearInputs();

                // Refresh the DataGridView to show the new record
                RefreshGrid();
            }
        }

        // Helper method to clear the textboxes
        private void ClearInputs()
        {
            txtAnimalId.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtScore.Clear();
            txtAnimalId.Focus(); // Put cursor back in the first box
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchId = txtSearchId.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(searchId))
            {
                // If search is empty, show all animals
                RefreshGrid();
                return;
            }

            // Find the animal in the loaded list
            var foundAnimal = _animals.FirstOrDefault(a => a.AnimalId == searchId);

            if (foundAnimal != null)
            {
                // Bind a new list containing only the found animal
                dgvAnimals.DataSource = new List<Animal> { foundAnimal };
            }
            else
            {
                MessageBox.Show("Animal not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvAnimals.DataSource = null; // Clear grid if not found
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtSearchId.Clear();
            RefreshGrid(); // Resets the grid to show all animals
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.CurrentRow == null) return;

            var selectedAnimal = dgvAnimals.CurrentRow.DataBoundItem as Animal;
            if (selectedAnimal == null) return;

            var confirm = MessageBox.Show($"Are you sure you want to delete {selectedAnimal.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                _animals.Remove(selectedAnimal);
                _fileService.RewriteAll(_animals); // Rewrite the whole file
                RefreshGrid();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.CurrentRow == null) return;
            var selectedAnimal = dgvAnimals.CurrentRow.DataBoundItem as Animal;

            // Example: Assuming you updated the textboxes with new values
            if (int.TryParse(txtScore.Text, out int newScore))
            {
                selectedAnimal.RecoveryScore = newScore;
                selectedAnimal.ApplyClassification(); // Update status/housing

                _fileService.RewriteAll(_animals);
                RefreshGrid();
                MessageBox.Show("Changes saved!");
            }

        }

        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            // 1. Check if there are any animals to summarize
            if (_animals == null || _animals.Count == 0)
            {
                MessageBox.Show("No animal records available to summarize.", "Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Basic Counts & Averages
            int totalAnimals = _animals.Count;

            // Calculate average age (cast to double so we don't lose decimals)
            double averageAge = _animals.Average(a => a.Age);

            // Calculate average score
            double averageScore = _animals.Average(a => a.RecoveryScore);

            // 3. Count by Status (using System.Linq)
            int criticalCount = _animals.Count
                (a => a.Status == "Critical");
            int seriousCount = _animals.Count
                (a => a.Status == "Serious");
            int stableCount = _animals.Count
                (a => a.Status == "Stable");
            int recoveringCount = _animals.Count
                (a => a.Status == "Recovering");
            int releaseReadyCount = _animals.Count
                (a => a.Status == "Release-Ready");

            // (Optional) You can count the other statuses too if you add labels for them later
            // int recoveringCount = _animals.Count(a => a.Status == "Recovering");
            // int releaseReadyCount = _animals.Count(a => a.Status == "Release-Ready");

            // 4. Update the Labels on the UI
            // Using "N1" or "N2" formatting to show decimals (e.g., 4.5 or 4.50)
            lblTotalAnimals.Text = $"Total Animals: {totalAnimals}";
            lblAverageAge.Text = $"Average Age: {averageAge:F1} years";
            lblAverageScore.Text = $"Average Score: {averageScore:F1}";

            lblCountCritical.Text = $"Critical: {criticalCount}";
            lblCountSerious.Text = $"Serious: {seriousCount}";
            lblCountStable.Text = $"Stable: {stableCount}";
            lblCountRecovering.Text = $"Recovering: {recoveringCount}";
            lblCountReleaseReady.Text = $"Release-Ready: {releaseReadyCount}";

            SaveSummaryToFile();

            // Optional: Show a message box with the summary
            MessageBox.Show($"Summary Generated!\n\nTotal Animals: {totalAnimals}\nAverage Age: {averageAge:F1}\nAverage Score: {averageScore:F1}",
                            "Summary Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveSummaryToFile()
        {
            string summaryPath = Path.Combine(
                AppContext.BaseDirectory,
                "summary.txt");
        
            StringBuilder report = new StringBuilder();
        
            report.AppendLine("BAOBAB RIDGE WILDLIFE REHABILITATION");
            report.AppendLine("SUMMARY REPORT");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}");
            report.AppendLine();
        
            report.AppendLine(
                $"Total Animals: {_animals.Count}");
        
            if (_animals.Count == 0)
            {
                report.AppendLine("Average Age: N/A");
                report.AppendLine("Average Score: N/A");
            }
            
            else
            {
                report.AppendLine(
                    $"Average Age: {_animals.Average(a => a.Age).ToString("F2", CultureInfo.InvariantCulture)}");
        
                report.AppendLine(
                    $"Average Score: {_animals.Average(a => a.RecoveryScore).ToString("F2", CultureInfo.InvariantCulture)}");
            }
        
            report.AppendLine();
        
            report.AppendLine($"Critical: {_animals.Count(a => a.Status == "Critical")}");      
            report.AppendLine($"Serious: {_animals.Count(a => a.Status == "Serious")}");       
            report.AppendLine($"Stable: {_animals.Count(a => a.Status == "Stable")}");        
            report.AppendLine($"Recovering: {_animals.Count(a => a.Status == "Recovering")}");        
            report.AppendLine($"Release-Ready: {_animals.Count(a => a.Status == "Release-Ready")}");
        
            File.WriteAllText(summaryPath, report.ToString());
        }
    }
}
