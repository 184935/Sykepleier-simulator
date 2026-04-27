namespace CaseSetup.Models
{
    public class Case
    {
        private int Id { get; set; }
        private Patient Patient { get; set; }
        private Vitals Vitals { get; set; }
        private List<Medication> Medications { get; set; }
        private List<Allergy> Allergies { get; set; }
        private List<Diagnosis> Diagnoses { get; set; }
        private MedicalHistory MedicalHistory { get; set; }
        private bool Editable { get; set; }
        private List<User> TestUsers { get; set; }
        private Difficulty Difficulty { get; set; }

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
