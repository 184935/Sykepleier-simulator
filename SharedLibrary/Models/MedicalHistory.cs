namespace SharedLibrary.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public List<string> MHistory { get; set; }
        public List<string> SurgicalHistory { get; set; }
        public List<string> SocialHistory { get; set; }
        public List<string> FamHistory { get; set; }

        public MedicalHistory(List<string> history, List<string> surgicalHistory, List<string> socialHistory,
            List<string> famhistory)
        {
            MHistory = history;
            SurgicalHistory = surgicalHistory;
            SocialHistory = socialHistory;
            FamHistory = famhistory;
        }
    }
}
