using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patients.Data.Configurations.Common;
using Patients.Domain;
using static Patients.Data.Configurations.Common.PostgresTypes;

namespace Patients.Data.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("doctors");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).HasColumnName("id");

        builder.Property(d => d.UserId).HasColumnName("user_id");
        builder.Property(d => d.SpecialtyId).HasColumnName("specialty_id");

        builder.Property(d => d.RoomNumber)
            .HasColumnName("room_number")
            .HasPostgresVarchar(20);

        builder.Property(d => d.Phone)
            .HasColumnName("phone")
            .HasPostgresVarchar(20);

        // Связи
        builder.HasOne(d => d.User)
            .WithOne(u => u.Doctor)
            .HasForeignKey<Doctor>(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(d => d.UserId).IsUnique();

        builder.HasOne(d => d.Specialty)
            .WithMany(s => s.Doctors)
            .HasForeignKey(d => d.SpecialtyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}