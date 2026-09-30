using Microsoft.EntityFrameworkCore;
using Patients.Domain;

namespace Patients.Services;

public class PatientsContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Specialty> Specialties => Set<Specialty>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Examination> Examinations => Set<Examination>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();
    public DbSet<Referral> Referrals => Set<Referral>();

    public PatientsContext(DbContextOptions<PatientsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Автоматически находит и применяет все IEntityTypeConfiguration в этой сборке
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientsContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}