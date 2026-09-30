using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patients.Data.Configurations.Common;
using Patients.Domain;
using static Patients.Data.Configurations.Common.PostgresTypes;

namespace Patients.Data.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("patients");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");

        builder.Property(p => p.CardNumber)
            .HasColumnName("card_number")
            .HasPostgresVarchar(20);

        builder.HasIndex(p => p.CardNumber).IsUnique();

        builder.Property(p => p.LastName)
            .HasColumnName("last_name")
            .HasPostgresVarchar(100);

        builder.Property(p => p.FirstName)
            .HasColumnName("first_name")
            .HasPostgresVarchar(100);

        builder.Property(p => p.MiddleName)
            .HasColumnName("middle_name")
            .HasPostgresVarchar(100)
            .IsRequired(false);

        builder.Property(p => p.BirthDate)
            .HasColumnName("birth_date")
            .HasColumnType(Date);

        builder.Property(p => p.Gender)
            .HasColumnName("gender")
            .HasPostgresVarchar(10);

        builder.Property(p => p.Phone)
            .HasColumnName("phone")
            .HasPostgresVarchar(20);

        builder.Property(p => p.PolicyNumber)
            .HasColumnName("policy_number")
            .HasPostgresVarchar(50);
    }
}