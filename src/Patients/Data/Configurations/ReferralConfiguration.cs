using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patients.Data.Configurations.Common;
using Patients.Domain;
using static Patients.Data.Configurations.Common.PostgresTypes;

namespace Patients.Data.Configurations;

public class ReferralConfiguration : IEntityTypeConfiguration<Referral>
{
    public void Configure(EntityTypeBuilder<Referral> builder)
    {
        builder.ToTable("referrals");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("id");

        builder.Property(r => r.ExaminationId).HasColumnName("examination_id");

        builder.Property(r => r.ReferralType)
            .HasColumnName("referral_type")
            .HasPostgresVarchar(100);

        builder.Property(r => r.TargetDescription)
            .HasColumnName("target_description")
            .HasColumnType(Text);

        builder.HasOne(r => r.Examination)
            .WithMany(e => e.Referrals)
            .HasForeignKey(r => r.ExaminationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}