namespace WildLifeRehab
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtAnimalId = new TextBox();
            txtSearchId = new TextBox();
            txtScore = new TextBox();
            txtAge = new TextBox();
            txtSpecies = new TextBox();
            txtName = new TextBox();
            btnAdd = new Button();
            btnSaveChanges = new Button();
            btnClear = new Button();
            btnSearch = new Button();
            btnDelete = new Button();
            btnGenerateSummary = new Button();
            dgvAnimals = new DataGridView();
            lblAnimalId = new Label();
            lblName = new Label();
            lblSpecies = new Label();
            lblAge = new Label();
            lblScore = new Label();
            lblSearchId = new Label();
            lblTotalAnimals = new Label();
            lblAverageAge = new Label();
            lblAverageScore = new Label();
            lblCountCritical = new Label();
            lblCountSerious = new Label();
            lblCountStable = new Label();
            lblCountRecovering = new Label();
            lblCountReleaseReady = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            SuspendLayout();
            // 
            // txtAnimalId
            // 
            txtAnimalId.Location = new Point(140, 12);
            txtAnimalId.Name = "txtAnimalId";
            txtAnimalId.Size = new Size(125, 27);
            txtAnimalId.TabIndex = 0;
            // 
            // txtSearchId
            // 
            txtSearchId.Location = new Point(140, 307);
            txtSearchId.Name = "txtSearchId";
            txtSearchId.Size = new Size(125, 27);
            txtSearchId.TabIndex = 1;
            // 
            // txtScore
            // 
            txtScore.Location = new Point(140, 250);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(125, 27);
            txtScore.TabIndex = 2;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(140, 177);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(125, 27);
            txtAge.TabIndex = 3;
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(140, 118);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(125, 27);
            txtSpecies.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 59);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(346, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new Point(346, 57);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(94, 29);
            btnSaveChanges.TabIndex = 7;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(346, 118);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(346, 177);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(346, 250);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnGenerateSummary
            // 
            btnGenerateSummary.Location = new Point(346, 307);
            btnGenerateSummary.Name = "btnGenerateSummary";
            btnGenerateSummary.Size = new Size(94, 29);
            btnGenerateSummary.TabIndex = 11;
            btnGenerateSummary.Text = "Summary";
            btnGenerateSummary.UseVisualStyleBackColor = true;
            btnGenerateSummary.Click += btnGenerateSummary_Click;
            // 
            // dgvAnimals
            // 
            dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimals.Location = new Point(475, 18);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.RowHeadersWidth = 51;
            dgvAnimals.Size = new Size(1012, 188);
            dgvAnimals.TabIndex = 12;
            // 
            // lblAnimalId
            // 
            lblAnimalId.AutoSize = true;
            lblAnimalId.Location = new Point(32, 15);
            lblAnimalId.Name = "lblAnimalId";
            lblAnimalId.Size = new Size(75, 20);
            lblAnimalId.TabIndex = 13;
            lblAnimalId.Text = "Animal ID";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(32, 62);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 12;
            lblName.Text = "Name";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(32, 121);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(59, 20);
            lblSpecies.TabIndex = 11;
            lblSpecies.Text = "Species";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(32, 180);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(36, 20);
            lblAge.TabIndex = 10;
            lblAge.Text = "Age";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(32, 253);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(110, 20);
            lblScore.TabIndex = 9;
            lblScore.Text = "Recovery Score";
            // 
            // lblSearchId
            // 
            lblSearchId.AutoSize = true;
            lblSearchId.Location = new Point(32, 310);
            lblSearchId.Name = "lblSearchId";
            lblSearchId.Size = new Size(92, 20);
            lblSearchId.TabIndex = 8;
            lblSearchId.Text = "Search by ID";
            // 
            // lblTotalAnimals
            // 
            lblTotalAnimals.AutoSize = true;
            lblTotalAnimals.Location = new Point(475, 230);
            lblTotalAnimals.Name = "lblTotalAnimals";
            lblTotalAnimals.Size = new Size(114, 20);
            lblTotalAnimals.TabIndex = 7;
            lblTotalAnimals.Text = "Total Animals: 0";
            // 
            // lblAverageAge
            // 
            lblAverageAge.AutoSize = true;
            lblAverageAge.Location = new Point(475, 257);
            lblAverageAge.Name = "lblAverageAge";
            lblAverageAge.Size = new Size(129, 20);
            lblAverageAge.TabIndex = 6;
            lblAverageAge.Text = "Average Age: N/A";
            // 
            // lblAverageScore
            // 
            lblAverageScore.AutoSize = true;
            lblAverageScore.Location = new Point(475, 284);
            lblAverageScore.Name = "lblAverageScore";
            lblAverageScore.Size = new Size(139, 20);
            lblAverageScore.TabIndex = 5;
            lblAverageScore.Text = "Average Score: N/A";
            // 
            // lblCountCritical
            // 
            lblCountCritical.AutoSize = true;
            lblCountCritical.Location = new Point(475, 311);
            lblCountCritical.Name = "lblCountCritical";
            lblCountCritical.Size = new Size(70, 20);
            lblCountCritical.TabIndex = 4;
            lblCountCritical.Text = "Critical: 0";
            // 
            // lblCountSerious
            // 
            lblCountSerious.AutoSize = true;
            lblCountSerious.Location = new Point(475, 338);
            lblCountSerious.Name = "lblCountSerious";
            lblCountSerious.Size = new Size(72, 20);
            lblCountSerious.TabIndex = 3;
            lblCountSerious.Text = "Serious: 0";
            // 
            // lblCountStable
            // 
            lblCountStable.AutoSize = true;
            lblCountStable.Location = new Point(475, 365);
            lblCountStable.Name = "lblCountStable";
            lblCountStable.Size = new Size(66, 20);
            lblCountStable.TabIndex = 2;
            lblCountStable.Text = "Stable: 0";
            // 
            // lblCountRecovering
            // 
            lblCountRecovering.AutoSize = true;
            lblCountRecovering.Location = new Point(620, 311);
            lblCountRecovering.Name = "lblCountRecovering";
            lblCountRecovering.Size = new Size(98, 20);
            lblCountRecovering.TabIndex = 1;
            lblCountRecovering.Text = "Recovering: 0";
            // 
            // lblCountReleaseReady
            // 
            lblCountReleaseReady.AutoSize = true;
            lblCountReleaseReady.Location = new Point(620, 338);
            lblCountReleaseReady.Name = "lblCountReleaseReady";
            lblCountReleaseReady.Size = new Size(122, 20);
            lblCountReleaseReady.TabIndex = 0;
            lblCountReleaseReady.Text = "Release-Ready: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1527, 672);
            Controls.Add(lblCountReleaseReady);
            Controls.Add(lblCountRecovering);
            Controls.Add(lblCountStable);
            Controls.Add(lblCountSerious);
            Controls.Add(lblCountCritical);
            Controls.Add(lblAverageScore);
            Controls.Add(lblAverageAge);
            Controls.Add(lblTotalAnimals);
            Controls.Add(lblSearchId);
            Controls.Add(lblScore);
            Controls.Add(lblAge);
            Controls.Add(lblSpecies);
            Controls.Add(lblName);
            Controls.Add(lblAnimalId);
            Controls.Add(dgvAnimals);
            Controls.Add(btnGenerateSummary);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnAdd);
            Controls.Add(txtName);
            Controls.Add(txtSpecies);
            Controls.Add(txtAge);
            Controls.Add(txtScore);
            Controls.Add(txtSearchId);
            Controls.Add(txtAnimalId);
            Name = "Form1";
            Text = "Baobab Ridge Wildlife Rehabilitation";
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAnimalId;
        private TextBox txtSearchId;
        private TextBox txtScore;
        private TextBox txtAge;
        private TextBox txtSpecies;
        private TextBox txtName;
        private Button btnAdd;
        private Button btnSaveChanges;
        private Button btnClear;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnGenerateSummary;
        private DataGridView dgvAnimals;
        private Label lblAnimalId;
        private Label lblName;
        private Label lblSpecies;
        private Label lblAge;
        private Label lblScore;
        private Label lblSearchId;
        private Label lblTotalAnimals;
        private Label lblAverageAge;
        private Label lblAverageScore;
        private Label lblCountCritical;
        private Label lblCountSerious;
        private Label lblCountStable;
        private Label lblCountRecovering;
        private Label lblCountReleaseReady;
    }
}