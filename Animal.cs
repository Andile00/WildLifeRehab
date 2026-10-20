using System;

namespace WildLifeRehab
{
    // Represents one animal record in the rehabilitation centre
    public class Animal
    {
        public string AnimalId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; set; } = string.Empty;
        public string HousingUnit { get; set; } = string.Empty;

        // Returns the status and housing unit for a recovery score (the only classifier in the app)
        public static (string Status, string HousingUnit) Classify(int score)
        {
            if (score < 0 || score > 100)
                throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100.");

            if (score <= 19) return ("Critical", "Intensive Care Unit");
            if (score <= 39) return ("Serious", "High-Dependency Ward");
            if (score <= 59) return ("Stable", "Recovery Ward");
            if (score <= 79) return ("Recovering", "Outdoor Enclosure");
            return ("Release-Ready", "Pre-Release Camp");
        }

        // Sets Status and HousingUnit from the current RecoveryScore
        public void ApplyClassification()
        {
            var result = Classify(RecoveryScore);
            Status = result.Status;
            HousingUnit = result.HousingUnit;
        }
    }
}