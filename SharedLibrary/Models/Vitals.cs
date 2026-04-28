namespace SharedLibrary.Models
{
    public class Vitals
    {
        public int Id {  get; set; }
        public int OverPressure { get; set; }
        public int UnderPressure { get; set; }
        public int Pulse { get; set; }
        public int RespiratoryRate { get; set; }
        public int OxygenSaturation { get; set; }
        public double Temperature { get; set; }

        public Vitals(int overPressure, int underPressure, int pulse, int respiratoryRate,
            int oxygenSaturation, double temperature)
        {
            OverPressure = overPressure;
            UnderPressure = underPressure;
            Pulse = pulse;
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
