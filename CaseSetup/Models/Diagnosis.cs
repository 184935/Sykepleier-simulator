using System.ComponentModel.DataAnnotations;

namespace CaseSetup.Models
{
    public class Diagnosis
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Treatment { get; set; }

        public Diagnosis(string name, string description, string treatment)
        {
            Name = name;
            Description = description;
            Treatment = treatment;
        }
    }
}
