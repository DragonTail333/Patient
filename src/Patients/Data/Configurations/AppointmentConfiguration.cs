using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patients.Data.Configurations.Common;
using Patients.Domain;
using Patients.Domain.Enums;
using static Patients.Data.Configurations.Common.PostgresTypes;

namespace Patients.Data.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("appointments", t =>
        {
            t.HasEnumCheckConstraint<AppointmentStatus>("chk_appointments_status", "status");
        });

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("id");

        builder.Property(a => a.PatientId).HasColumnName("patient_id");
        builder.Property(a => a.DoctorId).HasColumnName("doctor_id");
        builder.Property(a => a.CreatedByUserId).HasColumnName("created_by_user_id");

        builder.Property(a => a.AppointmentDate)
            .HasColumnName("appointment_date")
            .HasColumnType(TimeStampTz);

        builder.Property(a => a.Status)
            .HasColumnName("status")
            .HasPostgresVarchar(20, allowStringConversion: true);

        // Связи
        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.CreatedByUser)
            .WithMany(u => u.CreatedAppointments)
            .HasForeignKey(a => a.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}