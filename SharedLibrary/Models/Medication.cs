using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibrary.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dose { get; set; }
        public string Route { get; set; }
        public string Frequency { get; set; }
        public string Notes { get; set; }

        [ForeignKey(nameof(Case))]
        public int CaseId { get; set; }

        public Medication(string name, int dose, string route, string frequency, string notes, int caseId)
        {
            Name = name;
            Dose = dose;
            Route = route;
            Frequency = frequency;
            Notes = notes;
            CaseId = caseId;
        }
    }
}
