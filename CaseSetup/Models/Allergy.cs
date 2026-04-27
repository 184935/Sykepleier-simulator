namespace CaseSetup.Models
{
    public class Allergy
    {
        private string Allergen { get; set; }
        private string Reaction { get; set; }

        public Allergy(string allergen, string reaction)
        {
            Allergen = allergen;
            Reaction = reaction;
        }
    }
}
