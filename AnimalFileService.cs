using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// handles raeding and writing the animals.txt file, including parsing and formatting lines
namespace WildLifeRehab
{
    public class AnimalFileService
    {
        private const int FieldCount = 7;
        private static readonly Regex IdPattern = new Regex(@"^WR-\d{4}$");

        // Full path to animals.txt, built from the app's folder (never hard-coded)
        public string FilePath { get; } =
            Path.Combine(AppContext.BaseDirectory, "animals.txt");

        // Creates an empty animals.txt if it is missing so startup never crashes
        public void EnsureFileExists()
        {
            try
            {
                if (!File.Exists(FilePath))
                    File.WriteAllText(FilePath, string.Empty);
            }
            catch (Exception ex) when (IsFileError(ex))
            {
                ShowError("create", ex);
            }
        }

        // Reads every line, builds an Animal per valid line, and counts skipped lines
        public (List<Animal> Animals, int Skipped) LoadAll()
        {
            var animals = new List<Animal>();
            int skipped = 0;

            try
            {
                foreach (string line in File.ReadAllLines(FilePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    Animal animal = ParseLine(line);
                    if (animal == null) skipped++;
                    else animals.Add(animal);
                }
            }
            catch (Exception ex) when (IsFileError(ex))
            {
                ShowError("read", ex);
            }

            return (animals, skipped);
        }

        // Adds one line to the end of the file without touching existing lines
        public bool AppendOne(Animal animal)
        {
            try
            {
                File.AppendAllText(FilePath, ToLine(animal) + Environment.NewLine);
                return true;
            }
            catch (Exception ex) when (IsFileError(ex))
            {
                ShowError("save to", ex);
                return false;
            }
        }

        // Writes the whole list back to the file, one line per animal (used by Update and Delete)
        public bool RewriteAll(List<Animal> animals)
        {
            try
            {
                var lines = new List<string>();
                foreach (Animal a in animals) lines.Add(ToLine(a));
                File.WriteAllLines(FilePath, lines);
                return true;
            }
            catch (Exception ex) when (IsFileError(ex))
            {
                ShowError("update", ex);
                return false;
            }
        }

        // Converts one file line into an Animal, recalculating status so the file can never show a wrong one
        private Animal ParseLine(string line)
        {
            string[] p = line.Split('|');
            if (p.Length != FieldCount) return null;

            string id = p[0].Trim().ToUpper();
            if (!IdPattern.IsMatch(id)) return null;

            if (!int.TryParse(p[3].Trim(), out int age) || age < 0 || age > 100) return null;
            if (!int.TryParse(p[4].Trim(), out int score) || score < 0 || score > 100) return null;

            var animal = new Animal
            {
                AnimalId = id,
                Name = p[1].Trim(),
                Species = p[2].Trim(),
                Age = age,
                RecoveryScore = score
            };
            animal.ApplyClassification();
            return animal;
        }

        // Converts an Animal into one pipe-delimited file line
        private string ToLine(Animal a)
        {
            return string.Join("|", a.AnimalId, a.Name, a.Species,
                a.Age, a.RecoveryScore, a.Status, a.HousingUnit);
        }

        // Returns true for the file exceptions we handle with friendly messages
        private bool IsFileError(Exception ex)
        {
            return ex is IOException
                || ex is UnauthorizedAccessException
                || ex is DirectoryNotFoundException;
        }

        // Shows a friendly message instead of a stack trace
        private void ShowError(string action, Exception ex)
        {
            string reason = ex is UnauthorizedAccessException
                ? "The file is read-only or access was denied."
                : "The file may be open in another program or missing.";

            MessageBox.Show($"Could not {action} the animal records. {reason}",
                "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}