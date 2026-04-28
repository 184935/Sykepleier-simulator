using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibrary.Models
{
    public class Allergy
    {
        [Key]
        public string Allergen { get; set; }
        [Required] [StringLength(150)] 
        public string Reaction { get; set; }

        [ForeignKey(nameof(Case))]
        public int CaseId { get; set; }

        public Allergy(string allergen, string reaction)
        {
            Allergen = allergen;
            Reaction = reaction;
        }
    }
}
