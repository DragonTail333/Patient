using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patients.Data.Configurations.Common;
using Patients.Domain;
using static Patients.Data.Configurations.Common.PostgresTypes;

namespace Patients.Data.Configurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable("prescriptions");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");

        builder.Property(p => p.ExaminationId).HasColumnName("examination_id");

        builder.Property(p => p.MedicationName)
            .HasColumnName("medication_name")
            .HasPostgresVarchar(200);

        builder.Property(p => p.Dosage)
            .HasColumnName("dosage")
            .HasPostgresVarchar(100);

        builder.Property(p => p.Instructions)
            .HasColumnName("instructions")
            .HasColumnType(Text);

        builder.HasOne(p => p.Examination)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(p => p.ExaminationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}