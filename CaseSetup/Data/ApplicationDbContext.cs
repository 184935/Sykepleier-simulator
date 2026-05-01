using CaseSetup.Areas.Identity.Data;
using CaseSetup.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using System.Text.Json;

namespace CaseSetup.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<SharedLibrary.Models.Case> Cases { get; set; } = default!;
        public DbSet<SharedLibrary.Models.Allergy> Allergies { get; set; } = default!;
        public DbSet<SharedLibrary.Models.Diagnosis> Diagnosis { get; set; } = default!;
        public DbSet<SharedLibrary.Models.LabValues> LabValues {  get; set; } = default!;
        public DbSet<SharedLibrary.Models.MedicalHistory> MedHistory {  get; set; } = default!;
        public DbSet<SharedLibrary.Models.Medication> Medications {  get; set; } = default!;
        public DbSet<SharedLibrary.Models.Patient> Patients {  get; set; } = default!;
        public DbSet<SharedLibrary.Models.Vitals> Vitals {  get; set; } = default!;
        public DbSet<User> Users {  get; set; } = default!;
        public DbSet<Goal> Goals { get; set; } = default!;
        public DbSet<Event> Events {  get; set; } = default!;
        public DbSet<Comment> Comments {  get; set; } = default!; 
        public DbSet<Debrief> Debriefs {  get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MedicalHistory>(ent =>
            {
                ent.Property(e => e.MHistory).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                        );

                ent.Property(e => e.SurgicalHistory).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                    );
                ent.Property(e => e.SocialHistory).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                    );
                ent.Property(e => e.FamHistory).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                    );
            });


        }

        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (context.Cases.Any()) return;

            // Patients
            var patient1 = new Patient("Erik Hansen", 45, "Male", 82.5);
            var patient2 = new Patient("Ingrid Larsen", 62, "Female", 68.0);
            var patient3 = new Patient("Ole Bergström", 31, "Male", 95.0);
            var patient4 = new Patient("Astrid Nygaard", 54, "Female", 74.0);
            var patient5 = new Patient("Bjørn Solberg", 38, "Male", 88.0);

            context.Patients.AddRange(patient1, patient2, patient3, patient4, patient5);
            await context.SaveChangesAsync();

            // Vitals
            // Case 1 - abnormal temperature (fever 39.4)
            var vitals1 = new Vitals(125, 78, 98, 20, 96, 39.4);
            // Case 2 - high blood pressure (hypertensive 168/105)
            var vitals2 = new Vitals(168, 105, 88, 18, 97, 37.1);
            // Case 3 - low blood pressure (hypotensive 82/48)
            var vitals3 = new Vitals(82, 48, 112, 22, 94, 36.9);
            // Case 4 - both abnormal BP and abnormal temperature (high BP + hypothermia 35.1)
            var vitals4 = new Vitals(172, 108, 76, 16, 95, 35.1);
            // Case 5 - normal across the board for contrast
            var vitals5 = new Vitals(118, 76, 72, 16, 98, 36.8);

            context.Vitals.AddRange(vitals1, vitals2, vitals3, vitals4, vitals5);
            await context.SaveChangesAsync();

            // LabValues
            LabValues labs1 = new LabValues(7.2, 110, 138, 3.8);
            LabValues labs2 = new LabValues(11.4, 145, 132, 3.2);
            LabValues labs3 = new LabValues(3.8, 88, 141, 4.1);
            LabValues labs4 = new LabValues(9.1, 132, 135, 3.5);
            LabValues labs5 = new LabValues(5.1, 92, 140, 4.0);

            context.LabValues.AddRange(labs1, labs2, labs3, labs4, labs5);
            await context.SaveChangesAsync();

            // MedicalHistory
            var history1 = new MedicalHistory(
                new List<string> { "Type 2 Diabetes", "Hypertension" },
                new List<string> { "Appendectomy 2010" },
                new List<string> { "Smoker 10 years, quit 2018" },
                new List<string> { "Father had MI" }
            );
            var history2 = new MedicalHistory(
                new List<string> { "Hypertension", "Obesity" },
                new List<string> { "None" },
                new List<string> { "Sedentary lifestyle, non-smoker" },
                new List<string> { "Father had stroke, mother hypertensive" }
            );
            var history3 = new MedicalHistory(
                new List<string> { "Septic shock", "Previous DVT" },
                new List<string> { "Splenectomy 2015" },
                new List<string> { "Non-smoker, no alcohol" },
                new List<string> { "No significant family history" }
            );
            var history4 = new MedicalHistory(
                new List<string> { "Hypertension", "Hypothyroidism" },
                new List<string> { "Hip replacement 2020" },
                new List<string> { "Occasional alcohol, non-smoker" },
                new List<string> { "Mother had MI" }
            );
            var history5 = new MedicalHistory(
                new List<string> { "Asthma" },
                new List<string> { "None" },
                new List<string> { "Non-smoker, exercises regularly" },
                new List<string> { "No significant family history" }
            );

            context.MedHistory.AddRange(history1, history2, history3, history4, history5);
            await context.SaveChangesAsync();

            // Goals

            Goal StabUnderP = new Goal("Stabalize underpressure", 80, 60, 5000);
            Goal StabOverP = new Goal("Stabalize overpressure", 120, 90, 5000);
            Goal StabTemp = new Goal("Stabalize temperature", 38, 36, 10000);
            List<Goal> Goals2 = [StabOverP, StabUnderP, StabTemp];
            context.Goals.AddRange(Goals2);
            await context.SaveChangesAsync();

            // Cases
            var case1 = new Case(patient1.Id, vitals1.Id, history1.Id, true, 0);  // Easy - fever
            var case2 = new Case(patient2.Id, vitals2.Id, history2.Id, false, 1); // Intermediate - high BP
            var case3 = new Case(patient3.Id, vitals3.Id, history3.Id, false, 2); // Hard - low BP
            var case4 = new Case(patient4.Id, vitals4.Id, history4.Id, false, 2); // Hard - high BP + hypothermia
            var case5 = new Case(patient5.Id, vitals5.Id, history5.Id, true, 0);  // Easy - all normal
            case1.Goals = Goals2;
            case2.Goals = Goals2;
            case3.Goals = Goals2;
            case4.Goals = Goals2;
            case5.Goals = Goals2;
            context.Cases.AddRange(case1, case2, case3, case4, case5);
            await context.SaveChangesAsync();

            // Medications
            var medications = new List<Medication>
    {
        new Medication("Paracetamol", 1000, "Oral", "Every 6 hours", "For fever management", case1.Id),
        new Medication("Metformin", 500, "Oral", "Twice daily", "Take with food", case1.Id),
        new Medication("Amlodipine", 10, "Oral", "Once daily", "Monitor blood pressure", case2.Id),
        new Medication("Lisinopril", 20, "Oral", "Once daily", "Check renal function", case2.Id),
        new Medication("Norepinephrine", 8, "IV", "Continuous infusion", "Titrate to MAP >65", case3.Id),
        new Medication("NaCl 0.9%", 500, "IV", "500ml bolus", "Fluid resuscitation", case3.Id),
        new Medication("Amlodipine", 10, "Oral", "Once daily", "Monitor BP closely", case4.Id),
        new Medication("Levothyroxine", 50, "Oral", "Once daily", "Take on empty stomach", case4.Id),
        new Medication("Salbutamol", 100, "Inhaled", "As needed", "Rescue inhaler", case5.Id)
    };

            context.Medications.AddRange(medications);
            await context.SaveChangesAsync();

            // Allergies
            var allergies = new List<Allergy>
    {
        new Allergy("Penicillin", "Anaphylaxis - severe rash and swelling") { CaseId = case1.Id },
        new Allergy("Shellfish", "Hives and difficulty breathing") { CaseId = case2.Id },
        new Allergy("Aspirin", "Bronchospasm and urticaria") { CaseId = case3.Id },
        new Allergy("Sulfonamides", "Severe skin rash") { CaseId = case4.Id }
    };

            context.Allergies.AddRange(allergies);
            await context.SaveChangesAsync();

            // Diagnoses
            var diagnoses = new List<Diagnosis>
    {
        new Diagnosis("Urinary Tract Infection",
            "Bacterial infection causing fever and systemic inflammation",
            "Antipyretics, antibiotics after culture results, increased fluid intake")
            { CaseId = case1.Id },
        new Diagnosis("Hypertensive Crisis",
            "Severely elevated blood pressure requiring immediate intervention",
            "IV antihypertensives, strict BP monitoring, reduce MAP gradually")
            { CaseId = case2.Id },
        new Diagnosis("Septic Shock",
            "Life threatening organ dysfunction caused by dysregulated host response to infection",
            "Fluid resuscitation, vasopressors, broad spectrum antibiotics, ICU admission")
            { CaseId = case3.Id },
        new Diagnosis("Hypertensive Emergency with Hypothermia",
            "Combination of severely elevated BP and dangerously low body temperature",
            "Gradual rewarming, IV antihypertensives, continuous monitoring")
            { CaseId = case4.Id },
        new Diagnosis("Mild Asthma",
            "Chronic airway inflammation with normal vitals on presentation",
            "Salbutamol as needed, review inhaler technique, follow up with GP")
            { CaseId = case5.Id }
    };

            context.Diagnosis.AddRange(diagnoses);
            await context.SaveChangesAsync();
        }
    }
}
