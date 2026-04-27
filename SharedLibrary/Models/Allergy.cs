using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Allergy
    {
        [Key]
        public string Allergen { get; set; }
        [Required] [StringLength(150)] 
        public string Reaction { get; set; }

        public Allergy(string allergen, string reaction)
        {
            Allergen = allergen;
            Reaction = reaction;
        }
    }
}
