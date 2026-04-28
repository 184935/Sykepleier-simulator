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

        public LabValues(double bloodSugar, int creatinine, int sodium, double potassium)
        {
            BloodSugar = bloodSugar;
            Creatinine = creatinine;
            Sodium = sodium;
            Potassium = potassium;
        }
    }
}
