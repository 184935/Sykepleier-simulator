namespace CaseSetup.Models
{
    public class MedicalHistory
    {
        private List<string> MHistory { get; set; }
        private List<string> SurgicalHistory { get; set; }
        private List<string> SocialHistory { get; set; }
        private List<string> FamHistory { get; set; }

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
