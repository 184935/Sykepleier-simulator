namespace SharedLibrary.Models
{
    public class Case
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        
        public int VitalsId { get; set; }

        public int MedicalHistoryId { get; set; }
        
        public virtual List<Medication> Medications { get; set; }
        public virtual List<Allergy> Allergies { get; set; }
        public virtual List<Diagnosis> Diagnoses { get; set; }
        
        public bool Editable { get; set; }
        public virtual List<User> TestUsers { get; set; }

        public int DifficultyInt { get; set; }
        public virtual Difficulty Difficulty { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Vitals Vitals { get; set; }
        public virtual MedicalHistory MedicalHistory { get; set; }

        public Case(int patientId, int vitalsId, int medicalHistoryId, bool editable, int difficultyInt)
        {
            PatientId = patientId;
            VitalsId = vitalsId;
            MedicalHistoryId = medicalHistoryId;
            Editable = editable;
            DifficultyInt = difficultyInt;
        }
    }
}
