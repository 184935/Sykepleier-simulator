namespace CaseSetup.Models
{
    public class Vitals
    {
        private int Id {  get; set; }
        private int OverPressure { get; set; }
        private int UnderPressure { get; set; }
        private int Puls { get; set; }
        private int RespiratoryRate { get; set; }
        private int OxygenSaturation { get; set; }
        private double Temperature { get; set; }

        public Vitals(int overPressure, int underPressure, int puls, int respiratoryRate,
            int oxygenSaturation, double temperature)
        {
            OverPressure = overPressure;
            UnderPressure = underPressure;
            Puls = puls;
            RespiratoryRate = respiratoryRate;
            OxygenSaturation = oxygenSaturation;
            Temperature = temperature;
        }

        public string BlodPressure()
        {
            return OverPressure + " / " + UnderPressure;
        }

    }

}
