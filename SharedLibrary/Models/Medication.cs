using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Medication
    {
        [Key]
        public string Name { get; set; }
        public int Dose { get; set; }
        public string Route { get; set; }
        public string Frequency { get; set; }
        public string Notes { get; set; }

        public Medication(string name, int dose, string route, string frequency, string notes)
        {
            Name = name;
            Dose = dose;
            Route = route;
            Frequency = frequency;
            Notes = notes;
        }
    }
}
