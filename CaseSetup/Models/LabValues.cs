namespace CaseSetup.Models
{
    public class LabValues
    {
        private double BloodSugar { get; set; }
        private int Creatinine { get; set; }
        private int Sodium { get; set; }
        private double Potassium { get; set; }

        public LabValues(double bloodsugar, int creatinine, int sodium, double potassium)
        {
            BloodSugar = bloodsugar;
            Creatinine = creatinine;
            Sodium = sodium;
            Potassium = potassium;
        }
    }
}
