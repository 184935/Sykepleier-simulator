using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;

namespace CaseSetup.Models
{
    public class Medication
    {
        [Key]
        private string Name { get; set; }
        private int Dose { get; set; }
        private string Route { get; set; }
        private string Frequency { get; set; }
        private string Notes { get; set; }

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
