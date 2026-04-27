namespace SharedLibrary.Models
{
    public class Case
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Vitals Vitals { get; set; }
        public List<Medication> Medications { get; set; }
        public List<Allergy> Allergies { get; set; }
        public List<Diagnosis> Diagnoses { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public bool Editable { get; set; }
        public List<User> TestUsers { get; set; }
        public Difficulty Difficulty { get; set; }

        public Case(Patient patient, Vitals vitals, List<Medication> meds, List<Allergy> allergies,
            List<Diagnosis> diagnoses, MedicalHistory medHis, bool editable, List<User> testUsers, Difficulty diff)
        {
            Patient = patient;
            Vitals = vitals;
            Medications = meds;
            Allergies = allergies;
            Diagnoses = diagnoses;
            MedicalHistory = medHis;
            Editable = editable;
            TestUsers = testUsers;
            Difficulty = diff;
        }
    }
}
