using System.ComponentModel.DataAnnotations;

namespace CaseSetup.Models
{
    public class Allergy
    {
        [Key]
        private string Allergen { get; set; }
        [Required] [StringLength(150)] 
        private string Reaction { get; set; }

        public Allergy(string allergen, string reaction)
        {
            Allergen = allergen;
            Reaction = reaction;
        }
    }
}
