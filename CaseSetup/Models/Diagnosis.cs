namespace CaseSetup.Models
{
    public class Diagnosis
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Treatment { get; set; }

        public Diagnosis(string name, string description, string treatment)
        {
            Name = name;
            Description = description;
            Treatment = treatment;
        }
    }
}
