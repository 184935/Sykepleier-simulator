using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace CaseSetup.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<SharedLibrary.Models.Case> Case { get; set; } = default!;
        public DbSet<SharedLibrary.Models.Allergy> Allergies { get; set; } = default!;
        public DbSet<SharedLibrary.Models.Diagnosis> Diagnosis { get; set; } = default!;
        public DbSet<SharedLibrary.Models.LabValues> LabValues {  get; set; } = default!;
        public DbSet<SharedLibrary.Models.MedicalHistory> MedHistory {  get; set; } = default!;
        public DbSet<SharedLibrary.Models.Medication> Medications {  get; set; } = default!;
        public DbSet<SharedLibrary.Models.Patient> Patients {  get; set; } = default!;
        public DbSet<SharedLibrary.Models.Vitals> Vitals {  get; set; } = default!;
    }
}
