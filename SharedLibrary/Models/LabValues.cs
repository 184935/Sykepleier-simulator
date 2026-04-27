using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class LabValues
    {
        public int Id { get; set; }
        [Required]
        public double BloodSugar { get; set; }
        public int Creatinine { get; set; }
        public int Sodium { get; set; }
        public double Potassium { get; set; }

        public LabValues(double bloodsugar, int creatinine, int sodium, double potassium)
        {
            BloodSugar = bloodsugar;
            Creatinine = creatinine;
            Sodium = sodium;
            Potassium = potassium;
        }
    }
}
