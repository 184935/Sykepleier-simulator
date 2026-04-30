using CaseSetup.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using System.Text.Json;

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
        public DbSet<User> Users {  get; set; } = default!;

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
    }
}
