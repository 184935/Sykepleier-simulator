namespace CaseSetup.Models
{
    public class Patient
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private int Age { get; set; }
        private string Gender { get; set; }
        private double Weight { get; set; }

        public Patient(string name, int age, string gender, double weight)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
        }
    }
}
