using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patients.Data.Configurations.Common;
using Patients.Domain;
using Patients.Domain.Enums;

namespace Patients.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", t =>
        {
            t.HasEnumCheckConstraint<UserRole>("chk_users_role", "role");
        });

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id");

        builder.Property(u => u.Login)
            .HasColumnName("login")
            .HasPostgresVarchar(50);

        builder.HasIndex(u => u.Login).IsUnique();

        builder.Property(u => u.PasswordHash)
            .HasColumnName("password_hash")
            .HasPostgresVarchar(255);

        builder.Property(u => u.Role)
            .HasColumnName("role")
            .HasPostgresVarchar(20, allowStringConversion: true);

        builder.Property(u => u.LastName)
            .HasColumnName("last_name")
            .HasPostgresVarchar(100);

        builder.Property(u => u.FirstName)
            .HasColumnName("first_name")
            .HasPostgresVarchar(100);

        builder.Property(u => u.MiddleName)
            .HasColumnName("middle_name")
            .HasPostgresVarchar(100)
            .IsRequired(false);
    }
}