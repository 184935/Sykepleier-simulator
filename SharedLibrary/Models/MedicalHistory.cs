namespace SharedLibrary.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public List<string> MHistory { get; set; }
        public List<string> SurgicalHistory { get; set; }
        public List<string> SocialHistory { get; set; }
        public List<string> FamHistory { get; set; }

        public MedicalHistory(List<string> mHistory, List<string> surgicalHistory, List<string> socialHistory,
            List<string> famHistory)
        {
            MHistory = mHistory;
            SurgicalHistory = surgicalHistory;
            SocialHistory = socialHistory;
            FamHistory = famHistory;
        }
    }
}
