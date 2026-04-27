namespace SharedLibrary.Models
{
    public class Vitals
    {
        public int Id {  get; set; }
        public int OverPressure { get; set; }
        public int UnderPressure { get; set; }
        public int Puls { get; set; }
        public int RespiratoryRate { get; set; }
        public int OxygenSaturation { get; set; }
        public double Temperature { get; set; }

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
