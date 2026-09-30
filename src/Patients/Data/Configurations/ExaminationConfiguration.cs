using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patients.Data.Configurations.Common;
using Patients.Domain;
using static Patients.Data.Configurations.Common.PostgresTypes;

namespace Patients.Data.Configurations;

public class ExaminationConfiguration : IEntityTypeConfiguration<Examination>
{
    public void Configure(EntityTypeBuilder<Examination> builder)
    {
        builder.ToTable("examinations");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.AppointmentId).HasColumnName("appointment_id");

        builder.Property(e => e.ExaminationDate)
            .HasColumnName("examination_date")
            .HasColumnType(TimeStampTz);

        builder.Property(e => e.Complaints)
            .HasColumnName("complaints")
            .HasColumnType(Text);

        builder.Property(e => e.Anamnesis)
            .HasColumnName("anamnesis")
            .HasColumnType(Text);

        builder.Property(e => e.Diagnosis)
            .HasColumnName("diagnosis")
            .HasColumnType(Text);

        builder.Property(e => e.Recommendations)
            .HasColumnName("recommendations")
            .HasColumnType(Text);

        // Связь 1-к-1 с приёмом
        builder.HasOne(e => e.Appointment)
            .WithOne(a => a.Examination)
            .HasForeignKey<Examination>(e => e.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.AppointmentId).IsUnique();
    }
}